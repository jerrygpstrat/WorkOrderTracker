using Mapster;
using WebOrderTracker.Business.Dtos;
using WebOrderTracker.DataLayer.Entities;
using WebOrderTracker.DataLayer.Entities.enums;
using WebOrderTracker.DataLayer.Repositories.Interfaces;

namespace WebOrderTracker.Business.Services
{

    /// <summary>
    /// Work order service
    /// </summary>
    public class WorkOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CompleteWorkOrderJobAsync(Guid workOrderId)
        {
            // 1. Fetch the complete graph using custom repo method
            var workOrder = await _unitOfWork.WorkOrders.GetWorkOrderWithDetailsAsync(workOrderId);
            
            if (workOrder == null) 
                throw new Exception("We could not assign WorkOrders");

            // 2. Call the encapsulated domain logic inside your entity
            workOrder.CompleteWorkOrder();

            // 3. Batch save all modifications (Status, Tasks, etc.) in one atomic database call
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<WorkOrderDto>> GetWorkOrdersInStatus(WorkOrderStatus workOrderStatus)
        {
            var foundOrders = await _unitOfWork.WorkOrders.GetWorkOrderInStatusAsync(workOrderStatus);
            return foundOrders.Adapt<IEnumerable<WorkOrderDto>>();
        }

        public async Task<IEnumerable<WorkOrderDto>> GetAllActiveWorkOrders()
        {
            var foundOrders = await _unitOfWork.WorkOrders.GetAllActiveWorkOrders();
            return foundOrders.Adapt<IEnumerable<WorkOrderDto>>();
        }

        public async Task<WorkOrderDto> CreateWorkOrderAsync(WorkOrderDto model)
        {
            //TODO: verify for completion
            var dbModel = model.Adapt<WorkOrder>();
            await _unitOfWork.WorkOrders.AddAsync(dbModel);
            await _unitOfWork.CompleteAsync();

            var resultDto = dbModel.Adapt<WorkOrderDto>();

            return resultDto;
        }
    }
}
