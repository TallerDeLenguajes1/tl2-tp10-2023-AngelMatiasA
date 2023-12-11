using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kanban.Models;
using Repositorios;
using kanban.ViewModels;
namespace kanban.Controllers;


public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;
    private UsuarioRepository _usuarioRepository;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
        _usuarioRepository = new UsuarioRepository();
    }

 
    public IActionResult Index()
    {
        return View(new LoginViewModel());
    }

    //  [HttpGet]
    // public IActionResult Index(){
    //     return View();
    // }

    [HttpPost]
    public IActionResult LoguearUsu(LoginViewModel usuarioIngresado)
    {
       
        var usuarios = _usuarioRepository.MostrarUsuarios();
        var usuario = usuarios.FirstOrDefault(u => u.Nombre_de_usuario == usuarioIngresado.Nombre && u.Contrasenia == usuarioIngresado.Contrasenia);
        if (usuario == null) return RedirectToRoute(new {controller = "Home", action="Index"});
        IniciarSession(usuario);
        return RedirectToRoute(new {controller = "Tablero", action="Index"});
    }
       private void IniciarSession(Usuario usuarioIngresado)
    {
        HttpContext.Session.SetString("NombreUsuario", usuarioIngresado.Nombre_de_usuario);
        HttpContext.Session.SetString("Contrasenia", usuarioIngresado.Contrasenia.ToString());
        HttpContext.Session.SetString("Rol", usuarioIngresado.RolUsuario.ToString());
    }

}