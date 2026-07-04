using Microsoft.EntityFrameworkCore;
using WebOrderTracker.DataLayer.Entities;
using WebOrderTracker.DataLayer.Entities.enums;
using WebOrderTracker.DataLayer.Repositories.Interfaces;

namespace WebOrderTracker.DataLayer.Repositories
{
    public class WorkOrderRepository : Repository<WorkOrder>, IWorkOrderRepository
    {
        public WorkOrderRepository(DbContext context) : base(context) { }

        // Eager loads the child checklist, parts, and labor logs
        public async Task<WorkOrder?> GetWorkOrderWithDetailsAsync(Guid id)
        {
            return await Context.Set<WorkOrder>()
                .Include(w => w.Asset)
                .Include(w => w.AssignedTechnician)
                .Include(w => w.Tasks)
                .Include(w => w.PartsUsed).ThenInclude(p => p.Part)
                .Include(w => w.LaborLogs)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<WorkOrder>> GetPendingWorkOrdersAsync()
        {
            return await Context.Set<WorkOrder>()
                .Where(w => w.Status == WorkOrderStatus.New || w.Status == WorkOrderStatus.InProgress)
                .OrderByDescending(w => w.Priority)
                .ToListAsync();
        }

        public async Task<IEnumerable<WorkOrder>> GetWorkOrderInStatusAsync(WorkOrderStatus workOrderStatus)
        {
            return await Context.Set<WorkOrder>()
                 .Where(w => w.Status == workOrderStatus)
                 .OrderByDescending(w => w.Priority)
                 .ToListAsync();
        }

        public async Task<IEnumerable<WorkOrder>> GetAllActiveWorkOrders()
        {
            return await Context.Set<WorkOrder>()
                 .Where(w => w.Status != WorkOrderStatus.Cancelled)
                 .OrderByDescending(w => w.Priority)
                 .ToListAsync();
        }
    }
}
