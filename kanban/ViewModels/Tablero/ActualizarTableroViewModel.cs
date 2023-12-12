using System.ComponentModel.DataAnnotations;
using kanban.Models;


namespace kanban.ViewModels;

    public class ActualizarTableroViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Nombre de tablero")]
        public string Nombre{ get; set; }
        public int IdUsuarioPropietario{ get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        public int Id{get;set;}
        public List<UsuarioViewModel> usuarios;
        public ActualizarTableroViewModel(Tablero tablero)
        {
            Nombre = tablero.Nombre;
            Descripcion = tablero.Descripcion;
            Id = tablero.Id;
            IdUsuarioPropietario = tablero.Id_usuario_propietario;
        }

        public ActualizarTableroViewModel()
        {
        }
    }
