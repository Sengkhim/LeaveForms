using System.ComponentModel.DataAnnotations;

namespace Application.Conmon.Request.Identity
{
    public class UserClaimRequest
    {
        [Required] public string? UserId { get; set; }
        [Required] public string? type { get; set; }
        [Required] public string? value { get; set; }
    }
}