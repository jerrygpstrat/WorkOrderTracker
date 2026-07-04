using Microsoft.EntityFrameworkCore;
using WebOrderTracker.DataLayer.Entities;
using WebOrderTracker.DataLayer.Repositories.Interfaces;

namespace WebOrderTracker.DataLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public IWorkOrderRepository WorkOrders { get; private set; }
        public IRepository<Asset> Assets { get; private set; }
        public IRepository<Technician> Technicians { get; private set; }
        public IRepository<Part> Parts { get; private set; }

        public UnitOfWork(DbContext context)
        {
            _context = context;
            WorkOrders = new WorkOrderRepository(_context);
            Assets = new Repository<Asset>(_context);
            Technicians = new Repository<Technician>(_context);
            Parts = new Repository<Part>(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
