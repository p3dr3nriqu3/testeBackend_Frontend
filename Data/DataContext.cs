using Microsoft.EntityFrameworkCore;
using TesteCrud.Models;

namespace TesteCrud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
    {
    }

    public DbSet<Pessoa> Pessoas { get; set; }

    }
}