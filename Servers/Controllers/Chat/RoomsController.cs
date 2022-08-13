using Application.Conmon;
using Application.Hubs;
using AutoMapper;
using Domain.Entites.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Presistance.DataBase;

namespace Servers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHubContext<Chat> _hubContext;

        public RoomsController(DataContext context,
            IMapper mapper,
            IHubContext<Chat> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomViewModel>>> Get()
        {
            var rooms = await _context.Rooms.ToListAsync();

            var roomsViewModel = _mapper.Map<IEnumerable<Room>, IEnumerable<RoomViewModel>>(rooms);

            return Ok(roomsViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> Get(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
                return NotFound();

            var roomViewModel = _mapper.Map<Room, RoomViewModel>(room);
            return Ok(roomViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Room>> Create(RoomViewModel roomViewModel)
        {
            if (_context.Rooms.Any(r => r.Name == roomViewModel.Name))
                return BadRequest("Invalid room name or room already exists");

            var user = _context.Users.FirstOrDefault(u => u.UserName == User.Identity!.Name);
            var room = new Room()
            {
                Id = Guid.NewGuid().ToString(),
                Name = roomViewModel.Name,
                User   = user
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("addChatRoom", new { id = room.Id, name = room.Name });

            return CreatedAtAction(nameof(Get), new { id = room.Id }, new { id = room.Id, name = room.Name });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, RoomViewModel roomViewModel)
        {
            if (_context.Rooms.Any(r => r.Name == roomViewModel.Name))
                return BadRequest("Invalid room name or room already exists");

            var room = await _context.Rooms
                .Include(r => r.User)
                .Where(r => r.Id == id && r.User!.UserName == User.Identity!.Name)
                .FirstOrDefaultAsync();

            if (room == null)
                return NotFound();

            room.Name = roomViewModel.Name;
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("updateChatRoom", new { id = room.Id, room.Name });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var room = await _context.Rooms
                .Include(r => r.User)
                .Where(r => r.Id == id && r.User!.UserName == User.Identity!.Name)
                .FirstOrDefaultAsync();

            if (room == null)
                return NotFound();

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("removeChatRoom", room.Id);
            await _hubContext.Clients.Group(room.Name).SendAsync("onRoomDeleted", string.Format("Room {0} has been deleted.\nYou are moved to the first available room!", room.Name));

            return NoContent();
        }
    }
}
