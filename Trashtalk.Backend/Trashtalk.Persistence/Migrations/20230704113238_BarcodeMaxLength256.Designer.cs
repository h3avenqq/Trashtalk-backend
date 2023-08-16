﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Trashtalk.Persistence;

#nullable disable

namespace Trashtalk.Persistence.Migrations
{
    [DbContext(typeof(TrashTalkDbContext))]
    [Migration("20230704113238_BarcodeMaxLength256")]
    partial class BarcodeMaxLength256
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Trashtalk.Domain.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("BriefDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("News");
                });

            modelBuilder.Entity("Trashtalk.Domain.ReceptionPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<Point>("Coordinates")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("ReceptionPoints");
                });

            modelBuilder.Entity("Trashtalk.Domain.Trash", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("Barcode")
                        .IsUnique();

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TypeId");

                    b.ToTable("Trash");
                });

            modelBuilder.Entity("Trashtalk.Domain.TrashBin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("TrashBins");
                });

            modelBuilder.Entity("Trashtalk.Domain.TrashType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("TrashBinId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TrashBinId");

                    b.ToTable("TrashTypes");
                });

            modelBuilder.Entity("Trashtalk.Domain.UserTrash", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TrashId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TrashId");

                    b.ToTable("UserTrash");
                });

            modelBuilder.Entity("Trashtalk.Domain.News", b =>
                {
                    b.HasOne("Trashtalk.Domain.ReceptionPoint", "Author")
                        .WithMany("News")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Trashtalk.Domain.Trash", b =>
                {
                    b.HasOne("Trashtalk.Domain.TrashType", "Type")
                        .WithMany("Trash")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Trashtalk.Domain.TrashType", b =>
                {
                    b.HasOne("Trashtalk.Domain.TrashBin", "TrashBin")
                        .WithMany("TrashTypes")
                        .HasForeignKey("TrashBinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrashBin");
                });

            modelBuilder.Entity("Trashtalk.Domain.UserTrash", b =>
                {
                    b.HasOne("Trashtalk.Domain.Trash", "Trash")
                        .WithMany("UserTrash")
                        .HasForeignKey("TrashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trash");
                });

            modelBuilder.Entity("Trashtalk.Domain.ReceptionPoint", b =>
                {
                    b.Navigation("News");
                });

            modelBuilder.Entity("Trashtalk.Domain.Trash", b =>
                {
                    b.Navigation("UserTrash");
                });

            modelBuilder.Entity("Trashtalk.Domain.TrashBin", b =>
                {
                    b.Navigation("TrashTypes");
                });

            modelBuilder.Entity("Trashtalk.Domain.TrashType", b =>
                {
                    b.Navigation("Trash");
                });
#pragma warning restore 612, 618
        }
    }
}