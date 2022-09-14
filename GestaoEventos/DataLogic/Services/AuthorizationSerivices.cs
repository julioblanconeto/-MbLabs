using DataAcess.Dtos;
using DataAcess.Helpers;
using DataAcess.Models;

namespace DataLogic.Services
{
    public class AuthorizationSerivices
    {
        private readonly DataContext _dtContext;

        public AuthorizationSerivices(DataContext context)
        {
            _dtContext = context;
        }

        public async Task<int> ValidateUser(LoginDto login)
        {
            Users user = new Users();
            try
            {
                user = _dtContext.Users.Where(x => x.Email == login.Email && x.Password == login.Password).First();

            }
            catch (Exception)
            {

               return 0;
            }

            return user.UserId;
        }
    }
}
