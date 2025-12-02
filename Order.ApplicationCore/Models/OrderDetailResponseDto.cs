namespace Order.ApplicationCore.Models;

public class OrderDetailResponseDto
{
    public string Product_Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}