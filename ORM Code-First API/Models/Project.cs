namespace ORM_Code_First_API.Models
{
    public class Project : ModelBase
    {
        public string ProjectName { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
