using InterviewServer.DAO.Entities;
using InterviewServer.DAO.Providers.Interfaces;

namespace InterviewServer.DAO.Providers
{
    internal class UsersProvider : IUsersProvider
    {
        public Task<ResponseStatus> CreatAsync(User newUser)
        {
            throw new NotImplementedException(); 
        }

        public Task<ResponseStatus> DeleteAsync(long idUser)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseStatus> GetAsync(long idUser)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseStatus> UpdateAsync(User updateUser)
        {
            throw new NotImplementedException();
        }
    }
}
