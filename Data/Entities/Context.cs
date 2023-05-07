using Microsoft.EntityFrameworkCore;
using Data.Entities.Models;
using Data.Enums;

namespace Data.Entities
{
    public class EdInvestContext : DbContext 
    {
        public EdInvestContext(DbContextOptions<EdInvestContext> options) : base(options){}
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Subcategory> Subcategories => Set<Subcategory>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Item> Courses => Set<Item>();
        public DbSet<Investments> Investments => Set<Investments>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=EdInvestment;Username=postgres;Password=postgres;IncludeErrorDetail=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasPostgresEnum<ItemType>();



            modelBuilder.Entity<User>()
                .HasDiscriminator(u=>u.Type)
                .HasValue<Organisation>(UserType.Organisation)
                .HasValue<Investor>(UserType.Investor)
                .HasValue<Student>(UserType.Student);

            modelBuilder.Entity<Item>()
                .HasDiscriminator(i => i.Type)
                .HasValue<Course>(ItemType.Course)
                .HasValue<Application>(ItemType.Application)
                .HasValue<OnlineCourse>(ItemType.OnlineCourse)
                .HasValue<Event>(ItemType.Event);

                

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Users)
                .WithOne(u => u.Country)
                .HasForeignKey(u => u.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Subcategories)
                .WithOne(s => s.Category)
                .HasForeignKey(c => c.CatgoryId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Organisation>()
                .HasMany(u => u.Courses)
                .WithOne(u => u.Organisation)
                .HasForeignKey(c => c.OrganisationId)
                .OnDelete(DeleteBehavior.Cascade);
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
                .WithOne(i => i.Course)
                .HasForeignKey(i => i.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Item>()
                .HasOne(c => c.Category)
                .WithMany(co => co.Courses)
                .HasForeignKey(c => c.CategoryId);
            modelBuilder.Entity<Item>()
                .HasOne(c => c.Subcategory)
                .WithMany(co => co.Courses)
                .HasForeignKey(c => c.SubcategoryId);
            modelBuilder.Entity<Investments>()
                   .HasKey(i => new { i.InvestorId, i.CourseId });
            base.OnModelCreating(modelBuilder);



        }


    }
}
