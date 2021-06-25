using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Week6
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public Context() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
            optBuilder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; 
                                    Initial Catalog = Insurance; Server = .\SQLEXPRESS");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Client>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<Policy>(new PolicyConfiguration());
        }
    }
}
