using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOrderTracker.DataLayer.Entities
{
    [Table("LaborLogs")]
    public class LaborLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid WorkOrderId { get; set; }
        public Guid TechnicianId { get; set; }
        public Technician Technician { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double HoursWorked => (EndTime - StartTime).TotalHours;

        [StringLength(512)]
        public string Notes { get; set; } = string.Empty;
    }
}
