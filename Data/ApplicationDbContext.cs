using CrudOperationCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }

        public DbSet<CrudOperation> CrudOperations { get; set; }
    }
}
