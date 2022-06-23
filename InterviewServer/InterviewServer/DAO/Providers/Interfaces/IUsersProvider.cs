using InterviewServer.DAO.Entities;

namespace InterviewServer.DAO.Providers.Interfaces
{
    internal interface IUsersProvider
    {
        Task<ResponseStatus> CreatAsync(User newUser);
        Task<ResponseStatus> GetAsync(long idUser); 
        Task<ResponseStatus> UpdateAsync(User updateUser); 
        Task<ResponseStatus> DeleteAsync(long idUser);
    }
}
