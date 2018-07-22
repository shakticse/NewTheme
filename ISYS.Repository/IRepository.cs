using ISYS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISYS.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Get(string id);
        Task<IEnumerable<T>> GetById(string id);
        Task<Result> Insert(T entity);
        Task<Result> Update(T entity);
        Task<Result> Delete(T entity);
    }
}