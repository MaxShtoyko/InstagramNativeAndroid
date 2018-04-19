using Ins.Core.Models;

namespace Ins.Core.Interfaces
{
    public interface IUserService
    {
        User GetCurrentUser();
        bool IsCorrect(User user);
        void SetUser(FacebookProfile result);
    }
}