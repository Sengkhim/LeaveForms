
using Domain.Authentication;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public interface IUser
    {
        public Guid Id { get; set; }
    }
}
