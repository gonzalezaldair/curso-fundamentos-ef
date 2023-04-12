using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoef.Models;
using Microsoft.EntityFrameworkCore;

namespace proyectoef
{
    public class TareasContext : DbContext
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasListInit = new List<Categoria>();
            categoriasListInit.Add(new Categoria (){ CategoriaId = Guid.Parse("d0dc192d-f654-4b06-82e9-e9063a5b60e9"), Nombre = "Actividades Pendientes", Peso = 20 });
            categoriasListInit.Add(new Categoria (){ CategoriaId = Guid.Parse("d0dc192d-f654-4b06-82e9-e9063a5b60a7"), Nombre = "Actividades Personales", Peso = 50 });
            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);

                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

                categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p => p.Peso);

                categoria.HasData(categoriasListInit);

            });

            List<Tarea> tareasListInit = new List<Tarea>();
            tareasListInit.Add( new Tarea () { TareaId = Guid.Parse("d0dc192d-f654-4b06-82e9-e9063a5b6010"), CategoriaId = Guid.Parse("d0dc192d-f654-4b06-82e9-e9063a5b60e9") , 
            PrioridadTarea = Prioridad.Media ,Titulo = "Pagos Servicios Publicos", FechaCreacion = DateTime.Now } );
            tareasListInit.Add( new Tarea () { TareaId = Guid.Parse("d0dc192d-f654-4b06-82e9-e9063a5b6011"), CategoriaId = Guid.Parse("d0dc192d-f654-4b06-82e9-e9063a5b60a7") , 
            PrioridadTarea = Prioridad.Baja ,Titulo = "Terminar de ver pelicula en netflix", FechaCreacion = DateTime.Now } );


            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);

                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);

                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);

                tarea.Property(p => p.Descripcion).IsRequired(false);

                tarea.Property(p => p.PrioridadTarea);

                tarea.Property(p => p.FechaCreacion);

                tarea.Ignore(p => p.Resumen);

                tarea.HasData(tareasListInit);

            });

        }
    }
}