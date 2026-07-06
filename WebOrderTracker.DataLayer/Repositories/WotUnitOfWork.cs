using WebOrderTracker.DataLayer.Context;
using WebOrderTracker.DataLayer.Entities;
using WebOrderTracker.DataLayer.Repositories.Interfaces;

namespace WebOrderTracker.DataLayer.Repositories
{
    /// <summary>
    /// Work Order Tracker unit of work
    /// </summary>
    public class WotUnitOfWork : IUnitOfWork
    {
        private readonly WoTrackerDbContext _context;

        public IWorkOrderRepository WorkOrders { get; private set; }
        public IRepository<Asset> Assets { get; private set; }
        public IRepository<Technician> Technicians { get; private set; }
        public IRepository<Part> Parts { get; private set; }
        public IRepository<AppVar> AppVars { get; private set; }


        public WotUnitOfWork(WoTrackerDbContext context)
        {
            _context = context;
            WorkOrders = new WorkOrderRepository(_context);
            Assets = new Repository<Asset>(_context);
            Technicians = new Repository<Technician>(_context);
            Parts = new Repository<Part>(_context);
            AppVars = new Repository<AppVar>(_context);
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
