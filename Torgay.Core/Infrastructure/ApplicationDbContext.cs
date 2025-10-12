// ======================================
// Author: Ebenezer Monney
// Copyright (c) 2023 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Torgay.Core.Models;
using Torgay.Core.Models.Access;
using Torgay.Core.Models.Account;
using Torgay.Core.Models.Payments;
using Torgay.Core.Services.Account;

namespace Torgay.Core.Infrastructure
{
    public class ApplicationDbContext(DbContextOptions options, IUserIdAccessor userIdAccessor) :
        IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
    {
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<UserToClient> UserToClients { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Currency> Currensies { get; set; }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }

        public DbSet<OrganizationAccount> OrganizationAccounts { get; set; }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<ContractType> ContractTypes { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<MovementType> MovementTypes { get; set; }

        public DbSet<BCC> BCCs { get; set; }

        public DbSet<PPC> PPCs { get; set; }

        public DbSet<BankStatement> BankStatements { get; set; }

        public DbSet<BankTransaction> BankTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string priceDecimalType = "decimal(18,2)";
            const string tablePrefix = "App";

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Claims)
                .WithOne()
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Roles)
                .WithOne()
                .HasForeignKey(r => r.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>()
                .HasMany(r => r.Claims)
                .WithOne()
                .HasForeignKey(c => c.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationRole>()
                .HasMany(r => r.Users)
                .WithOne()
                .HasForeignKey(r => r.RoleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BaseEntity>().Property(e => e.Id).HasColumnName("Id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").ValueGeneratedOnAdd();

            builder.Entity<PPC>().Property(e => e.Id).HasColumnName("Id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").ValueGeneratedOnAdd();

            builder.Entity<BCC>().Property(e => e.Id).HasColumnName("Id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").ValueGeneratedOnAdd();

            builder.Entity<Country>().Property(e => e.Id).HasColumnName("Id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").ValueGeneratedOnAdd();

            builder.Entity<Currency>().Property(e => e.Id).HasColumnName("Id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").ValueGeneratedOnAdd();

            builder.Entity<CurrencyRate>().Property(e => e.Id).HasColumnName("Id").HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()").ValueGeneratedOnAdd();

            //builder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            //builder.Entity<Customer>().HasIndex(c => c.Name);
            //builder.Entity<Customer>().Property(c => c.Email).HasMaxLength(100);
            //builder.Entity<Customer>().Property(c => c.PhoneNumber).IsUnicode(false).HasMaxLength(30);
            //builder.Entity<Customer>().Property(c => c.City).HasMaxLength(50);
            //builder.Entity<Customer>().ToTable($"{tablePrefix}{nameof(Customers)}");

            //builder.Entity<ProductCategory>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            //builder.Entity<ProductCategory>().Property(p => p.Description).HasMaxLength(500);
            //builder.Entity<ProductCategory>().ToTable($"{tablePrefix}{nameof(ProductCategories)}");

            //builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            //builder.Entity<Product>().HasIndex(p => p.Name);
            //builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500);
            //builder.Entity<Product>().Property(p => p.Icon).IsUnicode(false).HasMaxLength(256);
            //builder.Entity<Product>().HasOne(p => p.Parent).WithMany(p => p.Children).OnDelete(DeleteBehavior.Restrict);
            //builder.Entity<Product>().Property(p => p.BuyingPrice).HasColumnType(priceDecimalType);
            //builder.Entity<Product>().Property(p => p.SellingPrice).HasColumnType(priceDecimalType);
            //builder.Entity<Product>().ToTable($"{tablePrefix}{nameof(Products)}");

            //builder.Entity<Order>().Property(o => o.Comments).HasMaxLength(500);
            //builder.Entity<Order>().Property(p => p.Discount).HasColumnType(priceDecimalType);
            //builder.Entity<Order>().ToTable($"{tablePrefix}{nameof(Orders)}");

            //builder.Entity<OrderDetail>().Property(p => p.UnitPrice).HasColumnType(priceDecimalType);
            //builder.Entity<OrderDetail>().Property(p => p.Discount).HasColumnType(priceDecimalType);
            //builder.Entity<OrderDetail>().ToTable($"{tablePrefix}{nameof(OrderDetails)}");
        }

        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddAuditInfo();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            AddAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddAuditInfo()
        {
            var currentUserId = userIdAccessor.GetCurrentUserId();

            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity &&
                           (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = currentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = currentUserId;
            }
        }
    }
}
