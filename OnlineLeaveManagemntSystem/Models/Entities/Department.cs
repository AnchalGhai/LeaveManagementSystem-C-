using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLeaveManagemntSystem.Models.Entities
{
    [Table("department")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Navigation property
        public ICollection<User> Users { get; set; }
    }
}
