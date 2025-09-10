using KapeejCafe.Application.Common.Interfaces;
using KapeejCafe.Domain.Entities;
using KapeejCafe.Infrastructure.Persistence;
using KapeejCafe.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitiOfWork
    {
        private readonly KapeejCafeDbContext _context;
        public IRepository<Producto> Productos { get; }
        public IRepository<Ingrediente> Ingredientes { get; }
        public UnitOfWork(KapeejCafeDbContext context)
        {
            _context = context;
            Productos = new Repository<Producto>(_context);
            Ingredientes = new Repository<Ingrediente>(_context);
        }
        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
