namespace code_first_app.Models
{
    public class User //Relation 1:1
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public virtual UserProfile? Profile { get; set; }
    }
}
