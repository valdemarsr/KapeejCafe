using KapeejCafe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapeejCafe.Application.Common.Interfaces
{
    public interface IUnitiOfWork : IDisposable
    {
        IRepository<Producto> Productos { get; }
        IRepository<Ingrediente> Ingredientes { get; }
        Task<int> CompleteAsync();
    }
}
