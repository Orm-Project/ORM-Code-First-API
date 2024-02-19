using System.ComponentModel.DataAnnotations;
namespace ORM_Code_First_API.Models
{
    public abstract class ModelBase
    {
        [Key]
        public int Id { get; set; }
    }
}
