using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using WebOrderTracker.Business.Dtos;
using WebOrderTracker.Business.Dtos.Requests;
using WebOrderTracker.Business.Services;

namespace WebOrderTracker.Controllers
{
    /// <summary>
    /// This controller holds anything common to any other controller, base controller
    /// </summary>
    public class BaseController(WorkOrderService workOrderService, IMapper mapper) : Controller
    {

        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        private readonly WorkOrderService _workOrderService = workOrderService ?? throw new ArgumentNullException(nameof(workOrderService));

        /// <summary>
        /// Get all active Orders from Business
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WorkOrderDto>> GetActiveOrders()
        {
          return await _workOrderService.GetAllActiveWorkOrders();
        }

        public async Task<WorkOrderDto> CreateNewWorkOrder(NewWorkOrderViewModel model)
        {
            var modelDto = model.Adapt<WorkOrderDto>();
            return await _workOrderService.CreateWorkOrderAsync(modelDto);
        }

        public async Task<string> GetNewWorkOrderNumber(string key = "WONumberSequence")
        {
            return await _workOrderService.GetNextWordOrderNumber(key);
        }
    }
}
