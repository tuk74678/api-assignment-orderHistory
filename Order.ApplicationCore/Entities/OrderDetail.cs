namespace Order.ApplicationCore.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    public int Order_Id { get; set; }
    public int ProductId { get; set; }
    public string Product_Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    // Navigation property
    public Orders Order { get; set; }
}