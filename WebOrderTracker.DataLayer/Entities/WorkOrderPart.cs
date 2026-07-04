using System.ComponentModel.DataAnnotations.Schema;

namespace WebOrderTracker.DataLayer.Entities
{
    [Table("WorkOrderParts")]
    public class WorkOrderPart
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
