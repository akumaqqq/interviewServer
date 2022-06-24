using AutoMapper;
using InterviewServer.DAO.Entities;
using InterviewServer.DAO.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InterviewServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersProvider _usersProvider;
        private readonly IMapper _mapper;

        public AuthController(IServiceProvider serviceProvider)
        {
            _usersProvider = serviceProvider.GetService<IUsersProvider>();
            _mapper = serviceProvider.GetService<IMapper>();
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
        public async Task<IActionResult> GetAsync(long idUser)
        {
            (User user, ResponseStatus status) = await _usersProvider.GetAsync(idUser);
            if (status != ResponseStatus.Succeed)
            { 
                return BadRequest(new { error = status.ToString() });
            }

            return Ok(_mapper.Map<UserResponse>(user));
        }

    }
}
