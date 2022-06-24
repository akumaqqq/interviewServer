using AutoMapper;
using InterviewServer.Configuration;
using InterviewServer.DAO.Entities;
using InterviewServer.DAO.Providers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewServer.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> RegistrationAsync(User user)
        {
            var result = await _usersProvider.CreatAsync(user);
            if (result != ResponseStatus.Succeed)
            {
                return BadRequest(new { error = result.ToString() });
            }

            return Ok(new { result = result.ToString() });
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAsync()
        {
            var idUser = User.GetUserId();
            var result = await _usersProvider.DeleteAsync(idUser);
            if (result != ResponseStatus.Succeed)
            {
                return BadRequest(new { error = result.ToString() });
            }

            return Ok(new { result = result.ToString() });
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(UpdatableUserData user)
        {
            user.Id = User.GetUserId();
            var result = await _usersProvider.UpdateAsync(user);
            if (result != ResponseStatus.Succeed)
            {
                return BadRequest(new { error = result.ToString() });
            }

            return Ok(new { result = result.ToString() });
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAsync()
        {
            var idUser = User.GetUserId();
            (User user, ResponseStatus status) = await _usersProvider.GetAsync(idUser);
            if (status != ResponseStatus.Succeed)
            {
                return BadRequest(new { error = status.ToString() });
            }

            return Ok(_mapper.Map<UserResponse>(user));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LogInAsync(LogInRequest logInRequest)
        {
            var result = await _usersProvider.LogInAsync(logInRequest);
            return Ok(result);
        }
    }
}
