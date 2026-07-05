using WebOrderTracker.Business.Dtos;

namespace WebOrderTracker.Business
{
    /// <summary>
    /// Technitial DTO response
    /// </summary>
    public class TechnicianDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<WorkOrderDto> AssignedWorkOrders { get; set; } = new List<WorkOrderDto>();
    }
}