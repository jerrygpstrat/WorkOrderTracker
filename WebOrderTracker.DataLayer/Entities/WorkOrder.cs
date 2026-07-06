using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebOrderTracker.Common.Enums;

namespace WebOrderTracker.DataLayer.Entities
{
    [Table("WorkOrders")]
    public class WorkOrder
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OrderNumber { get; set; } = string.Empty;

        [StringLength(128)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1024)]
        public string Description { get; set; } = string.Empty;

        public WorkOrderStatus Status { get; set; } = WorkOrderStatus.New;
        public WorkOrderPriority Priority { get; set; } = WorkOrderPriority.Medium;

        public bool IsWorkPaid { get; set; }


        // Dates
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime TargetCompletionDate { get; set; }

        public DateTime PaidDate { get; set; }


        // Relationships
        //public Guid AssetId { get; set; }
        //public Asset Asset { get; set; } = null!;

        //public Guid? AssignedTechnicianId { get; set; }
        //public Technician? AssignedTechnician { get; set; }

        // Child Collections
        public ICollection<WorkOrderTask> Tasks { get; set; } = new List<WorkOrderTask>();
        public ICollection<WorkOrderPart> PartsUsed { get; set; } = new List<WorkOrderPart>();
        public ICollection<LaborLog> LaborLogs { get; set; } = new List<LaborLog>();

        // Domain Logic
        public void CompleteWorkOrder()
        {
            Status = WorkOrderStatus.Completed;
            CompletedAt = DateTime.UtcNow;

            foreach (var task in Tasks)
            {
                task.IsCompleted = true;
            }
        }
    }
}
