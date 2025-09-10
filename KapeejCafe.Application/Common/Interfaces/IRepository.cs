using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid Id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);


    }
}
