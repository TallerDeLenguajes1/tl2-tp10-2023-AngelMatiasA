namespace kanban.ViewModels;
using kanban.Models;

public class TableroViewModel
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int IdUsuarioPropietario { get; set; }
    public string NombrePropietario { get; set; }
    public TableroViewModel(){

    }
      public TableroViewModel(Tablero tablero)
        {
            IdUsuarioPropietario = tablero.Id_usuario_propietario;
            Nombre = tablero.Nombre;
            Descripcion = tablero.Descripcion;
            Id = tablero.Id;
        }

    public TableroViewModel(Tablero tablero, UsuarioViewModel usuarioVM)
    {
        Id = tablero.Id;
        Nombre = tablero.Nombre;
        Descripcion = tablero.Descripcion;
        IdUsuarioPropietario = tablero.Id_usuario_propietario;
        NombrePropietario = usuarioVM.Nombre;
    }


}