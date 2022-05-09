using BackRowCommerceApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackRowCommerceApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<NotificationSettings> NotificationSettings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}