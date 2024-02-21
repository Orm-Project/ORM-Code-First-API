using System.ComponentModel.DataAnnotations.Schema;

namespace ORM_Code_First_API.Models
{
    public class Manager : ModelBase
    {
        public string ManagerName { get; set; }
        public string ManagerDescription { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
