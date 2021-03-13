﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(FitRoutineContext))]
    [Migration("20210313085035_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRestDay")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsRestDay = false,
                            Name = "Monday"
                        },
                        new
                        {
                            Id = 2,
                            IsRestDay = true,
                            Name = "Tuesday"
                        },
                        new
                        {
                            Id = 3,
                            IsRestDay = false,
                            Name = "Wednesday"
                        },
                        new
                        {
                            Id = 4,
                            IsRestDay = true,
                            Name = "Thursday"
                        },
                        new
                        {
                            Id = 5,
                            IsRestDay = false,
                            Name = "Friday"
                        },
                        new
                        {
                            Id = 6,
                            IsRestDay = true,
                            Name = "Saturday"
                        },
                        new
                        {
                            Id = 7,
                            IsRestDay = true,
                            Name = "Sunday"
                        });
                });

            modelBuilder.Entity("Data.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DayId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<int>("Reps")
                        .HasColumnType("int");

                    b.Property<int>("Sets")
                        .HasColumnType("int");

                    b.Property<int>("WeightInKg")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Data.Models.Exercise", b =>
                {
                    b.HasOne("Data.Models.Day", "Day")
                        .WithMany("Exercises")
                        .HasForeignKey("DayId");

                    b.Navigation("Day");
                });

            modelBuilder.Entity("Data.Models.Day", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
