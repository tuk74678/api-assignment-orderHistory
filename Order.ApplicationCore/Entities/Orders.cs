namespace Order.ApplicationCore.Entities;

public class Orders
{
    public int Id { get; set; }
    public DateTime Order_Date { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int? PaymentMethodId { get; set; }
    public string? PaymentName { get; set; }
    public string ShippingAddress { get; set; }
    public string? ShippingMethod { get; set; }
    public decimal? BillAmount { get; set; }
    public string? Order_Status { get; set; }
    // Navigation property
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

}