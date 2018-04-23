using Ins.Core.Models;
using System.Collections.Generic;

namespace Ins.Core.Interfaces
{
    public interface IDataBaseService<T>
    {
        bool InDataBase(object primaryKey);

        void CreateDataBase(string dataBaseName);
        void InsertIntoTable(T item);
        void UpdateTable(T item);

        List<T> GetItems();
    }
}