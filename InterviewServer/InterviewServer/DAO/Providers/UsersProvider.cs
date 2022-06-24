using InterviewServer.Configuration;
using InterviewServer.DAO.Entities;
using InterviewServer.DAO.Providers.DB;
using InterviewServer.DAO.Providers.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace InterviewServer.DAO.Providers
{
    internal class UsersProvider : IUsersProvider
    {
        private readonly UsersContext _usersContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UsersProvider(UsersContext usersContext, IPasswordHasher<User> passwordHasher)
        {
            _usersContext = usersContext;
            _passwordHasher = passwordHasher;
        }
        public async Task<ResponseStatus> CreatAsync(User user)
        {
            if (new List<string> { user.Name, user.Login, user.Password }.Any(x => string.IsNullOrEmpty(x)))
            {
                return ResponseStatus.FilledNotAllRequiredFields;
            }

            if (await _usersContext.Users.AnyAsync(x => x.Login == user.Login))
            {
                return ResponseStatus.LoginExists;
            }

            user.Id = 0;
            user.Password = _passwordHasher.HashPassword(user, user.Password);

            user.Status = UserStatus.Active;
            _usersContext.Users.Add(user);

            await _usersContext.SaveChangesAsync();
            return ResponseStatus.Succeed;
        }

        public async Task<ResponseStatus> DeleteAsync(long idUser)
        {
            var user = await _usersContext.Users.FirstOrDefaultAsync(x => x.Id == idUser);
            if (user == null)
            {
                return ResponseStatus.NotFound;
            }
            user.Status = UserStatus.Deleted;

            await _usersContext.SaveChangesAsync();
            return ResponseStatus.Succeed;
        }

        public async Task<(User, ResponseStatus)> GetAsync(long idUser)
        {
            var user = await _usersContext.Users.SingleOrDefaultAsync(x => x.Id == idUser);
            if (user == null)
            {
                return (null, ResponseStatus.NotFound);
            }

            return (user, ResponseStatus.Succeed);
        }

        public async Task<ResponseStatus> UpdateAsync(UpdatableUserData update)
        {
            //тут можно понять больше полей, но тк логично менять только имя, оставила его 
            var user = await _usersContext.Users.FirstOrDefaultAsync(x => x.Id == update.Id).ConfigureAwait(false);
            if (user == null)
            {
                return ResponseStatus.NotFound;
            }

            user.Name = !string.IsNullOrWhiteSpace(update.Name) ? update.Name : user.Name;

            await _usersContext.SaveChangesAsync();
            return ResponseStatus.Succeed;
        }

        public async Task<ResponseStatus> ChangePasswordAsync(string oldPassword, string newPassword, long userId)
        {
            var user = await _usersContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.Password, oldPassword) != PasswordVerificationResult.Success)
            {
                return ResponseStatus.WrongPasswordOrLogin;
            }

            user.Password = _passwordHasher.HashPassword(user, newPassword);
            await _usersContext.SaveChangesAsync();
            return ResponseStatus.Succeed;
        }

        public async Task<TokenResponse> LogInAsync(LogInRequest logInRequest)
        {
            var user = await _usersContext.Users.FirstOrDefaultAsync(x => x.Login == logInRequest.Login).ConfigureAwait(false);
            if (user == null)
            {
                return new TokenResponse()
                {
                    Status = ResponseStatus.NotFound,
                    Token = ""
                };
            }
            if (_passwordHasher.VerifyHashedPassword(user, user.Password, logInRequest.Password) != PasswordVerificationResult.Success)
            {
                return new TokenResponse()
                {
                    Status = ResponseStatus.WrongPasswordOrLogin,
                    Token = ""
                };
            }

            var token = GenerateToken(new
            {
                user.Id,
                user.Login
            });

            return new TokenResponse()
            {
                Status = ResponseStatus.Succeed,
                Token = token
            };
        }

        private static string GenerateToken<T>(T payload)
        {
            JwtPayload jwtPayload = JwtPayload.Deserialize(JsonSerializer.Serialize(payload));
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: DateTime.UtcNow,
                    claims: jwtPayload.Claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
