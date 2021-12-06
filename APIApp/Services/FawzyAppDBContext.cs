using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FawzyShared.Models;
using Microsoft.EntityFrameworkCore;
namespace APIApp.Services
{
    public class FawzyAppDBContext : DbContext
    {
        public FawzyAppDBContext(DbContextOptions<FawzyAppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(
                    eb =>
                    {
                        eb.ToTable("User");
                        eb.HasNoKey();
                    });
    }
        public DbSet<User> Companies { get; set; }
}
}
