using Newtonsoft.Json;

namespace Ins.Core.Models
{
    public class UserJson
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string ProfilePictureID { get; set; }

        [JsonProperty("picture")]
        public Picture PictureData { get; set; }

        public partial class Picture
        {
            [JsonProperty("data")]
            public Data Data { get; set; }
        }

        public partial class Data
        {
            [JsonProperty("height")]
            public long Height { get; set; }

            [JsonProperty("is_silhouette")]
            public bool IsSilhouette { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("width")]
            public long Width { get; set; }
        }
    }
}
