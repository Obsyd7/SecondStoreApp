using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using SecondStoreApp.Models;

namespace SecondStoreApp.DAL
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext() : base ("StoreDbContext")
        {

        }

        static StoreDbContext()
        {
            Database.SetInitializer<StoreDbContext>(new CourseInitializer());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}