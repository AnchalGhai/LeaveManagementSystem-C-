using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLeaveManagemntSystem.Models.Entities
{
    [Table("leavetype")]
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int MaxPerYear { get; set; }

        // Navigation property
        public ICollection<LeaveBalance> LeaveBalances { get; set; }
        public ICollection<LeaveApplication> LeaveApplications { get; set; }
    }
}
