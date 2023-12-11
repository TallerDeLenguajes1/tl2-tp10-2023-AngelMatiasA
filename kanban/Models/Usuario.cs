using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kanban.ViewModels;

namespace Models; 
public enum Rol{
    admin,
    operador
}
public class Usuario{
 
    public int Id {get; set;}
    public string? Nombre_de_usuario {get; set;}
    public string? Contrasenia {get; set;}
    public Rol? RolUsuario {get; set;}

}