namespace InterviewServer.DAO.Entities
{
    internal enum ResponseStatus
    {
        Succeed,
        NotFound,
        FilledNotAllRequiredFields,
        LoginExists,
        WrongPasswordOrLogin
    }
}
