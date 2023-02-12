using Microsoft.EntityFrameworkCore;
using User.Models;

namespace User.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        { }
        public DbSet<UserData> users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<RoleActivity> RoleActivity { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserData>().ToTable("users");
            modelBuilder.Entity<UserData>()
               .HasOne(r => r.Role)
               .WithMany(r => r.users)
               .HasForeignKey(ar => ar.Fid);
            modelBuilder.Entity<Role>()
                .HasMany(u => u.users)
                .WithOne(r => r.Role)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RoleActivity>()
               .HasOne(ar => ar.Role)
               .WithMany(ar => ar.RoleActivity)
               .HasForeignKey(ar => ar.roleid);
            modelBuilder.Entity<RoleActivity>()
                .HasOne(ac => ac.Activities)
                .WithMany(r => r.RoleActivity)
                .HasForeignKey(ar => ar.activityid);

         
        }

    }
}

