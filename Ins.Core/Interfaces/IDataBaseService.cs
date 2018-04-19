using Ins.Core.Models;
using System.Collections.Generic;

namespace Ins.Core.Interfaces
{
    public interface IDataBaseService
    {
        bool InDataBase(User user);

        void CreateDataBase();
        void InsertIntoTableUser(User User);
        void UpdateTableUser(User User);

        List<User> GetUsers();
    }
}