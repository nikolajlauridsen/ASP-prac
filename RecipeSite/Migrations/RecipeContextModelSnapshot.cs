﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeSite.Models;

namespace RecipeSite.Migrations
{
    [DbContext(typeof(RecipeContext))]
    partial class RecipeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeSite.Models.Comment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("Published");

                    b.Property<int>("RecipeID");

                    b.HasKey("ID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("RecipeSite.Models.Ingredient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Quantity");

                    b.Property<int>("RecipeID");

                    b.Property<int>("UnitID");

                    b.HasKey("ID");

                    b.HasIndex("RecipeID");

                    b.HasIndex("UnitID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RecipeSite.Models.Rating", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RecipeID");

                    b.Property<int>("Value");

                    b.HasKey("ID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("RecipeSite.Models.Recipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Procedure")
                        .IsRequired();

                    b.Property<DateTime>("Published");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("RecipeSite.Models.Unit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("RecipeSite.Models.Comment", b =>
                {
                    b.HasOne("RecipeSite.Models.Recipe")
                        .WithMany("Comments")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecipeSite.Models.Ingredient", b =>
                {
                    b.HasOne("RecipeSite.Models.Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RecipeSite.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RecipeSite.Models.Rating", b =>
                {
                    b.HasOne("RecipeSite.Models.Recipe")
                        .WithMany("Ratings")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
