using System.ComponentModel.DataAnnotations;
using WebOrderTracker.Common.Enums;

namespace WebOrderTracker.Business.Dtos.Requests
{
    /// <summary>
    /// New work order view model
    /// </summary>
    public class NewWorkOrderViewModel
    {

        [Required(ErrorMessage = "Please enter the Order number for the work order.")]
        [StringLength(16, ErrorMessage = "Order number cannot exced 16 characters.")]
        public string? OrderNumber { get; set; }

        [Required(ErrorMessage = "Please enter a title for the work order.")]
        [StringLength(100, ErrorMessage = "The title cannot exceed 100 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter a title for the work order.")]
        [StringLength(100, ErrorMessage = "The title cannot exceed 100 characters.")]
        public string Description { get; set; } = string.Empty;
        public WorkOrderStatus Status { get; set; } = WorkOrderStatus.New;
        public WorkOrderPriority Priority { get; set; } = WorkOrderPriority.Medium;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime TargetCompletionDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ExpectedPayDate { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "The amount must be greater than zero.")]
        [Required(ErrorMessage = "Please enter the amount to pay by customer for the work order.")]
        public decimal AmountToPay { get; set; }
    }
}
