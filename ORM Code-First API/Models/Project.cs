namespace ORM_Code_First_API.Models
{
    public class Project : ModelBase
    {
        public string Name { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = new();
    }
}
