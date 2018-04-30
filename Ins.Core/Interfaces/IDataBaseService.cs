using Ins.Core.Models;
using System.Collections.Generic;

namespace Ins.Core.Interfaces
{
    public interface IDataBaseService<T>
    {
        bool InDataBase(object primaryKey);

        void CreateDataBase();
        void InsertIntoTable(T item);
        void UpdateTable(T item);
        T GetItem(object primaryKey);

        List<T> GetItems();
    }
}