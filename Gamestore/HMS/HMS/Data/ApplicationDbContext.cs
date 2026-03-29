using HMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }
    public DbSet<SystemCode> SystemCodes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>()
            .HasOne(a=>a.Gender)
            .WithMany()
            .HasForeignKey(a=>a.GenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ApplicationUser>()
            .HasOne(a=>a.MaritalStatus)
            .WithMany()
            .HasForeignKey(a=>a.MaritalStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ApplicationUser>()
            .HasOne(a=>a.BloodGroup)
            .WithMany()
            .HasForeignKey(a=>a.BloodGroupId)
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.Entity<SystemCode>()
            .HasOne(sc=>sc.ModifiedBy)
            .WithMany()
            .HasForeignKey(sc=>sc.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<SystemCodeDetail>()
            .HasOne(scd=>scd.ModifiedBy)
            .WithMany()
            .HasForeignKey(scd=>scd.ModifiedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<SystemCodeDetail>()
            .HasOne(scd=>scd.SystemCode)
            .WithMany()
            .HasForeignKey(scd=>scd.SystemCodeId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
