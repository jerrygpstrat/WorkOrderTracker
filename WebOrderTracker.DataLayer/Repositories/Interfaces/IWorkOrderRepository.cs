using WebOrderTracker.Common.Enums;
using WebOrderTracker.DataLayer.Entities;

namespace WebOrderTracker.DataLayer.Repositories.Interfaces
{
    public interface IWorkOrderRepository : IRepository<WorkOrder>
    {
        Task<WorkOrder?> GetWorkOrderWithDetailsAsync(Guid id);
        Task<IEnumerable<WorkOrder>> GetPendingWorkOrdersAsync();
        Task<IEnumerable<WorkOrder>> GetWorkOrderInStatusAsync(WorkOrderStatus workOrderStatus);
        Task<IEnumerable<WorkOrder>> GetAllActiveWorkOrders();
    }
}
