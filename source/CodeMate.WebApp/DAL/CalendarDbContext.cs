using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeMate.WebApp.DAL
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Models;

    public class CalendarDbContext : DbContext
    {
        public CalendarDbContext() : base("defaultConnection")
        {
            
        }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}