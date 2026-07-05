using System.ComponentModel.DataAnnotations;

namespace WebOrderTracker.Business
{
    /// <summary>
    /// Work order task DTO response
    /// </summary>
    public class WorkOrderTaskDto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid WorkOrderId { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public int SequenceOrder { get; set; }
    }
}