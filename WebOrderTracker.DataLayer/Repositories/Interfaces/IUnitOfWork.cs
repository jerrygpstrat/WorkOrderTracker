using WebOrderTracker.DataLayer.Entities;

namespace WebOrderTracker.DataLayer.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkOrderRepository WorkOrders { get; }
        IRepository<Asset> Assets { get; }
        IRepository<Technician> Technicians { get; }
        IRepository<Part> Parts { get; }

        // Commits all changes inside a single database transaction
        Task<int> CompleteAsync();
    }
}
