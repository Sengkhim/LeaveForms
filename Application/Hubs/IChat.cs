using MediatR;

namespace Application.Hubs
{
    public interface IChat<Entity> where Entity : class
    {
        Task SendPrivate(string receiverName, string message);
        Task Join(string roomName);
        Task Leave(string roomName);
        IEnumerable<Entity> GetUsers(string roomName);
        string GetDevice();
    }
}
