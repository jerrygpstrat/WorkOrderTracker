using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebOrderTracker.Business.Services;

namespace WebOrderTracker.Controllers
{
    public class WorkOrdersController : BaseController
    {

        public WorkOrdersController(WorkOrderService workOrderService) : base(workOrderService) { }

        public async Task<IActionResult> Index()
        {



            return View();
        }


        /// <summary>
        /// Get all active orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<JsonResult> GetAllActiveOrders()
        {
            var activeOrders = await GetActiveOrders();
            return new JsonResult(new
            {
                rows = activeOrders.ToList(),
                total = activeOrders != null ? activeOrders.Count() : 0
            });
        }
    }
}
