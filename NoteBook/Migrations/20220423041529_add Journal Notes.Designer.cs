﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteBook.Data;

namespace NoteBook.Migrations
{
    [DbContext(typeof(NoteBookContext))]
    [Migration("20220423041529_add Journal Notes")]
    partial class addJournalNotes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NoteBook.Models.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColorId");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("NoteBook.Models.Greeting", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContentId");

                    b.ToTable("Greeting");
                });

            modelBuilder.Entity("NoteBook.Models.Journal", b =>
                {
                    b.Property<int>("JournalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MoodId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("NotebookId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeatherId")
                        .HasColumnType("int");

                    b.HasKey("JournalId");

                    b.HasIndex("ColorId");

                    b.HasIndex("MoodId");

                    b.HasIndex("NotebookId");

                    b.HasIndex("WeatherId");

                    b.ToTable("Journal");
                });

            modelBuilder.Entity("NoteBook.Models.Mood", b =>
                {
                    b.Property<int>("MoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoodPic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoodId");

                    b.ToTable("Mood");
                });

            modelBuilder.Entity("NoteBook.Models.Notebook", b =>
                {
                    b.Property<int>("NotebookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotebookId");

                    b.ToTable("Notebook");
                });

            modelBuilder.Entity("NoteBook.Models.PhotoDiary", b =>
                {
                    b.Property<int>("PhotoDiaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TemplateId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("secondContent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhotoDiaryId");

                    b.HasIndex("TemplateId");

                    b.ToTable("PhotoDiary");
                });

            modelBuilder.Entity("NoteBook.Models.Template", b =>
                {
                    b.Property<int>("TemplateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Templates")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateId");

                    b.ToTable("Template");
                });

            modelBuilder.Entity("NoteBook.Models.Weather", b =>
                {
                    b.Property<int>("WeatherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("WeatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WeatherPic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeatherId");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("NoteBook.Models.Journal", b =>
                {
                    b.HasOne("NoteBook.Models.Color", "color")
                        .WithMany("Journals")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteBook.Models.Mood", "mood")
                        .WithMany("Journals")
                        .HasForeignKey("MoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteBook.Models.Notebook", "notebook")
                        .WithMany("Journals")
                        .HasForeignKey("NotebookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NoteBook.Models.Weather", "weather")
                        .WithMany("Journals")
                        .HasForeignKey("WeatherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("color");

                    b.Navigation("mood");

                    b.Navigation("notebook");

                    b.Navigation("weather");
                });

            modelBuilder.Entity("NoteBook.Models.PhotoDiary", b =>
                {
                    b.HasOne("NoteBook.Models.Template", "template")
                        .WithMany("PhotoDiarys")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("template");
                });

            modelBuilder.Entity("NoteBook.Models.Color", b =>
                {
                    b.Navigation("Journals");
                });

            modelBuilder.Entity("NoteBook.Models.Mood", b =>
                {
                    b.Navigation("Journals");
                });

            modelBuilder.Entity("NoteBook.Models.Notebook", b =>
                {
                    b.Navigation("Journals");
                });

            modelBuilder.Entity("NoteBook.Models.Template", b =>
                {
                    b.Navigation("PhotoDiarys");
                });

            modelBuilder.Entity("NoteBook.Models.Weather", b =>
                {
                    b.Navigation("Journals");
                });
#pragma warning restore 612, 618
        }
    }
}
