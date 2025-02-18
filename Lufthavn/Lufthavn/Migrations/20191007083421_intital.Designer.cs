﻿// <auto-generated />
using System;
using Lufthavn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lufthavn.Migrations
{
    [DbContext(typeof(LufthavnContext))]
    [Migration("20191007083421_intital")]
    partial class intital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lufthavn.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AircraftType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FromLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightId");

                    b.ToTable("Flight");
                });
#pragma warning restore 612, 618
        }
    }
}
