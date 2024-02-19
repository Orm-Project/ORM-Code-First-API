namespace ORM_Code_First_API.Models
{
    public class Employee : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
