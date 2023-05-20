using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Enums;
using Shared.Helpers;
using Shared.Models;
using Shared.Models.Items;
using Shared.Models.Users;

namespace Data.Entities
{
    public class EdInvestContext : DbContext
    {
        public EdInvestContext(DbContextOptions<EdInvestContext> options) : base(options) { }
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Subcategory> Subcategories => Set<Subcategory>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<Investments> Investments => Set<Investments>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationHelper.GetConfiguration().GetConnectionString("ContextSettings"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasPostgresEnum<ItemType>();



            modelBuilder.Entity<User>()
                .HasDiscriminator(u => u.Type)
                .HasValue<Organisation>(UserType.Organisation)
                .HasValue<Investor>(UserType.Investor)
                .HasValue<Student>(UserType.Student);

            modelBuilder.Entity<Item>()
                .HasDiscriminator(i => i.Type)
                .HasValue<Course>(ItemType.Course)
                .HasValue<Application>(ItemType.Application)
                .HasValue<OnlineCourse>(ItemType.OnlineCourse)
                .HasValue<Event>(ItemType.Event);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Subcategories)
                .WithOne(s => s.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Organisation>()
                .HasMany(u => u.Items)
                .WithOne(c => c.Organisation)
                .HasForeignKey(c => c.OrganisationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Item>()
                .HasOne(c => c.Organisation)
                .WithMany(co => co.Items)
                .HasForeignKey(co => co.OrganisationId);
            modelBuilder.Entity<Investor>()
                .HasMany(u => u.Investments)
                .WithOne(i => i.Investor)
                .HasForeignKey(i => i.InvestorId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Investor>()
                .HasMany(i => i.Students)
                .WithOne(s => s.Funder)
                .HasForeignKey(i => i.FunderId);
            modelBuilder.Entity<Item>()
                .HasMany(c => c.Investments)
                .WithOne(i => i.Item)
                .HasForeignKey(i => i.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Item>()
                .HasOne(c => c.Category)
                .WithMany(co => co.Items)
                .HasForeignKey(c => c.CategoryId);
            modelBuilder.Entity<Item>()
                .HasOne(c => c.Subcategory)
                .WithMany(co => co.Items)
                .HasForeignKey(c => c.SubcategoryId);
            modelBuilder.Entity<Investments>()
                   .HasKey(i => new { i.InvestorId, i.ItemId });
            modelBuilder.Entity<User>()
                .Property(u => u.Claims);
            modelBuilder.Entity<Subcategory>()
                .Property(s => s.CategoryId);
            Seeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);



        }


    }
}
