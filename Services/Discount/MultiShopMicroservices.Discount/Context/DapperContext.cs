using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShopMicroservices.Discount.Entities;
using System.Data;

namespace MultiShopMicroservices.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;initial catalog = MultiShopDiscountDb;User Id=sa; Password=sa1234SA; MultipleActiveResultSets=true; Trust Server Certificate=true;");
        }

        DbSet<Coupon> Coupons { get; set; }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
