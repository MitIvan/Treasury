﻿// <auto-generated />
using System;
using Blagajna.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blagajna.Domain.Migrations
{
    [DbContext(typeof(DenBlDbContext))]
    [Migration("20210128191001_sostojba")]
    partial class sostojba
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blagajna.Domain.Den.Bl.Models.DenDocumnet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DenIzvodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DocDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PresmetkovnaEdId")
                        .HasColumnType("int");

                    b.Property<int>("TotalSmetki")
                        .HasColumnType("int");

                    b.Property<int>("VidDocument")
                        .HasColumnType("int");

                    b.Property<int>("VrabotenId")
                        .HasColumnType("int");

                    b.Property<string>("Zabeleska")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("DenIzvodId");

                    b.HasIndex("PresmetkovnaEdId");

                    b.HasIndex("VrabotenId");

                    b.ToTable("DenDocumnents");
                });

            modelBuilder.Entity("Blagajna.Domain.Den.Bl.Models.DenIzvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DenBlSostojba")
                        .HasColumnType("int");

                    b.Property<int>("Saldo")
                        .HasColumnType("int");

                    b.Property<int>("VkupenPriem")
                        .HasColumnType("int");

                    b.Property<int>("VkupnaIsplata")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DenIzvodi");
                });

            modelBuilder.Entity("Blagajna.Domain.Den.Bl.Models.DenSmetka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DenDocumnetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SmetkaDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SmetkaInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SmetkaTotal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DenDocumnetId");

                    b.ToTable("DenSmetki");
                });

            modelBuilder.Entity("Blagajna.Domain.Shared.Models.DenBlSostojba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DenSostojba")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DenBlSostojba");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DenSostojba = 1000000
                        });
                });

            modelBuilder.Entity("Blagajna.Domain.Shared.Models.PresmetkovnaEd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PresmetkovniEd");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PeName = "SK 123 ZZ"
                        },
                        new
                        {
                            Id = 2,
                            PeName = "SK 124 HZ"
                        });
                });

            modelBuilder.Entity("Blagajna.Domain.Shared.Models.Vraboten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mb")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vraboteni");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Ivan Mitev",
                            Mb = 190
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Ljubica Donevska",
                            Mb = 191
                        });
                });

            modelBuilder.Entity("Blagajna.Domain.Den.Bl.Models.DenDocumnet", b =>
                {
                    b.HasOne("Blagajna.Domain.Den.Bl.Models.DenIzvod", "DenIzvod")
                        .WithMany("DenDocuments")
                        .HasForeignKey("DenIzvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blagajna.Domain.Shared.Models.PresmetkovnaEd", "PresmetkovnaEd")
                        .WithMany("DenDocuments")
                        .HasForeignKey("PresmetkovnaEdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blagajna.Domain.Shared.Models.Vraboten", "Vraboten")
                        .WithMany("DenDocuments")
                        .HasForeignKey("VrabotenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blagajna.Domain.Den.Bl.Models.DenSmetka", b =>
                {
                    b.HasOne("Blagajna.Domain.Den.Bl.Models.DenDocumnet", "DenDocumnet")
                        .WithMany("DenSmetki")
                        .HasForeignKey("DenDocumnetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}