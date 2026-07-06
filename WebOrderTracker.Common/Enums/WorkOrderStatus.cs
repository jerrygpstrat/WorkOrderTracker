using System.ComponentModel.DataAnnotations;

namespace WebOrderTracker.Common.Enums
{
    public enum WorkOrderStatus
    {
        [Display(Name = "New Order")]
        New = 100,
        [Display(Name = "In Progress")]
        InProgress = 200,
        [Display(Name = "Completed")]
        Completed = 300,
        [Display(Name = "On Hold")]
        OnHold = -100,
        [Display(Name = "Cancelled")]
        Cancelled = -200
    }
}
