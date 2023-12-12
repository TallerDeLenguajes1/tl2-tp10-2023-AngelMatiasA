using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using kanban.Models;

namespace kanban.ViewModels;

public class ModificarTareaViewModel
{
    [Required(ErrorMessage = "Este campo es requerido.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Id Tablero")]
    public int IdTablero { get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Estado")]
    public Estado Estado { get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Descripcion")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Color")]
    public string Color { get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Id Usuario Asignado")]
    public int IdUsuarioAsingnado { get; set; }

    public ModificarTareaViewModel()
    {
    }

    public ModificarTareaViewModel(Tarea tarea)
    {
        Id = tarea.Id;
        IdTablero = tarea.Id_Tablero;
        Nombre = tarea.Nombre;
        Estado = tarea.Estado;
        Descripcion = tarea.Descripcion;
        Color = tarea.Color;
        IdUsuarioAsingnado = tarea.Id_usuario_asignado;
    }
}

