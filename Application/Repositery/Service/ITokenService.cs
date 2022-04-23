using Application.Conmon.Request.Identity;
using Application.Conmon.Response.Identity;
using Share.Wapper;

namespace Application.Repositery.Service
{
    public interface ITokenService 
    {
        Task<Response<TokenResponse>> LoginAsync(TokenRequest model);
        Task<Response<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}
