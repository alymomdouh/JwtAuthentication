using SecuringWebApiUsingJwtAuthentication.Helpers;
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
            /*
             Here we are using a key-based derivation function (PBKDF2) which it applies the HMac function in combination with a 
            hashing algorithm (SHA-256) to the password with a salt (base64 encoded random number with size 128-bit) and repeats 
            this as many times as specified in the iterations parameter (10000 times is the default) in our example to derive a random key from the produced result.
            Key Derivation functions (or Password-Hashing functions), such as PBKDF2 or Bcrypt require a longer computation time and more resources 
            for a password to get cracked or brute-forced because of the large number of iterations applied along with the salt, this is called key stretching
            Note: You should never save a password in the database as-is (plain text), always make sure to calculate and save the hash of the password, 
            and use a Key Derivation function based hashing algorithm with a large key size (i.e 256-bit or more) and random large salt (64-bit or 128-bit) 
            to make it very difficult to crack the passwords.
             */
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
