using SQLite;

namespace Ins.Core.Models
{
    public class User
    {
        [PrimaryKey]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ProfilePictureID { get; set; }
    }
}