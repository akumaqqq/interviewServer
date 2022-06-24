namespace InterviewServer.DAO.Entities
{
    public class UserResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Login { get; set; }
        public UserStatus Status { get; set; }
    }
}
