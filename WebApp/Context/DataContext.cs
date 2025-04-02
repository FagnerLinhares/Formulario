using Microsoft.EntityFrameworkCore;
using WebApp.Context.Configs;
using WebApp.Entities;

namespace WebApp.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());   
        }
    }
}
