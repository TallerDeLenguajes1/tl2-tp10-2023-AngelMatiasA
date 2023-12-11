using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace kanban.ViewModels;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Display(Name = "NombredeUsuario")] 
        public string Nombre {get;set;}        
        
        [Required(ErrorMessage = "Este campo es requerido.")]
        [PasswordPropertyText]
        [Display(Name = "Contrasenia")]
        public string Contrasenia {get;set;}
    }
