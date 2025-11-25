using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLeaveManagemntSystem.Models.Entities
{
    [Table("leavebalance")]
    public class LeaveBalance
    {
        [Key]
        public int BalanceId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

        [Required]
        public int TotalAssigned { get; set; }

        [Required]
        public int Used { get; set; }

        [NotMapped]
        public int Remaining => TotalAssigned - Used;
    }
}
