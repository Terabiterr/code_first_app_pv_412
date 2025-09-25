using System;

namespace code_first_app.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        //Foreign key
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        //Intermediate for *:*
        public virtual IEnumerable<OrderProduct>? OrderProducts { get; set; }
    }
}
