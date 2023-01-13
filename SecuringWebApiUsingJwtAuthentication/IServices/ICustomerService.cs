using SecuringWebApiUsingJwtAuthentication.Requests;
using SecuringWebApiUsingJwtAuthentication.Responses;
using System.Threading.Tasks;

namespace SecuringWebApiUsingJwtAuthentication.IServices
{
    public interface ICustomerService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
