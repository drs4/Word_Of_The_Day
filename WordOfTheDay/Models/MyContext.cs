using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordOfTheDay.Models
{
    class MyContext : DbContext
    {
        // default constructor should do this automatically but fails in this case
        public MyContext() : base("MyDBContext") { }

        public DbSet<Word> Words { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
