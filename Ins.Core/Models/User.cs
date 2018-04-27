using SQLite;
using Newtonsoft.Json;

namespace Ins.Core.Models
{
    public class User
    {
        [PrimaryKey]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string FullName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ProfilePictureID { get; set; }
    }
}