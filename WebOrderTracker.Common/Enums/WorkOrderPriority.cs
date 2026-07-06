using System.ComponentModel.DataAnnotations;

namespace WebOrderTracker.Common.Enums
{
    public enum WorkOrderPriority
    {
        [Display(Name="Critical")]
        Critical = 100,
        [Display(Name = "High")]
        High = 200,
        [Display(Name = "Medium")]
        Medium = 800,
        [Display(Name = "Low")]
        Low = 900
    }
}