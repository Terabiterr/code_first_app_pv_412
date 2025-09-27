namespace code_first_app.Models
{
    public class Employee //self-referencing relationship
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //FK to self
        public int ManagerId { get; set; }
        //Navigation property to Manager
        public Employee? Manager { get; set; }
        //Navigation property to self
        public virtual IEnumerable<Employee>? Subordinates { get; set; }
    }
}
