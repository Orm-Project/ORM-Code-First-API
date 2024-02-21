namespace ORM_Code_First_API.Models
{
    public class Department : ModelBase
    {
        public string DepartmentName { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
