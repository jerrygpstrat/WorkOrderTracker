namespace WebOrderTracker.DataLayer.Entities.enums
{
    public enum WorkOrderStatus
    {
        New = 100,
        InProgress= 200,
        Completed = 300,
        OnHold = -100,
        Cancelled = -200
    }
}
