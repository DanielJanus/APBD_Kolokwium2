using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S18782_Daniel_Janus_Kolos2.Models;

namespace S18782_Daniel_Janus_Kolos2.Models
{
    public class MusicLabelContext : DbContext
    {
        public MusicLabelContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=APBD12;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seedMusician = new List<Musican>
            {
                new Musican {IdMusican = 1,FirstName = "Piotr",LastName = "Jakiś",Nickname="Tak"},
                new Musican {IdMusican = 2,FirstName = "Adam",LastName = "Gorzej",Nickname=null}
            };

            var seedMusicLabel = new List<MusicLabel>
            {
                new MusicLabel{IdMusicLabel = 1,Name = "Fajna"},
                new MusicLabel{IdMusicLabel = 2,Name = "Brzydka"}
            };

            var seedAlbum = new List<Album>
            {
                new Album{IdAlbum = 1,AlbumName ="Elegancki",PublishDate = DateTime.Now,IdMusicLabel = 1},
                new Album{IdAlbum = 2,AlbumName ="Niefajny",PublishDate = DateTime.Now,IdMusicLabel = 2}
            };

            var seedTrack = new List<Track>
            {
                new Track{IdTrack = 1,TrackName ="Najlepszy",Duration = 3,IdMusicAlbum = 1},
                new Track{IdTrack = 2,TrackName ="Najgorszy",Duration = 5,IdMusicAlbum = null}
            };

            var seedMusician_Track = new List<Musican_Track>
            {
                new Musican_Track {IdMusicianTrack = 1,IdTrack = 1,IdMusician = 1},
                new Musican_Track {IdMusicianTrack = 2,IdTrack = 2,IdMusician = 2}
            };

            modelBuilder.Entity<Musican>().HasData(seedMusician);
            modelBuilder.Entity<MusicLabel>().HasData(seedMusicLabel);
            modelBuilder.Entity<Album>().HasData(seedAlbum);
            modelBuilder.Entity<Track>().HasData(seedTrack);
            modelBuilder.Entity<Musican_Track>().HasData(seedMusician_Track);

            
        }

        public DbSet<Musican> Musican { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<Musican_Track> Musican_Track { get; set; }



    }
}
