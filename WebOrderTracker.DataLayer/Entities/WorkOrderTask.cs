using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOrderTracker.DataLayer.Entities
{
    [Table("WorkOrderTasks")]
    public class WorkOrderTask
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid WorkOrderId { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public int SequenceOrder { get; set; }
    }
}
