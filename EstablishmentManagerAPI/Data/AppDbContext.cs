using Models.ClientRelated;
using Models.InventoryRelated;
using Models.MoneyRelated;
using Models.OrdersRelated;
using Models.UserRelated;
using Microsoft.EntityFrameworkCore;

namespace EstablishmentManagerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Client_address> Client_Addresses { get; set; }
        public DbSet<Client_telephone> Client_Telephones { get; set; }
        public DbSet<Group_of_product> Group_of_products { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_addon> Product_addons { get; set; }
        public DbSet<Product_observation> Product_observations { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Delivery> Deliverys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlServer(connectionString:
                "Server=DESKTOP-IC0LVQA\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal");
            }

        }

    }
}
