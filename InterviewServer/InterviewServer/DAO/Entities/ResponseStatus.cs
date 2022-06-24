namespace InterviewServer.DAO.Entities
{
    public enum ResponseStatus
    {
        Succeed,
        NotFound,
        FilledNotAllRequiredFields,
        LoginExists,
        WrongPasswordOrLogin
    }
}
