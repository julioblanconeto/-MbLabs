using DataAcess.Dtos;
using DataAcess.Helpers;
using DataLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEventos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private AuthorizationSerivices authorizationSerivices;

        public AuthorizationController(DataContext context)
        {
            authorizationSerivices = new AuthorizationSerivices(context);
        }

        [HttpPost(Name = "Login")]
        public async Task<int> login([FromBody] LoginDto Login)
        {
            return  await authorizationSerivices.ValidateUser(Login);
          
        }
    }
}
