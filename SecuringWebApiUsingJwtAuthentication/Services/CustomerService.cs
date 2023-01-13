﻿using SecuringWebApiUsingJwtAuthentication.Helpers;
using SecuringWebApiUsingJwtAuthentication.IServices;
using SecuringWebApiUsingJwtAuthentication.Models;
using SecuringWebApiUsingJwtAuthentication.Requests;
using SecuringWebApiUsingJwtAuthentication.Responses;
using System.Linq;
using System.Threading.Tasks;

namespace SecuringWebApiUsingJwtAuthentication.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly JwtAuthDbContext customersDbContext;
        public CustomerService(JwtAuthDbContext customersDbContext)
        {
            this.customersDbContext = customersDbContext;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var customer = customersDbContext.Customer.SingleOrDefault(customer => customer.Active && customer.Username == loginRequest.Username);

            if (customer == null)
            {
                return null;
            }
            var passwordHash = HashingHelper.HashUsingPbkdf2(loginRequest.Password, customer.PasswordSalt);
            if (customer.Password != passwordHash)
            {
                return null;
            }
            var token = await Task.Run(() => TokenHelper.GenerateToken(customer));
            return new LoginResponse { Username = customer.Username, FirstName = customer.FirstName, LastName = customer.LastName, Token = token };
        }

    }
}
