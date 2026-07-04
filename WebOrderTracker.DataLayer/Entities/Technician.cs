using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOrderTracker.DataLayer.Entities
{

    [Table("Technicians")]
    public class Technician
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public ICollection<WorkOrder> AssignedWorkOrders { get; set; } = new List<WorkOrder>();
    }
}
