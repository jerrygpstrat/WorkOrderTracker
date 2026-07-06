using WebOrderTracker.DataLayer.Entities;
using WebOrderTracker.DataLayer.Entities.enums;

namespace WebOrderTracker.Business.Dtos
{

    /// <summary>
    /// Work orders Dto or response
    /// </summary>
    public class WorkOrderDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OrderNumber { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public WorkOrderStatus Status { get; set; } = WorkOrderStatus.New;
        public WorkOrderPriority Priority { get; set; } = WorkOrderPriority.Medium;

        public bool IsWorkPaid { get; set; }

        // Dates
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime TargetCompletionDate { get; set; }

        public DateTime PaydDate { get; set; }
        public DateTime ExpectedPayDate { get; set; }

        // Relationships
        public Guid AssetId { get; set; }
        public Asset Asset { get; set; } = null!;

        public Guid? AssignedTechnicianId { get; set; }
        public TechnicianDto? AssignedTechnician { get; set; }

        // Child Collections
        public ICollection<WorkOrderTaskDto> Tasks { get; set; } = new List<WorkOrderTaskDto>();
        public ICollection<WorkOrderPartDto> PartsUsed { get; set; } = new List<WorkOrderPartDto>();
        public ICollection<LaborLogDto> LaborLogs { get; set; } = new List<LaborLogDto>();
    }
}