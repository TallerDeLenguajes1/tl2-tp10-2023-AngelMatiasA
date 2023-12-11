using kanban.Models;
namespace kanban.ViewModels;

public class UsuarioViewModel
{
    public int? Id { get; set; }
    public string? Nombre { get; set; }
    public Rol? RolUsuario { get; set; }

    public UsuarioViewModel(){

    }
    public UsuarioViewModel(Usuario usuario){
        this.Id = usuario.Id;
        this.Nombre = usuario.Nombre_de_usuario;
        this.RolUsuario = usuario.RolUsuario;
    }

    
}