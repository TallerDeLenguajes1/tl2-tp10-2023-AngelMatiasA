using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kanban.ViewModels;

namespace kanban.Models; 
public enum Rol{
    admin,
    operador
}
public class Usuario{
 
    public int Id {get; set;}
    public string? Nombre_de_usuario {get; set;}
    public string? Contrasenia {get; set;}
    public Rol? RolUsuario {get; set;}

      public Usuario(CrearUsuarioViewModel usuario){
        Nombre_de_usuario = usuario.Nombre;
        Contrasenia = usuario.Contrasenia;
        RolUsuario = usuario.RolUsuario;
    }

    public Usuario(ActualizarUsuarioViewModel usuario){
        Id = usuario.Id;
        Nombre_de_usuario = usuario.Nombre;
        Contrasenia = usuario.Contrasenia;
        RolUsuario = usuario.RolUsuario;
    }


    public Usuario(){
        
    }



}