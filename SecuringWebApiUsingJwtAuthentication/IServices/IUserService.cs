using SecuringWebApiUsingJwtAuthentication.Models;
using System.Threading.Tasks;

namespace SecuringWebApiUsingJwtAuthentication.IServices
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);
    }
}
