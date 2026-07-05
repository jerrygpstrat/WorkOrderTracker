using System.ComponentModel.DataAnnotations;
using WebOrderTracker.DataLayer.Entities.enums;

namespace WebOrderTracker.Business.Dtos.Requests
{
    /// <summary>
    /// New work order view model
    /// </summary>
    public class NewWorkOrderViewModel
    {
        [Required(ErrorMessage = "Please enter a title for the work order.")]
        [StringLength(100, ErrorMessage = "The title cannot exceed 100 characters.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Please enter a title for the work order.")]
        [StringLength(100, ErrorMessage = "The title cannot exceed 100 characters.")]
        public string Description { get; set; } = string.Empty;
        public WorkOrderStatus Status { get; set; } = WorkOrderStatus.New;
        public WorkOrderPriority Priority { get; set; } = WorkOrderPriority.Medium;
        public DateTime TargetCompletionDate { get; set; }
        public DateTime ExpectedPayDate { get; set; }
    }
}
