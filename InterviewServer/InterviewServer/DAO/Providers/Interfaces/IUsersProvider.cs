using InterviewServer.DAO.Entities;

namespace InterviewServer.DAO.Providers.Interfaces
{
    internal interface IUsersProvider
    {
        Task<ResponseStatus> CreatAsync(User newUser);
        Task<(User, ResponseStatus)> GetAsync(long idUser); 
        Task<ResponseStatus> UpdateAsync(UpdatableUserData updateUser); 
        Task<ResponseStatus> DeleteAsync(long idUser);
        Task<ResponseStatus> ChangePasswordAsync(string oldPassword, string newPassword, long userId);
        Task<TokenResponse> LogInAsync(LogInRequest logInRequest);
    }
}
