using Microsoft.EntityFrameworkCore;
using MVCExercise.Domain.Entities;

namespace MVCExercise.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Email> Email { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        #endregion
    }
}
