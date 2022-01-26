﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SPJMD.Data;

namespace SPJMD.Migrations
{
    [DbContext(typeof(SPJMDContext))]
    partial class SPJMDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("PolicialProcedimento", b =>
                {
                    b.Property<int>("PoliciaisId")
                        .HasColumnType("int");

                    b.Property<int>("ProcedimentosId")
                        .HasColumnType("int");

                    b.HasKey("PoliciaisId", "ProcedimentosId");

                    b.HasIndex("ProcedimentosId");

                    b.ToTable("PolicialProcedimento");
                });

            modelBuilder.Entity("SPJMD.Models.Oficial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Digito")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Posto")
                        .HasColumnType("int");

                    b.Property<string>("Re")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Oficial");
                });

            modelBuilder.Entity("SPJMD.Models.Policial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Digito")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<int>("Graduacao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Re")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Policial");
                });

            modelBuilder.Entity("SPJMD.Models.Procedimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int?>("OficialId")
                        .HasColumnType("int");

                    b.Property<string>("Opm")
                        .HasColumnType("longtext");

                    b.Property<int>("Origem")
                        .HasColumnType("int");

                    b.Property<string>("Prefixo")
                        .HasColumnType("longtext");

                    b.Property<int>("TipoProcedimento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OficialId");

                    b.ToTable("Procedimento");
                });

            modelBuilder.Entity("PolicialProcedimento", b =>
                {
                    b.HasOne("SPJMD.Models.Policial", null)
                        .WithMany()
                        .HasForeignKey("PoliciaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SPJMD.Models.Procedimento", null)
                        .WithMany()
                        .HasForeignKey("ProcedimentosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SPJMD.Models.Procedimento", b =>
                {
                    b.HasOne("SPJMD.Models.Oficial", "Oficial")
                        .WithMany("Procedimentos")
                        .HasForeignKey("OficialId");

                    b.Navigation("Oficial");
                });

            modelBuilder.Entity("SPJMD.Models.Oficial", b =>
                {
                    b.Navigation("Procedimentos");
                });
#pragma warning restore 612, 618
        }
    }
}
