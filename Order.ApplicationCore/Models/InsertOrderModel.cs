namespace Order.ApplicationCore.Models;

public class InsertOrderModel
{
    public DateTime Order_Date { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string ShippingAddress { get; set; }
    public List<OrderDetailsModel> OrderDetails { get; set; }
}