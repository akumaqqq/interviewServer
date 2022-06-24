using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewServer.DAO.Entities
{
    [Table("users")]
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
    }
}
