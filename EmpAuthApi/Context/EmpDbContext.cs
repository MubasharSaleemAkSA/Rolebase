using EmpAuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpAuthApi.Context
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options) {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }
       
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Role>().ToTable("Role");

            modelBuilder.Entity<User>()
                .HasOne(r => r.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(ar => ar.FRid).IsRequired();
            modelBuilder.Entity<Role>()
                .HasMany(u => u.Users)
                .WithOne(r => r.Role)
                .OnDelete(DeleteBehavior.Cascade);
              
            modelBuilder.Entity<Activityrole>()
                .HasOne(ar => ar.Role)
                .WithMany(ar => ar.activityrole)
                .HasForeignKey(ar => ar.roleid);
            modelBuilder.Entity<Activityrole>()
                .HasOne(ac => ac.Activities)
                .WithMany(r => r.activityrole)
                .HasForeignKey(ar => ar.activityid);



        }

        internal Task FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public DbSet<EmpAuthApi.Models.Activityrole> Activityrole { get; set; }
    }
}
