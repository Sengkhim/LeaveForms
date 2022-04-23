using System.ComponentModel.DataAnnotations;

namespace Application.Conmon.Request.Identity
{
    public class TokenRequest
    {
        [Required] public string? Email { get; set; }

        [Required] public string? Password { get; set; }
    }
}