using Microsoft.AspNetCore.Mvc;
using WebOrderTracker.Business.Services;
using WebOrderTracker.DataLayer.Entities;

namespace WebOrderTracker.Controllers
{


    /// <summary>
    /// This controller holds anything common to any other controller, base controller
    /// </summary>
    public class BaseController(WorkOrderService workOrderService) : Controller
    {
        private readonly WorkOrderService _workOrderService = workOrderService ?? throw new ArgumentNullException(nameof(workOrderService));

        /// <summary>
        /// Get all active Orders from Business
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WorkOrder>> GetActiveOrders()
        {
          return await _workOrderService.GetAllActiveWorkOrders();
        }
    }
}
