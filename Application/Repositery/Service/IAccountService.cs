using Application.Conmon.Request.Identity;
using Share.Wapper;

namespace Application.Repositery.Service
{
    public interface IAccountService
    {
        Task<IResponse> ChangePasswordAsync(ChangePasswordRequest model, Guid userId);
    }
}
