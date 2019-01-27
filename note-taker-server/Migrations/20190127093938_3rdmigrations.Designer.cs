﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using note_taker_server.Models;

namespace notetakerserver.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190127093938_3rdmigrations")]
    partial class _3rdmigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("note_taker_server.Models.Note", b =>
                {
                    b.Property<int>("NoteID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<int>("LanguageId");

                    b.Property<int?>("ProgrammingLanguageLanguageId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("NoteID");

                    b.HasIndex("LanguageId");

                    b.HasIndex("ProgrammingLanguageLanguageId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("note_taker_server.Models.ProgrammingLanguage", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("LanguageId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("note_taker_server.Models.Note", b =>
                {
                    b.HasOne("note_taker_server.Models.ProgrammingLanguage", "language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("note_taker_server.Models.ProgrammingLanguage")
                        .WithMany("Notes")
                        .HasForeignKey("ProgrammingLanguageLanguageId");
                });
#pragma warning restore 612, 618
        }
    }
}
