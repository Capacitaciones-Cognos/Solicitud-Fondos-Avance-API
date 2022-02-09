﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solicitud_Fondos_Avance_API.Infrastructure.DataContext;

namespace Solicitud_Fondos_Avance_API.Migrations
{
    [DbContext(typeof(DbContextSolicitudFondosAvance))]
    partial class DbContextSolicitudFondosAvanceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Solicitud_Fondos_Avance_API.Models.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("apMaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apPaterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("estado")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Solicitud_Fondos_Avance_API.Models.Proyecto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("estado")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("fechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("personaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("personaId");

                    b.ToTable("Proyectos");
                });

            modelBuilder.Entity("Solicitud_Fondos_Avance_API.Models.SubProyecto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("estado")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("fechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_creacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fecha_modificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("proyectoId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("proyectoId");

                    b.ToTable("SubProyecto");
                });

            modelBuilder.Entity("Solicitud_Fondos_Avance_API.Models.Proyecto", b =>
                {
                    b.HasOne("Solicitud_Fondos_Avance_API.Models.Persona", "persona")
                        .WithMany("proyectos")
                        .HasForeignKey("personaId");

                    b.Navigation("persona");
                });

            modelBuilder.Entity("Solicitud_Fondos_Avance_API.Models.SubProyecto", b =>
                {
                    b.HasOne("Solicitud_Fondos_Avance_API.Models.Proyecto", "proyecto")
                        .WithMany()
                        .HasForeignKey("proyectoId");

                    b.Navigation("proyecto");
                });

            modelBuilder.Entity("Solicitud_Fondos_Avance_API.Models.Persona", b =>
                {
                    b.Navigation("proyectos");
                });
#pragma warning restore 612, 618
        }
    }
}
