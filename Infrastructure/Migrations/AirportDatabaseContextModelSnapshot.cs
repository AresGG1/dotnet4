﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AirportDatabaseContext))]
    partial class AirportDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Models.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightHours")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Aircrafts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FlightHours = 1688,
                            Manufacturer = "Stehr - Emmerich",
                            Model = "Cruze",
                            Year = 1982
                        },
                        new
                        {
                            Id = 2,
                            FlightHours = 1650,
                            Manufacturer = "Satterfield, Hagenes and ",
                            Model = "Alpine",
                            Year = 2006
                        },
                        new
                        {
                            Id = 3,
                            FlightHours = 151,
                            Manufacturer = "Hammes - Feil",
                            Model = "Alpine",
                            Year = 1978
                        },
                        new
                        {
                            Id = 4,
                            FlightHours = 1388,
                            Manufacturer = "Schroeder Inc",
                            Model = "Escalade",
                            Year = 1970
                        },
                        new
                        {
                            Id = 5,
                            FlightHours = 239,
                            Manufacturer = "Nikolaus Group",
                            Model = "Wrangler",
                            Year = 1998
                        },
                        new
                        {
                            Id = 6,
                            FlightHours = 132,
                            Manufacturer = "Terry, Turner and Schmitt",
                            Model = "Taurus",
                            Year = 1996
                        },
                        new
                        {
                            Id = 7,
                            FlightHours = 1542,
                            Manufacturer = "Greenfelder - Zieme",
                            Model = "Land Cruiser",
                            Year = 1974
                        },
                        new
                        {
                            Id = 8,
                            FlightHours = 1228,
                            Manufacturer = "O'Kon Group",
                            Model = "Camry",
                            Year = 2017
                        },
                        new
                        {
                            Id = 9,
                            FlightHours = 1887,
                            Manufacturer = "Marquardt Group",
                            Model = "Element",
                            Year = 2019
                        },
                        new
                        {
                            Id = 10,
                            FlightHours = 991,
                            Manufacturer = "Rau Inc",
                            Model = "Malibu",
                            Year = 1989
                        });
                });

            modelBuilder.Entity("Domain.Models.FlightDestination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("TicketPrice")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasDefaultValue(15m);

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.ToTable("FlightDestinations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AircraftId = 10,
                            Start = new DateTime(2023, 9, 7, 10, 37, 4, 953, DateTimeKind.Local).AddTicks(8702),
                            TicketPrice = 55.360310068471840m
                        },
                        new
                        {
                            Id = 2,
                            AircraftId = 3,
                            Start = new DateTime(2023, 7, 18, 23, 42, 28, 483, DateTimeKind.Local).AddTicks(2082),
                            TicketPrice = 191.495747836056160m
                        },
                        new
                        {
                            Id = 3,
                            AircraftId = 1,
                            Start = new DateTime(2023, 10, 21, 0, 33, 31, 512, DateTimeKind.Local).AddTicks(1837),
                            TicketPrice = 216.289991043976840m
                        },
                        new
                        {
                            Id = 4,
                            AircraftId = 10,
                            Start = new DateTime(2023, 7, 20, 15, 19, 4, 0, DateTimeKind.Local).AddTicks(3391),
                            TicketPrice = 376.483626162988360m
                        },
                        new
                        {
                            Id = 5,
                            AircraftId = 1,
                            Start = new DateTime(2023, 7, 21, 8, 36, 9, 361, DateTimeKind.Local).AddTicks(6254),
                            TicketPrice = 114.355516865629510m
                        },
                        new
                        {
                            Id = 6,
                            AircraftId = 3,
                            Start = new DateTime(2023, 9, 17, 15, 10, 13, 690, DateTimeKind.Local).AddTicks(5780),
                            TicketPrice = 62.388356628746710m
                        },
                        new
                        {
                            Id = 7,
                            AircraftId = 7,
                            Start = new DateTime(2023, 10, 12, 7, 21, 50, 494, DateTimeKind.Local).AddTicks(2280),
                            TicketPrice = 247.970267016316120m
                        },
                        new
                        {
                            Id = 8,
                            AircraftId = 1,
                            Start = new DateTime(2023, 7, 24, 8, 5, 38, 600, DateTimeKind.Local).AddTicks(8796),
                            TicketPrice = 311.874024882048580m
                        },
                        new
                        {
                            Id = 9,
                            AircraftId = 8,
                            Start = new DateTime(2023, 8, 29, 4, 29, 49, 71, DateTimeKind.Local).AddTicks(6200),
                            TicketPrice = 376.041178505421640m
                        },
                        new
                        {
                            Id = 10,
                            AircraftId = 9,
                            Start = new DateTime(2023, 8, 26, 3, 18, 58, 956, DateTimeKind.Local).AddTicks(1850),
                            TicketPrice = 304.874977411121380m
                        });
                });

            modelBuilder.Entity("Domain.Models.FlightDestination", b =>
                {
                    b.HasOne("Domain.Models.Aircraft", "Aircraft")
                        .WithMany("FlightDestination")
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");
                });

            modelBuilder.Entity("Domain.Models.Aircraft", b =>
                {
                    b.Navigation("FlightDestination");
                });
#pragma warning restore 612, 618
        }
    }
}
