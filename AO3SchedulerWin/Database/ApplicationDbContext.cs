using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AO3SchedulerWin.Models.Base;
using Microsoft.EntityFrameworkCore;


namespace AO3SchedulerWin.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            optionsBuilder.UseSqlite($"Data Source={appdata}/AO3S/appstorage.sqlite");
        }
    }
}
