using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace image_browser
{
    public class MainContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Filetype> Filetypes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            string[] initString = File.ReadAllLines("conf/db.config");
            optionsBuilder.UseNpgsql(initString[0]);
        }
    }
}