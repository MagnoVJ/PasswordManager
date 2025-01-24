using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassManager.model
{
    public class PassManagerDbContext : DbContext
    {

        private readonly string connectionString;

        public PassManagerDbContext(string connectionString) {

            this.connectionString = connectionString;

        }

        public DbSet<Account> account {  get; set; }
        public DbSet<Password_item> password_item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL(connectionString);
        }



    }
}
