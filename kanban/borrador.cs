// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using Models;
// using Repositorios;
// using ViewModels;
// using Models;
// namespace Controllers;


// public class LoginController : Controller
// {
//     private readonly ILogger<LoginController> _logger;
//     private UsuarioRepository _usuarioRepository;

//     public LoginController(ILogger<LoginController> logger)
//     {
//         _logger = logger;
//         _usuarioRepository = new UsuarioRepository();
//     }

 
//     public IActionResult Index()
//     {
//         return View(new LoginViewModel());
//     }

//      [HttpGet]
//     public IActionResult Index(){
//         return View();
//     }

//     [HttpPost]
//     public IActionResult LoguearUsu(LoginViewModels usuarioIngresado)
//     {
       
//         var usuario = _usuarioRepository.FirstOrDefault(u => u.Nombre_de_usuario == usuarioIngresado.Nombre && u.Contrasenia == usuarioIngresado.Contrasenia);
//         if (usuario == null) return RedirectToAction("Index");
//         InicarSession(usuario);
//         return RedirectToRoute(new {controller = "Tablero", action="Index"});
//     }
//        private void IniciarSession(Usuario usuarioIngresado)
//     {
//         HttpContext.Session.SetString("Usuario", usuarioIngresado.Nombre_de_usuario);
//         HttpContext.Session.SetString("Password", usuarioIngresado.Contrasenia.ToString());
//         HttpContext.Session.SetString("Rol", usuarioIngresado.RolUsuario.ToString());
//     }

// }