﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S18782_Daniel_Janus_Kolos2.Models;

namespace S18782_Daniel_Janus_Kolos2.Migrations
{
    [DbContext(typeof(MusicLabelContext))]
    partial class MusicLabelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("S18782_Daniel_Janus_Kolos2.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Elegancki",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2020, 6, 15, 12, 44, 25, 837, DateTimeKind.Local).AddTicks(2752)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "Niefajny",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2020, 6, 15, 12, 44, 25, 839, DateTimeKind.Local).AddTicks(657)
                        });
                });

            modelBuilder.Entity("S18782_Daniel_Janus_Kolos2.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabel");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "Fajna"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "Brzydka"
                        });
                });

            modelBuilder.Entity("S18782_Daniel_Janus_Kolos2.Models.Musican", b =>
                {
                    b.Property<int>("IdMusican")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("IdMusican");

                    b.ToTable("Musican");

                    b.HasData(
                        new
                        {
                            IdMusican = 1,
                            FirstName = "Piotr",
                            LastName = "Jakiś",
                            Nickname = "Tak"
                        },
                        new
                        {
                            IdMusican = 2,
                            FirstName = "Adam",
                            LastName = "Gorzej"
                        });
                });

            modelBuilder.Entity("S18782_Daniel_Janus_Kolos2.Models.Musican_Track", b =>
                {
                    b.Property<int>("IdMusicianTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.Property<int?>("MusicanIdMusican")
                        .HasColumnType("int");

                    b.HasKey("IdMusicianTrack");

                    b.HasIndex("IdTrack");

                    b.HasIndex("MusicanIdMusican");

                    b.ToTable("Musican_Track");

                    b.HasData(
                        new
                        {
                            IdMusicianTrack = 1,
                            IdMusician = 1,
                            IdTrack = 1
                        },
                        new
                        {
                            IdMusicianTrack = 2,
                            IdMusician = 2,
                            IdTrack = 2
                        });
                });

            modelBuilder.Entity("S18782_Daniel_Janus_Kolos2.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Track");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 3f,
                            IdMusicAlbum = 1,
                            TrackName = "Najlepszy"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 5f,
                            TrackName = "Najgorszy"
                        });
                });

            modelBuilder.Entity("S18782_Daniel_Janus_Kolos2.Models.Album", b =>
                {
                    b.HasOne("S18782_Daniel_Janus_Kolos2.Models.MusicLabel", "MusicLabel")
                        .WithMany("Album")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("S18782_Daniel_Janus_Kolos2.Models.Musican_Track", b =>
                {
                    b.HasOne("S18782_Daniel_Janus_Kolos2.Models.Track", "Track")
                        .WithMany("Musican_Track")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("S18782_Daniel_Janus_Kolos2.Models.Musican", "Musican")
                        .WithMany("Musican_Track")
                        .HasForeignKey("MusicanIdMusican");
                });

            modelBuilder.Entity("S18782_Daniel_Janus_Kolos2.Models.Track", b =>
                {
                    b.HasOne("S18782_Daniel_Janus_Kolos2.Models.Album", "Album")
                        .WithMany("Track")
                        .HasForeignKey("IdMusicAlbum");
                });
#pragma warning restore 612, 618
        }
    }
}
