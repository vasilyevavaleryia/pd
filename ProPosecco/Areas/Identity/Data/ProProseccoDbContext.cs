using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProPosecco.Areas.Identity.Data.Entities;

namespace ProPosecco.Areas.Identity.Data
{
    public class ProProseccoDbContext : IdentityDbContext<User>
    {
        public DbSet<UserDetails> UsersDetails { get; set; }

        public DbSet<Wine> Wines { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ProProseccoDbContext(DbContextOptions<ProProseccoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ApplyUserConfigurations();
            ApplyWineConfigurations();
            ApplyOrderConfigurations();

            void ApplyUserConfigurations()
            {
                builder.Entity<User>()
                    .HasOne(u => u.UserDetails)
                    .WithOne(ud => ud.User)
                    .HasForeignKey<UserDetails>(ud => ud.UserId);
            }

            void ApplyWineConfigurations()
            {
                builder.Entity<Wine>()
                    .Property(w => w.Price)
                    .HasColumnType("decimal")
                    .HasPrecision(18, 2);
            }

            void ApplyOrderConfigurations()
            {
                builder.Entity<Order>()
                    .Property(o => o.Total)
                    .HasColumnType("decimal")
                    .HasPrecision(18, 2);

                builder.Entity<Order>()
                    .Property(o => o.IsPaid)
                    .HasDefaultValue(false);

                builder.Entity<Order>()
                    .HasOne(o => o.Cart)
                    .WithOne(c => c.Order)
                    .HasForeignKey<Cart>(o => o.OrderId);
            }
        }
    }
}
