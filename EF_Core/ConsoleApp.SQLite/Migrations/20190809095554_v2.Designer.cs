﻿// <auto-generated />
using System;
using ConsoleApp.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp.SQLite.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20190809095554_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("ConsoleApp.SQLite.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("ConsoleApp.SQLite.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ConsoleApp.SQLite.Subscriber", b =>
                {
                    b.Property<int>("SubscriberId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BlogId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("SubscriberId");

                    b.HasIndex("BlogId");

                    b.ToTable("Subscriber");
                });

            modelBuilder.Entity("ConsoleApp.SQLite.Post", b =>
                {
                    b.HasOne("ConsoleApp.SQLite.Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConsoleApp.SQLite.Subscriber", b =>
                {
                    b.HasOne("ConsoleApp.SQLite.Blog", "Blog")
                        .WithMany("Subscribes")
                        .HasForeignKey("BlogId");
                });
#pragma warning restore 612, 618
        }
    }
}
