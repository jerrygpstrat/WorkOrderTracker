using Mapster;
using WebOrderTracker.Business.Dtos;
using WebOrderTracker.DataLayer.Entities;

namespace WebOrderTracker.Business.Mappings
{
    public class MappingRegister : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Configure mapping from DAL Entity to BLL DTO
            config.NewConfig<WorkOrder, WorkOrderDto>()
                .TwoWays(); 
        }
    }
}
