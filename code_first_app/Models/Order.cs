namespace code_first_app.Models
{
    public class Order //Relation *:*
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual IEnumerable<OrderProduct>? OrderProducts { get; set; }

    }
}
