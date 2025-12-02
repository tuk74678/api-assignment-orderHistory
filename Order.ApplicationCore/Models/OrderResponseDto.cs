namespace Order.ApplicationCore.Models;

public class OrderResponseDto
{
    public int Id { get; set; }
    public DateTime Order_Date { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string ShippingAddress { get; set; }
    public decimal? BillAmount { get; set; }
    public string? Order_Status { get; set; }
    public List<OrderDetailResponseDto> OrderDetails { get; set; }
}