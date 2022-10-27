using BLL.Request;
using BLL.Response;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utility.Helpers;

namespace BLL.Services
{
    public interface IAccountService
    {
        Task<LoginResponse> LoginUser(LoginRequest request);
        Task<LoginResponse> RefreshToken(string refreshToken);
        Task Test(ClaimsPrincipal tt);
        Task<SuccessResponse> Logout(ClaimsPrincipal tt);
    }
}
