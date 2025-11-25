using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLeaveManagemntSystem.Models.Entities
{
    [Table("notification")]
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;
    }
}
