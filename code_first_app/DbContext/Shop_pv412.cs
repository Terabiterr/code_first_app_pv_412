using code_first_app.Models;
using Microsoft.EntityFrameworkCore;

namespace code_first_app
{
    public class Shop_pv412 : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DOMBROVSKY;Database=PV_412;Integrated Security=True; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relation 1:1
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);
            //Relation 1:*
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            //Relation *:*
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);
            //Створити міграцію бази даних
            //Провести аналіз таблиць в MSSQL та зробити діаграму
            //бази даних
            //Скинути фото в тімс
            //Enable-Migrations
            //Add-Migration InitDatabase
            //Update-Database
        }
    }
}
