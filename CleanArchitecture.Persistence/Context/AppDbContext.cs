using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>(entity =>
            {
                entity.Property(u => u.RoleName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.Description)
                      .IsRequired()
                      .HasMaxLength(100);
            });

            builder.Entity<User>(entity =>
            {
                entity.Property(u => u.FullName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(u => u.EmailAddress)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(u => u.PasswordHash)
                      .IsRequired()
                      .HasMaxLength(256);

                entity.Property(u => u.MobileNumber)
                      .IsRequired()
                      .HasMaxLength(15);

                entity.Property(u => u.DateOfBirth)
                      .HasColumnType("date")
                      .IsRequired();

                entity.Property(u => u.ProfilePicture)
                      .HasMaxLength(50);

                entity.HasOne(u => u.Role)
                      .WithMany()
                      .HasForeignKey(u => u.RoleId);
            });
        }
    }
}