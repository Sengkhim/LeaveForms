using Application.Conmon;
using Application.Conmon.Response.Identity;
using AutoMapper;
using Domain.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Presistance.DataBase;
using System.Text.RegularExpressions;

namespace Application.Hubs
{
    [Authorize]
    public class Chat : Hub, IChat<UserResponse>
    {
        private readonly static Dictionary<string, string> _ConnectionsMap = new Dictionary<string, string>();
        public readonly static List<UserResponse> _Connections = new List<UserResponse>();
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public Chat(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        private string IdentityName
        {
            get { return Context.User.Identity.Name; }
        }
        public string GetDevice()
        {
            var device = Context.GetHttpContext()!.Request.Headers["Device"].ToString();
            if (!string.IsNullOrEmpty(device) && (device.Equals("Desktop") || device.Equals("Mobile")))
                return device;

            return "Web";
        }

        public async Task Join(string roomName)
        {
            try
            {
                var user = _Connections.Where(u => u.UserName == IdentityName).FirstOrDefault();
                if (user != null && user.CurrentRoom != roomName)
                {
                    // Remove user from others list
                    if (!string.IsNullOrEmpty(user.CurrentRoom))
                        await Clients.OthersInGroup(user.CurrentRoom).SendAsync("removeUser", user);

                    // Join to new chat room
                    await Leave(user.CurrentRoom!);
                    await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
                    user.CurrentRoom = roomName;

                    // Tell others to update their list of users
                    await Clients.OthersInGroup(roomName).SendAsync("addUser", user);
                }
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("onError", "You failed to join the chat room!" + ex.Message);
            }
        }

        public async Task Leave(string roomName) => await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);

        public Task SendMessageAsync(string message) => throw new NotImplementedException();

        public async Task SendPrivate(string receiverName, string message)
        {
            if (_ConnectionsMap.TryGetValue(receiverName, out string userId))
            {
                // Who is the sender;
                var sender = _Connections.Where(u => u.UserName == IdentityName).First();

                if (!string.IsNullOrEmpty(message.Trim()))
                {
                    // Build the message
                    var messageViewModel = new MessageViewModel()
                    {
                        Content = Regex.Replace(message, @"<.*?>", string.Empty),
                        From = sender.FullName!,
                        Avatar = sender.Avatar!,
                        Room = "",
                        Timestamp = DateTime.Now.ToLongTimeString()
                    };

                    // Send the message
                    await Clients.Client(userId).SendAsync("newMessage", messageViewModel);
                    await Clients.Caller.SendAsync("newMessage", messageViewModel);
                }
            }
        }

        public IEnumerable<UserResponse> GetUsers(string roomName) => _Connections.Where(u => u.CurrentRoom == roomName).ToList();
        public override Task OnConnectedAsync()
        {
            try
            {
                var user = _context.Users.Where(u => u.UserName == IdentityName).FirstOrDefault();
                var userViewModel = _mapper.Map<User, UserResponse>(user!);
                userViewModel.Device = GetDevice();
                userViewModel.CurrentRoom = "";

                if (!_Connections.Any(u => u.UserName == IdentityName))
                {
                    _Connections.Add(userViewModel);
                    _ConnectionsMap.Add(IdentityName, Context.ConnectionId);
                }

                Clients.Caller.SendAsync("getProfileInfo", user!.FullName, user.Avatar);
            }
            catch (Exception ex)
            {
                Clients.Caller.SendAsync("onError", "OnConnected:" + ex.Message);
            }
            return base.OnConnectedAsync();
        }
    }
}
