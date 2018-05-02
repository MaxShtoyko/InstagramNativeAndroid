using Ins.Core.Models;

namespace Ins.Core.Mappers
{
    public class UserMapper
    {
        public static User MapToDto(UserJson userJson)
        {
            User resultUser = new User();

            resultUser.Email = userJson.Email;
            resultUser.FullName = userJson.FullName;
            resultUser.ProfilePictureID = userJson.ProfilePictureID;
            resultUser.PictureUrl = userJson.PictureData?.Data.Url;

            return resultUser;
        }
    }
}
