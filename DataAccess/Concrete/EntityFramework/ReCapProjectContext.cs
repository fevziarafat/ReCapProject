using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=.;
                 Initial Catalog=C:\USERS\XXX\DOCUMENTS\RECAPPROJECT.MDF;
                 Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False");
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
