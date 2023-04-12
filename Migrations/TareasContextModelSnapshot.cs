﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyectoef;

#nullable disable

namespace proyectoef.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("d0dc192d-f654-4b06-82e9-e9063a5b60e9"),
                            Nombre = "Actividades Pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("d0dc192d-f654-4b06-82e9-e9063a5b60a7"),
                            Nombre = "Actividades Personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("d0dc192d-f654-4b06-82e9-e9063a5b6010"),
                            CategoriaId = new Guid("d0dc192d-f654-4b06-82e9-e9063a5b60e9"),
                            FechaCreacion = new DateTime(2023, 4, 12, 11, 55, 31, 654, DateTimeKind.Local).AddTicks(8657),
                            PrioridadTarea = 1,
                            Titulo = "Pagos Servicios Publicos"
                        },
                        new
                        {
                            TareaId = new Guid("d0dc192d-f654-4b06-82e9-e9063a5b6011"),
                            CategoriaId = new Guid("d0dc192d-f654-4b06-82e9-e9063a5b60a7"),
                            FechaCreacion = new DateTime(2023, 4, 12, 11, 55, 31, 654, DateTimeKind.Local).AddTicks(8672),
                            PrioridadTarea = 0,
                            Titulo = "Terminar de ver pelicula en netflix"
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.HasOne("proyectoef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
