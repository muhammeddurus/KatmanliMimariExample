using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public interface IRepository<T>
    {

        List<T> GetAll();
        void Insert(T item);

        T GetById(int itemId);

        void Update(T item);
        void Delete(int itemId);
    }
}
