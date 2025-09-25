namespace code_first_app.Models
{
    public class OrderProduct //Intermediate table *:*
    {
        //Foreign key
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }
        //Foreign key
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
