using HW_L5_02_EfCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace HW_L5_02_EfCore.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}