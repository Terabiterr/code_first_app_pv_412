namespace code_first_app.Models
{
    public class UserProfile //Relation 1:1
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        //Зворотній зв'язок
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
