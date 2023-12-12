namespace kanban.ViewModels;

using System.ComponentModel.DataAnnotations;
using kanban.Models;

public class ActualizarUsuarioViewModel
{
    public int Id {get; set;}

    [Required(ErrorMessage = "Este campo es requerido")]
    [Display(Name = "Nombre")]
    public string? Nombre { get ; set ; }

    [Display(Name = "Contraseña")]
    public string? Contrasenia { get; set ; }

    [Display(Name = "Rol")]
    public Rol? RolUsuario { get ; set ; }

    public ActualizarUsuarioViewModel(Usuario usuario){
        Id = usuario.Id;
        Nombre = usuario.Nombre_de_usuario;
        Contrasenia = usuario.Contrasenia;
        RolUsuario = usuario.RolUsuario;
    }

    public ActualizarUsuarioViewModel(){

    }
}