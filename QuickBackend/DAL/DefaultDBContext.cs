using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuickBackend.DAL
{
    public class DefaultDBContext : DbContext
    {
        public DefaultDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Directory.GetCurrentDirectory() + "/DefaultDB.sqlite");
        }
        public DbSet<DefaultModel> DefaultModel { get; set; }
    }
}
