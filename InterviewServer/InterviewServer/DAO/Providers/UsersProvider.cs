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

        public async Task<(User, ResponseStatus)> GetAsync(long idUser)
        {
            var user = await _usersContext.Users.SingleOrDefaultAsync(x => x.Id == idUser);
            if (user == null)
            {
                return (null, ResponseStatus.NotFound);
            }

            return (user, ResponseStatus.Succeed);
        }

        public Task<ResponseStatus> UpdateAsync(User updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
