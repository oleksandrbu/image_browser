using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace image_browser
{
    public class DbConnectionContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Filetype> Filetypes { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<ImageCharacter> ImageCharacters { get; set;}
        public DbSet<TitleCharacter> TitleCharacters { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            string[] initString = File.ReadAllLines("conf/db.config");
            optionsBuilder.UseNpgsql(initString[0]);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageCharacter>()
                .HasKey(t => new { t.ImageId, t.CharacterId });
    
            modelBuilder.Entity<ImageCharacter>()
                .HasOne(sc => sc.Image)
                .WithMany(s => s.ImageCharacters)
                .HasForeignKey(sc => sc.ImageId);
    
            modelBuilder.Entity<ImageCharacter>()
                .HasOne(sc => sc.Character)
                .WithMany(s => s.ImageCharacters)
                .HasForeignKey(sc => sc.CharacterId);
            
            modelBuilder.Entity<TitleCharacter>()
                .HasKey(t => new { t.TitleId, t.CharacterId });
    
            modelBuilder.Entity<TitleCharacter>()
                .HasOne(sc => sc.Title)
                .WithMany(s => s.TitleCharacters)
                .HasForeignKey(sc => sc.TitleId);
    
            modelBuilder.Entity<TitleCharacter>()
                .HasOne(sc => sc.Character)
                .WithMany(s => s.TitleCharacters)
                .HasForeignKey(sc => sc.CharacterId);
        }
    }
}