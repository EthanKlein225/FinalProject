﻿// <auto-generated />
using System;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProject.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240510001623_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("FinalProject.Models.Collection", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CollectionId");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("FinalProject.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Console")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Rating")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("GameId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("FinalProject.Models.GameCollection", b =>
                {
                    b.Property<int>("CollectionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CollectionId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameCollection");
                });

            modelBuilder.Entity("FinalProject.Models.GameCollection", b =>
                {
                    b.HasOne("FinalProject.Models.Collection", "Collection")
                        .WithMany("GameCollections")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProject.Models.Game", "Game")
                        .WithMany("GameCollections")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("FinalProject.Models.Collection", b =>
                {
                    b.Navigation("GameCollections");
                });

            modelBuilder.Entity("FinalProject.Models.Game", b =>
                {
                    b.Navigation("GameCollections");
                });
#pragma warning restore 612, 618
        }
    }
}
