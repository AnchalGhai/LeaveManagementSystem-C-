using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLeaveManagemntSystem.Models.Entities
{
    [Table("leaveapplication")]
    public class LeaveApplication
    {
        [Key]
        public int LeaveId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int TotalDays => (EndDate - StartDate).Days + 1;

        [Required]
        public string Reason { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } // Pending / Approved / Rejected

        public string ManagerComments { get; set; }

        public DateTime AppliedOn { get; set; } = DateTime.Now;
        public DateTime? ActionDate { get; set; }
    }
}
