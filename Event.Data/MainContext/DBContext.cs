using Event.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Data.MainContext
{
    public class DBContext : DbContext
    {
            public DBContext(DbContextOptions options) : base(options)
            {
            }

            public DbSet<Cities> Cities { get; set; }

            public DbSet<Events> Events { get; set; }

            public DbSet<Speaker> Speaker { get; set; }

            public DbSet<TalkDetails> TalkDetails { get; set; }    
    }
}

