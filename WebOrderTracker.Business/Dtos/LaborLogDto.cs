using WebOrderTracker.DataLayer.Entities;

namespace WebOrderTracker.Business.Dtos
{
    /// <summary>
    /// Response labor log
    /// </summary>
    public class LaborLogDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid WorkOrderId { get; set; }
        public Guid TechnicianId { get; set; }
        public Technician Technician { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double HoursWorked => (EndTime - StartTime).TotalHours;
        public string Notes { get; set; } = string.Empty;
    }
}