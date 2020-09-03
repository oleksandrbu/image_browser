﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using image_browser;

namespace image_browser.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20200903124317_1-getting-files")]
    partial class _1gettingfiles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("image_browser.Character", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<long>("Age")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("image_browser.Filetype", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Filetypes");
                });

            modelBuilder.Entity("image_browser.Image", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal?>("FiletypeId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<long>("Height")
                        .HasColumnType("bigint");

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.Property<decimal?>("TitleId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<long>("Width")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FiletypeId");

                    b.HasIndex("TitleId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("image_browser.ImageCharacter", b =>
                {
                    b.Property<decimal>("ImageId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("CharacterId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("ImageId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("ImageCharacter");
                });

            modelBuilder.Entity("image_browser.Title", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("Release")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("image_browser.TitleCharacter", b =>
                {
                    b.Property<decimal>("TitleId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<decimal>("CharacterId")
                        .HasColumnType("numeric(20,0)");

                    b.HasKey("TitleId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("TitleCharacter");
                });

            modelBuilder.Entity("image_browser.Image", b =>
                {
                    b.HasOne("image_browser.Filetype", "Filetype")
                        .WithMany()
                        .HasForeignKey("FiletypeId");

                    b.HasOne("image_browser.Title", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId");
                });

            modelBuilder.Entity("image_browser.ImageCharacter", b =>
                {
                    b.HasOne("image_browser.Character", "Character")
                        .WithMany("ImageCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("image_browser.Image", "Image")
                        .WithMany("ImageCharacters")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("image_browser.TitleCharacter", b =>
                {
                    b.HasOne("image_browser.Character", "Character")
                        .WithMany("TitleCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("image_browser.Title", "Title")
                        .WithMany("TitleCharacters")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
