using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace S18782_Daniel_Janus_Kolos2.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musican",
                columns: table => new
                {
                    IdMusican = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musican", x => x.IdMusican);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabel",
                columns: table => new
                {
                    IdMusicLabel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabel", x => x.IdMusicLabel);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumName = table.Column<string>(maxLength: 30, nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    IdMusicLabel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Album_MusicLabel_IdMusicLabel",
                        column: x => x.IdMusicLabel,
                        principalTable: "MusicLabel",
                        principalColumn: "IdMusicLabel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    IdTrack = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrackName = table.Column<string>(maxLength: 20, nullable: false),
                    Duration = table.Column<float>(nullable: false),
                    IdMusicAlbum = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.IdTrack);
                    table.ForeignKey(
                        name: "FK_Track_Album_IdMusicAlbum",
                        column: x => x.IdMusicAlbum,
                        principalTable: "Album",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Musican_Track",
                columns: table => new
                {
                    IdMusicianTrack = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTrack = table.Column<int>(nullable: false),
                    IdMusician = table.Column<int>(nullable: false),
                    MusicanIdMusican = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musican_Track", x => x.IdMusicianTrack);
                    table.ForeignKey(
                        name: "FK_Musican_Track_Track_IdTrack",
                        column: x => x.IdTrack,
                        principalTable: "Track",
                        principalColumn: "IdTrack",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musican_Track_Musican_MusicanIdMusican",
                        column: x => x.MusicanIdMusican,
                        principalTable: "Musican",
                        principalColumn: "IdMusican",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MusicLabel",
                columns: new[] { "IdMusicLabel", "Name" },
                values: new object[,]
                {
                    { 1, "Fajna" },
                    { 2, "Brzydka" }
                });

            migrationBuilder.InsertData(
                table: "Musican",
                columns: new[] { "IdMusican", "FirstName", "LastName", "Nickname" },
                values: new object[,]
                {
                    { 1, "Piotr", "Jakiś", "Tak" },
                    { 2, "Adam", "Gorzej", null }
                });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 2, 5f, null, "Najgorszy" });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 1, "Elegancki", 1, new DateTime(2020, 6, 15, 12, 44, 25, 837, DateTimeKind.Local).AddTicks(2752) });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
                values: new object[] { 2, "Niefajny", 2, new DateTime(2020, 6, 15, 12, 44, 25, 839, DateTimeKind.Local).AddTicks(657) });

            migrationBuilder.InsertData(
                table: "Musican_Track",
                columns: new[] { "IdMusicianTrack", "IdMusician", "IdTrack", "MusicanIdMusican" },
                values: new object[] { 2, 2, 2, null });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
                values: new object[] { 1, 3f, 1, "Najlepszy" });

            migrationBuilder.InsertData(
                table: "Musican_Track",
                columns: new[] { "IdMusicianTrack", "IdMusician", "IdTrack", "MusicanIdMusican" },
                values: new object[] { 1, 1, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Album_IdMusicLabel",
                table: "Album",
                column: "IdMusicLabel");

            migrationBuilder.CreateIndex(
                name: "IX_Musican_Track_IdTrack",
                table: "Musican_Track",
                column: "IdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Musican_Track_MusicanIdMusican",
                table: "Musican_Track",
                column: "MusicanIdMusican");

            migrationBuilder.CreateIndex(
                name: "IX_Track_IdMusicAlbum",
                table: "Track",
                column: "IdMusicAlbum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musican_Track");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Musican");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "MusicLabel");
        }
    }
}
