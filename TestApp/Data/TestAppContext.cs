using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.Model;

namespace TestApp.Models
{
    public class TestAppContext : DbContext
    {
        public TestAppContext (DbContextOptions<TestAppContext> options)
            : base(options)
        {
        }

        public DbSet<Vegetables> Vegetables { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Message> Message { get; set; }


    }
}
