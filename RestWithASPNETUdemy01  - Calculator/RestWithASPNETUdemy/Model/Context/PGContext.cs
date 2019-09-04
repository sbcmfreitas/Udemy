using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Model.Context
{
    public class PgContext : DbContext
    {
        public PgContext()
        {

        }

        public PgContext(DbContextOptions<PgContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }
    }
}
