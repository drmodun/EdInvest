using Microsoft.EntityFrameworkCore;
using Data.Entities.Models;
namespace Data.Entities
{
    public class EdInvestContext : DbContext 
    {
        public EdInvestContext(DbContextOptions<EdInvestContext> options) : base(options){}
        public DbSet<Models.Country> Countries => Set<Country>();
        public DbSet<Models.Category> Categories => Set<Category>();
        public DbSet<Models.Subcategory> Subcategories => Set<Subcategory>();
        public DbSet<Models.User> Users => Set<User>();
        public DbSet<Models.Course> Courses => Set<Course>();
        public DbSet<Models.Investments> Investments => Set<Investments>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=EdInvestment;Username=postgres;Password=postgres;IncludeErrorDetail=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            modelBuilder.Entity<User>()
                .HasMany(u => u.Courses)
                .WithOne(u => u.Donee)
                .HasForeignKey(c => c.DoneeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Investments)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Investments)
                .WithOne(i => i.Course)
                .HasForeignKey(i => i.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Category)
                .WithMany(co => co.Courses)
                .HasForeignKey(c => c.CategoryId);
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Subcategory)
                .WithMany(co => co.Courses)
                .HasForeignKey(c => c.SubcategoryId);
            modelBuilder.Entity<Investments>()
                   .HasKey(i => new { i.UserId, i.CourseId });
            base.OnModelCreating(modelBuilder);

        }


    }
}
