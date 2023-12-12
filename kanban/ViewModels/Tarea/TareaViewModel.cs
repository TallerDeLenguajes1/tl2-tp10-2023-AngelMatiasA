using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kanban.Models;
namespace kanban.ViewModels;

public class TareaViewModel
{
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Color { get; set; }
    public Estado Estado { get; set; }
    public int Id_tarea { get; set; }
    public int Id_Tablero { get; set; }
    public int? Id_Usuario_Asingnado { get; set; }

    public TareaViewModel()
    {
    }

    public TareaViewModel(Tarea tarea)
    {
        Id_tarea = tarea.Id;
        Id_Tablero = tarea.Id_Tablero;
        Nombre = tarea.Nombre;
        Descripcion = tarea.Descripcion;
        Color = tarea.Color;
        Estado = tarea.Estado;
        Id_Usuario_Asingnado = tarea.Id_usuario_asignado;
    }


}