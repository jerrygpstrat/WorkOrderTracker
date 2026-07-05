using System.ComponentModel.DataAnnotations.Schema;
using WebOrderTracker.DataLayer.Entities;

namespace WebOrderTracker.Business
{
    public class WorkOrderPartDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid WorkOrderId { get; set; }
        public Guid PartId { get; set; }
        public Part Part { get; set; } = null!;
        public int QuantityUsed { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceAtTimeOfUse { get; set; } // Historical price lock

        public WorkOrder WorkOrder { get; set; } = null!;
    }
}