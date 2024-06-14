﻿// <auto-generated />
using System;
using ApplicationDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Portafolio.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240518225316_m3")]
    partial class m3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProyectImages.Models.ProyectImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProyectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProyectId");

                    b.ToTable("ProyectImages");
                });

            modelBuilder.Entity("Proyects.Models.Proyect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Proyects");
                });

            modelBuilder.Entity("Reviews.Model.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Like")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("PId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("UserProyects.Models.UserProyect", b =>
                {
                    b.Property<Guid>("ProyectsId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(0);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnOrder(1);

                    b.HasKey("ProyectsId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProyects");
                });

            modelBuilder.Entity("Users.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProyectImages.Models.ProyectImage", b =>
                {
                    b.HasOne("Proyects.Models.Proyect", "Proyect")
                        .WithMany("ImagesP")
                        .HasForeignKey("ProyectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyect");
                });

            modelBuilder.Entity("Reviews.Model.Review", b =>
                {
                    b.HasOne("Proyects.Models.Proyect", "Proyect")
                        .WithMany()
                        .HasForeignKey("PId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Users.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyect");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserProyects.Models.UserProyect", b =>
                {
                    b.HasOne("Proyects.Models.Proyect", "Proyects")
                        .WithMany("UserProyects")
                        .HasForeignKey("ProyectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Users.Models.User", "User")
                        .WithMany("UserProyects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyects");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Proyects.Models.Proyect", b =>
                {
                    b.Navigation("ImagesP");

                    b.Navigation("UserProyects");
                });

            modelBuilder.Entity("Users.Models.User", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("UserProyects");
                });
#pragma warning restore 612, 618
        }
    }
}