using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using imento.Models;

namespace imento.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20160627111548_UpdatePhotoModel")]
    partial class UpdatePhotoModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20896");

            modelBuilder.Entity("imento.Models.Album", b =>
                {
                    b.Property<string>("AlbumId");

                    b.Property<DateTime>("Date_Ende");

                    b.Property<DateTime>("Date_Start");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.HasKey("AlbumId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("imento.Models.Entry", b =>
                {
                    b.Property<int>("EntryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlbumId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("EntryId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("imento.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlbumId");

                    b.Property<string>("Description");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("LocationId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("imento.Models.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EntryId");

                    b.Property<byte[]>("ImageByteArray");

                    b.Property<bool>("isFavourite");

                    b.HasKey("PhotoId");

                    b.HasIndex("EntryId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("imento.Models.Entry", b =>
                {
                    b.HasOne("imento.Models.Album")
                        .WithMany()
                        .HasForeignKey("AlbumId");
                });

            modelBuilder.Entity("imento.Models.Location", b =>
                {
                    b.HasOne("imento.Models.Album")
                        .WithOne()
                        .HasForeignKey("imento.Models.Location", "AlbumId");
                });

            modelBuilder.Entity("imento.Models.Photo", b =>
                {
                    b.HasOne("imento.Models.Entry")
                        .WithMany()
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
