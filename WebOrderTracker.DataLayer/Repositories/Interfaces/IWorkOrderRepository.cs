using WebOrderTracker.DataLayer.Entities;
using WebOrderTracker.DataLayer.Entities.enums;

namespace WebOrderTracker.DataLayer.Repositories.Interfaces
{
    public interface IWorkOrderRepository : IRepository<WorkOrder>
    {
        Task<WorkOrder?> GetWorkOrderWithDetailsAsync(Guid id);
        Task<IEnumerable<WorkOrder>> GetPendingWorkOrdersAsync();
        Task<IEnumerable<WorkOrder>> GetWorkOrderInStatusAsync(WorkOrderStatus workOrderStatus);
    }
}
