using System;

namespace code_first_app.Models
{
    public class Category //Relation 1:*
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual IEnumerable<Product>? Products { get; set; }

    }
}
