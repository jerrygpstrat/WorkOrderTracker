using Mapster;
using System.Net.Http.Headers;
using WebOrderTracker.Business.Dtos;
using WebOrderTracker.Common.Enums;
using WebOrderTracker.DataLayer.Entities;
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

        public async Task<string> GetNextWordOrderNumber(string keyId)
        {
            string fResult = string.Empty;
            var foundkey = await _unitOfWork.AppVars.FindFirstAsync(v => v.Name == keyId);

            if (foundkey != null)
            {
                Int32.TryParse(foundkey.Value, out var result);

                string originalFolio = result.ToString().PadLeft(6, '0');
                var foundWorkOrderWithLastFolio = await _unitOfWork.WorkOrders.FindFirstAsync(w => w.OrderNumber.EndsWith(originalFolio));

                if (foundWorkOrderWithLastFolio == null)
                {
                    // that folio has not been used !!
                    if (!string.IsNullOrEmpty(foundkey.UsePrefix))
                        return $"{foundkey.UsePrefix}{originalFolio}";
                    else
                        return originalFolio;
                }

                result += 1;
                string newFolio = result.ToString().PadLeft(6, '0');

                // We update the order number 
                foundkey.Value = result.ToString();
                _unitOfWork.AppVars.Update(foundkey);
                await _unitOfWork.CompleteAsync();

                fResult = string.IsNullOrEmpty(foundkey.UsePrefix) ? newFolio : $"{foundkey.UsePrefix}{newFolio}";
            }
            else
            {
                // if not found it is new
                await _unitOfWork.AppVars.AddAsync(new AppVar { Id = new Guid(), ConvertsTo = "string", Name = keyId, UsePrefix = "WOT-", Value = "1" });
                await _unitOfWork.CompleteAsync();

                fResult = "WOT-000001";

            }

            return fResult;
        }
    }
}
