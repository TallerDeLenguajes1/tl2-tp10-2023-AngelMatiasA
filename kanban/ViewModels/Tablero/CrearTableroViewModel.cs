using System.ComponentModel.DataAnnotations;
using kanban.Models;


namespace kanban.ViewModels;

public class CrearTableroViewModel
{
    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Nombre de tablero")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Usuario Propietario")]
    public int IdUsuarioPropietario { get; set; }

    [Required(ErrorMessage = "Este campo es requerido.")]
    [Display(Name = "Descripcion")]
    public string Descripcion { get; set; }

    public List<UsuarioViewModel> usuarios { get; set; } = new List<UsuarioViewModel>();
    public CrearTableroViewModel(List<Usuario> usuarios)
    {
        foreach (var item in usuarios)
        {
            var usu = new UsuarioViewModel(item);
            this.usuarios.Add(usu);
            
        }
        
    }
    //  public CrearTableroViewModel(Tablero tablero, List<UsuarioViewModel> usuarios, Usuario usuario)
    // {
    //     Nombre = tablero.Nombre;
    //     IdUsuarioPropietario = usuario.Id;
    //     Descripcion = tablero.Descripcion;
    //     this.usuarios = usuarios;
    // }
    public CrearTableroViewModel()
    {
    }
}
