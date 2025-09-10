using KapeejCafe.Application.Common.Interfaces;
using KapeejCafe.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly KapeejCafeDbContext _context;
        public Repository(KapeejCafeDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(Guid Id) => await _context.Set<T>().FindAsync(Id);
        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Remove(T entity) => _context.Set<T>().Remove(entity);

        
    }
}
