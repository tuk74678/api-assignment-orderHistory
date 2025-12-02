namespace Order.ApplicationCore.Models;

public class UpdateOrderModel
{
    public int Id { get; set; }
    public DateTime Order_Date { get; set; }
    public string CustomerName { get; set; }
    public string ShippingAddress { get; set; }
    public List<OrderDetailsModel> OrderDetails { get; set; }
}