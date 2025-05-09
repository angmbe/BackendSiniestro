using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSiniestro.Interface
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string tableName);
    }
}
