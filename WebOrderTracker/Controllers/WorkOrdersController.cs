using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using WebOrderTracker.Business.Dtos;
using WebOrderTracker.Business.Dtos.Requests;
using WebOrderTracker.Business.Services;

namespace WebOrderTracker.Controllers
{
    public class WorkOrdersController : BaseController
    {
        public WorkOrdersController(WorkOrderService workOrderService, IMapper mapper) : base(workOrderService, mapper) { }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public  IActionResult NewWorkOrder()
        {
            NewWorkOrderViewModel newWordOrder = new NewWorkOrderViewModel();
            return View(newWordOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> NewWorkOrder(NewWorkOrderViewModel model)
        {
            // If validation fails (e.g., missing required fields), return the view 
            // with the input data preserved and validation messages displayed.
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await CreateNewWorkOrder(model);

            // 3. Redirect back to an index or confirmation page to prevent duplicate submissions (PRG Pattern)
            return RedirectToAction("Index", "Home");
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
