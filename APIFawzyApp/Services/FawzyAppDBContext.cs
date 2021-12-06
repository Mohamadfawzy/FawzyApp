using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FawzyShared.Models;
using Microsoft.EntityFrameworkCore;
namespace APIFawzyApp.Services
{
    public class FawzyAppDBContext : DbContext
    {
        public FawzyAppDBContext(DbContextOptions<FawzyAppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(
                    eb =>
                    {
                        eb.ToTable("User");
                    }).Entity<Courses>(
                    eb =>
                    {
                        eb.ToTable("Courses");
                    }).Entity<Students>(
                    eb =>
                    {
                        eb.ToTable("Students");
                    }).Entity<Students_Courses>(
                    eb =>
                    {
                        eb.ToTable("Students_Courses");
                    });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Students_Courses> Students_Courses { get; set; }
    }
}
