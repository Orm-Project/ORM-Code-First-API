namespace ORM_Code_First_API.Models
{
    public class Department : ModelBase
    {
        public string DepartmentName { get; set; }
        public virtual Manager? Manager { get; set; } 
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
