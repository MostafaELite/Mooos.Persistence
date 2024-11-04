namespace Moos.Persistence.Test.TestEntities;

public class Order
{
    public Order()
    {
        
    }
    public Order(int orderId, DateTime orderDate, IEnumerable<OrderItem>? items)
    {
        OrderId = orderId;
        OrderDate = orderDate;
        Items = items;
    }

    public int OrderId { get; private set; }
    public DateTime OrderDate { get; private set; }

    public IEnumerable<OrderItem>? Items { get; private set; }
}