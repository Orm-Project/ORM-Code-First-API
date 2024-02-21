namespace ORM_Code_First_API.Models
{
    public class Team : ModelBase
    {
        public string TeamName { get; set; }
        public virtual Department Department { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
