namespace Moos.Persistence.Test.TestEntities;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public required string ProductName { get; set; }
    public int Quantity { get; set; }

    public int OrderId { get; set; }
    
    public required Order Order { get; set; }
}