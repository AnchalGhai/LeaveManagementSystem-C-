using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLeaveManagemntSystem.Models.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } // Employee / Manager / Admin

        // Department foreign key
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // Manager foreign key (nullable)
        public int? ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public User Manager { get; set; }

        // Navigation properties
        public ICollection<User> EmployeesUnderManager { get; set; }
        public ICollection<LeaveBalance> LeaveBalances { get; set; }
        public ICollection<LeaveApplication> LeaveApplications { get; set; }
        public ICollection<Notification> Notifications { get; set; }

        public DateTime DateOfJoining { get; set; }
    }
}
