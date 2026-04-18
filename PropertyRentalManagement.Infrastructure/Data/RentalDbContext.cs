using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyRentalManagement.Core.Entities;

namespace PropertyRentalManagement.Infrastructure.Data
{
    public class RentalDbContext : IdentityDbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties => Set<Property>();
        public DbSet<Unit> Units => Set<Unit>();
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Landlord> Landlords => Set<Landlord>();
        public DbSet<Lease> Leases => Set<Lease>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<MaintenanceRequest> MaintenanceRequests => Set<MaintenanceRequest>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Property>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.PropertyName)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(p => p.AddressLine1)
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(p => p.AddressLine2)
                    .HasMaxLength(200);

                entity.Property(p => p.City)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(p => p.State)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(p => p.ZipCode)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(p => p.TotalUnits)
                    .IsRequired();

                entity.HasMany(p => p.Units)
                    .WithOne(u => u.Property)
                    .HasForeignKey(u => u.PropertyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Unit>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.UnitNumber)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(u => u.MonthlyRent)
                    .HasColumnType("decimal(18,2)");

                entity.Property(u => u.Bedrooms)
                    .IsRequired();

                entity.Property(u => u.Bathrooms)
                    .IsRequired();

                entity.Property(u => u.IsOccupied)
                    .IsRequired();

             
            });

            builder.Entity<Tenant>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.FirstName)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(t => t.LastName)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(t => t.Email)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(t => t.PhoneNumber)
                    .HasMaxLength(30)
                    .IsRequired();

                entity.HasMany(t => t.Leases)
                    .WithOne(l => l.Tenant)
                    .HasForeignKey(l => l.TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(t => t.MaintenanceRequests)
                    .WithOne(m => m.Tenant)
                    .HasForeignKey(m => m.TenantId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
         
            builder.Entity<Landlord>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.Property(l => l.FullName)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(l => l.Email)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(l => l.PhoneNumber)
                    .HasMaxLength(30)
                    .IsRequired();

                entity.HasMany(l => l.Properties)
                    .WithOne(p => p.Landlord)
                    .HasForeignKey(p => p.LandlordId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Property>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.PropertyName)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(p => p.AddressLine1)
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(p => p.AddressLine2)
                    .HasMaxLength(200);

                entity.Property(p => p.City)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(p => p.State)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(p => p.ZipCode)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.HasMany(p => p.Units)
                    .WithOne(u => u.Property)
                    .HasForeignKey(u => u.PropertyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
                     

            builder.Entity<Lease>(entity =>
            {
                entity.HasKey(l => l.Id);

                entity.Property(l => l.MonthlyRent)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(l => l.SecurityDeposit)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(l => l.LeaseStartDate)
                    .IsRequired();

                entity.Property(l => l.LeaseEndDate)
                    .IsRequired();

                entity.HasOne(l => l.Tenant)
                    .WithMany(t => t.Leases)
                    .HasForeignKey(l => l.TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.Property)
                    .WithMany(p => p.Leases)
                    .HasForeignKey(l => l.PropertyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(l => l.Payments)
                    .WithOne(p => p.Lease)
                    .HasForeignKey(p => p.LeaseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

        
            builder.Entity<Payment>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.PaymentDate)
                    .IsRequired();

                entity.Property(p => p.AmountPaid)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(p => p.PaymentMethod)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(p => p.Status)
                    .HasMaxLength(50)
                    .IsRequired();
            });

            builder.Entity<MaintenanceRequest>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.Property(m => m.Title)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(m => m.Description)
                    .HasMaxLength(1000)
                    .IsRequired();

                entity.Property(m => m.RequestDate)
                    .IsRequired();

                entity.Property(m => m.Status)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(m => m.Priority)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.HasOne(m => m.Unit)
                    .WithMany()
                    .HasForeignKey(m => m.UnitId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}