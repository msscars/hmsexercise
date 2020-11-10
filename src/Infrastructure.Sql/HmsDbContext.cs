using Hms.Exercise.Domain.ResultAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hms.Exercise.Infrastructure.Sql
{
    public class HmsDbContext : DbContext
    {
        public HmsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>().HasKey(x => x.Id);
        }
    }
}
