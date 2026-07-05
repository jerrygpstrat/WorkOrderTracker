using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebOrderTracker.Business.Dtos.Requests;
using WebOrderTracker.Business.Services;

namespace WebOrderTracker.Controllers
{
    public class WorkOrdersController : BaseController
    {

        public WorkOrdersController(WorkOrderService workOrderService) : base(workOrderService) { }

        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult AddNewWorkOrder()
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
