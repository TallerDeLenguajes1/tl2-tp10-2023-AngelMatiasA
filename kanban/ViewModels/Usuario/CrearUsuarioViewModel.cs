namespace kanban.ViewModels;

using System.ComponentModel.DataAnnotations;
using kanban.Models;

public class CrearUsuarioViewModel
{

    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Nombre de usuario")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Contraseña")]
    public string? Contrasenia { get; set; }

    [Display(Name = "Rol")]
    public Rol? RolUsuario { get; set; }

 public CrearUsuarioViewModel(Usuario usuario)
        {
            Nombre = usuario.Nombre_de_usuario;
            Contrasenia = usuario.Contrasenia;
            RolUsuario = usuario.RolUsuario;
        }

        public CrearUsuarioViewModel()
        {
        }

}