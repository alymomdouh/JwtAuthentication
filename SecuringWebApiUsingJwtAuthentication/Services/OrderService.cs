using Microsoft.EntityFrameworkCore;
using SecuringWebApiUsingJwtAuthentication.IServices;
using SecuringWebApiUsingJwtAuthentication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringWebApiUsingJwtAuthentication.Services
{
    public class OrderService : IOrderService
    {
        private readonly JwtAuthDbContext customersDbContext; 
        public OrderService(JwtAuthDbContext customersDbContext)
        {
            this.customersDbContext = customersDbContext;
        }
        public async Task<List<Order>> GetOrdersByCustomerId(int id)
        {
            var orders = await customersDbContext.Order.Where(order => order.CustomerId == id).ToListAsync(); 
            return orders;
        } 
    }
}
