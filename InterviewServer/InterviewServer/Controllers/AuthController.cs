using InterviewServer.DAO.Providers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersProvider _usersProvider;

        public AuthController(IServiceProvider serviceProvider)
        {
            _usersProvider = serviceProvider.GetService<IUsersProvider>();
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> RegistrationAsync()
        {
            
            return await Task.FromResult(Ok("hello")); 
        }

        [HttpDelete]
        [Route("delete")]
        public Task<IActionResult> DeleteAsync()
        {
            return null;
        }

        [HttpPut]
        [Route("update")]
        public Task<IActionResult> UpdateAsync() 
        {
            return null;
        }

        [HttpGet]
        [Route("get")]
        public Task<IActionResult> GetAsync()
        {
            return null;
        }

    }
}
