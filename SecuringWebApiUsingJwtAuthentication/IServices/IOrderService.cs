using SecuringWebApiUsingJwtAuthentication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecuringWebApiUsingJwtAuthentication.IServices
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersByCustomerId(int id);
    }
}
