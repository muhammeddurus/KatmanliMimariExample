using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatmanliBLL.Repository
{
    public interface IRepository<T>
    {

        
        void Insert(T item);

        

        void Update(T item);
        void Delete(int itemId);
    }
}
