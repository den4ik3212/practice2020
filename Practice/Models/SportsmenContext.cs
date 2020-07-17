using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
namespace Practice.Models
{
    public class SportsmenContext : DbContext
    {
        public SportsmenContext(DbContextOptions<SportsmenContext> options)
            : base(options)
        {
        }

    public DbSet<Sportsmen> Sportsmen { get; set; }
    }
}
