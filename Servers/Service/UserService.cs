using Presistance.DataBase;
using System.Security.Claims;

namespace Servers.Service
{
    public class UserService : IUserSerive
    {
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            var id = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(id)) UserId = Guid.Parse(id);
            Claims = httpContextAccessor.HttpContext?.User.Claims.AsEnumerable()
                .Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
        }

        public List<KeyValuePair<string, string>> Claims { get; }
    }
}
