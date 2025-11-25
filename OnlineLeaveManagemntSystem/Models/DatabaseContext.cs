using Microsoft.EntityFrameworkCore;
using OnlineLeaveManagemntSystem.Models.Entities;

namespace OnlineLeaveManagemntSystem.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----------------------------
            // Seed Departments
            // ----------------------------
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "HR" },
                new Department { DepartmentId = 2, Name = "IT" }
            );

            // ----------------------------
            // Seed Admin
            // ----------------------------
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    FullName = "Admin User",
                    Email = "admin@example.com",
                    PasswordHash = "Admin@123", // replace with real hash
                    Role = "Admin",
                    DepartmentId = 1,
                    DateOfJoining = DateTime.Now
                },

                // ----------------------------
                // Seed Manager
                // ----------------------------
                new User
                {
                    UserId = 2,
                    FullName = "John Manager",
                    Email = "manager@example.com",
                    PasswordHash = "Manager@123",
                    Role = "Manager",
                    DepartmentId = 2,
                    DateOfJoining = DateTime.Now
                },

                // ----------------------------
                // Seed Employee
                // ----------------------------
                new User
                {
                    UserId = 3,
                    FullName = "Alice Employee",
                    Email = "employee@gmail.com",
                    PasswordHash = "Employee@123",
                    Role = "Employee",
                    DepartmentId = 2,
                    ManagerId = 2, // Assigned to John Manager
                    DateOfJoining = DateTime.Now
                }
            );
        }
    }
}
