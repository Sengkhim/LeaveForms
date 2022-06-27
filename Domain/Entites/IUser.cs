
using Domain.Authentication;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public interface IUser
    {
        public Guid Id { get; set; }
    }


    /// <summary>
    /// 
    /// </summary>
    public interface EntityUser
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }
}
