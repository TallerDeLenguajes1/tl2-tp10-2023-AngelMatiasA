using System;
using kanban.ViewModels;
namespace kanban.Models;

public class Tarea
{
    public int Id { get; set; }
    public int Id_Tablero { get; set; }
    public string? Nombre { get; set; }
    public Estado Estado { get; set; }
    public string? Descripcion { get; set; }
    public string? Color { get; set; }
    public int Id_usuario_asignado { get; set; }

    public Tarea()
    {
    }

    public Tarea(CrearTareaViewModel tareaVM)
    {
        Id_Tablero = tareaVM.idTablero;
        Nombre = tareaVM.Nombre;
        Estado = tareaVM.Estado;
        Descripcion = tareaVM.Descripcion;
        Color = tareaVM.Color;
        Id_usuario_asignado = tareaVM.idUsuarioAsingnado;
    }

    public Tarea(ModificarTareaViewModel tareaVM)
    {
        Id = tareaVM.Id;
        Id_Tablero = tareaVM.IdTablero;
        Nombre = tareaVM.Nombre;
        Estado = tareaVM.Estado;
        Descripcion = tareaVM.Descripcion;
        Color = tareaVM.Color;
        Id_usuario_asignado = tareaVM.IdUsuarioAsingnado;
    }
}

public enum Estado{
    ToDo, 
    Doing, 
    Review, 
    Done
}