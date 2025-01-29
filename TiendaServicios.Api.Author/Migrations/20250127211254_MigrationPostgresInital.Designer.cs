﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TiendaServicios.Api.Author.Persistence;

#nullable disable

namespace TiendaServicios.Api.Author.Migrations
{
    [DbContext(typeof(AuthorContext))]
    [Migration("20250127211254_MigrationPostgresInital")]
    partial class MigrationPostgresInital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TiendaServicios.Api.Author.Model.AcademyGradeModel", b =>
                {
                    b.Property<int>("AcademyGradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AcademyGradeId"));

                    b.Property<string>("AcademyCenter")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AcademyGradeGuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("BookAuthorId")
                        .HasColumnType("uuid");

                    b.Property<int>("BookAuthorId1")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("GradeDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AcademyGradeId");

                    b.HasIndex("BookAuthorId1");

                    b.ToTable("AcademyGrade");
                });

            modelBuilder.Entity("TiendaServicios.Api.Author.Model.BookAuthorModel", b =>
                {
                    b.Property<int>("BookAuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookAuthorId"));

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("BookAuthorGuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BookAuthorId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("TiendaServicios.Api.Author.Model.AcademyGradeModel", b =>
                {
                    b.HasOne("TiendaServicios.Api.Author.Model.BookAuthorModel", "BookAuthor")
                        .WithMany("AcademyGradesList")
                        .HasForeignKey("BookAuthorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookAuthor");
                });

            modelBuilder.Entity("TiendaServicios.Api.Author.Model.BookAuthorModel", b =>
                {
                    b.Navigation("AcademyGradesList");
                });
#pragma warning restore 612, 618
        }
    }
}
