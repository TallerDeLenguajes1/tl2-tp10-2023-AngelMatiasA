using System; 
using kanban.ViewModels;
namespace kanban.Models; 
public class Tablero{

    public int Id {get; set;}
    public int Id_usuario_propietario {get; set;}
    public string? Nombre {get; set;}
    public string? Descripcion {get;set;}
    
     public Tablero(){

    }

    public Tablero(CrearTableroViewModel tableroVM)
    {   
        
        Id_usuario_propietario = tableroVM.IdUsuarioPropietario;
        Nombre = tableroVM.Nombre;
        Descripcion = tableroVM.Descripcion;
    }

    public Tablero(ActualizarTableroViewModel tableroVM)
    {   
        Id = tableroVM.Id;
        Id_usuario_propietario = tableroVM.IdUsuarioPropietario;
        Nombre = tableroVM.Nombre;
        Descripcion = tableroVM.Descripcion;
    }

}