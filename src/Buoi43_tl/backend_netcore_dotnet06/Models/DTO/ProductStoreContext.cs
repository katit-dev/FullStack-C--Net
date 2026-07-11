// ef-dbcontext
using Microsoft.EntityFrameworkCore;

namespace Models.Models {
    public class ProductStoreContext : DbContext {
        private readonly IConfiguration _configuration;
        public ProductStoreContext() { }
        public ProductStoreContext(DbContextOptions<ProductStoreContext> options, IConfiguration configuration) : base(options) {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // lay connection string tu appsettings.json
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ProductStoreConnection"));
        }


        // khai bao bang dang class tren tang code
        public DbSet<Product> Products { get; set; }

    }
}