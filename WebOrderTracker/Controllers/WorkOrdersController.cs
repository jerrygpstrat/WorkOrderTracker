using Microsoft.AspNetCore.Mvc;
using WebOrderTracker.Business.Services;

namespace WebOrderTracker.Controllers
{
    public class WorkOrdersController : BaseController
    {

       public WorkOrdersController(WorkOrderService workOrderService) : base(workOrderService) { }

        public async Task<IActionResult> Index()
        {
            var activeOrders = await GetActiveOrders();


            return View();
        }
    }
}
