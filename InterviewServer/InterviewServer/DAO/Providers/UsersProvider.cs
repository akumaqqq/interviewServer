using InterviewServer.DAO.Entities;
using InterviewServer.DAO.Providers.DB;
using InterviewServer.DAO.Providers.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InterviewServer.DAO.Providers
{
    internal class UsersProvider : IUsersProvider
    {
        private readonly UsersContext _usersContext;

        public UsersProvider(UsersContext usersContext)
        {
            _usersContext = usersContext;
        }
        public Task<ResponseStatus> CreatAsync(User newUser)
        {
            throw new NotImplementedException(); 
        }

        public Task<ResponseStatus> DeleteAsync(long idUser)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseStatus> GetAsync(long idUser)
        {
            _usersContext.Users.Add(new User()
            {
                BirthDay = DateTime.UtcNow,
                Login = "mjhnbgfv",
                Name = "hngbfvd",
                Password = "njhbgfdv",
                Status = UserStatus.Active
            });


            await _usersContext.SaveChangesAsync().ConfigureAwait(false);

            return ResponseStatus.Succeed;
        }

        public Task<ResponseStatus> UpdateAsync(User updateUser)
        {
            throw new NotImplementedException(); 
        }
    }
}
