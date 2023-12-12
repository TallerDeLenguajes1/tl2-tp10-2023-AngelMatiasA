using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using kanban.Models;

namespace kanban.ViewModels
{
    public class CrearTareaViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int idTarea { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Id Tablero")]
        public int idTablero { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Estado")]
        public Estado Estado { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Color")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Id Usuario Asignado")]
        public int idUsuarioAsingnado { get; set; }

        public List<Tablero> tableros { get; set; }
        public List<Usuario> usuarios { get; set; }

        public CrearTareaViewModel()
        {
        }

        public CrearTareaViewModel(List<Tablero> tableros, List<Usuario> usuarios)
        {
            this.tableros = tableros;
            this.usuarios = usuarios;
        }
    }
}
