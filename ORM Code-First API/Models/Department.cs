namespace ORM_Code_First_API.Models
{
    public class Department : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; } = new();
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
