using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kanban.Models;
using kanban.ViewModels;
using Repositorios;
namespace kanban.Controllers;

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private UsuarioRepository usuarioRepo;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepo = new UsuarioRepository();
    }

    [HttpGet]
    public IActionResult Index(){
          if(!EstaLogueado()) return RedirectToRoute(new {controller = "Login", action="Index"});
        //if(!EsAdmin()) return RedirectToRoute(new {controller = "Login", action="Index"});
        var usuarios = usuarioRepo.MostrarUsuarios();
        return View(usuarios);
    }

    [HttpGet]
    public IActionResult CrearUsuario(){
          if(!EstaLogueado()) return RedirectToRoute(new {controller = "Login", action="Index"});
        if(!EsAdmin()) return RedirectToAction("Index");
        return View(new CrearUsuarioViewModel());
    }

    [HttpGet]
    public IActionResult ActualizarUsuario(int idUsuario){
        if(!EsAdmin()) return RedirectToRoute(new {controller = "Home", action="Index"});

        var usu = usuarioRepo.MostrarUsuarioPorId(idUsuario);
        return View(new ActualizarUsuarioViewModel(usu));
    }

    [HttpPost]
    public IActionResult CrearUsuario(CrearUsuarioViewModel nuevo){
        if(!EsAdmin()) return RedirectToRoute(new {controller = "Home", action="Index"});
        if(!ModelState.IsValid) return RedirectToAction("CrearUsuario");
        usuarioRepo.CrearUsuario(new Usuario(nuevo));
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult ActualizarUsuario1( ActualizarUsuarioViewModel usuarioModificar){
        if(!EsAdmin()) return RedirectToAction("Index");
        if(!ModelState.IsValid) return RedirectToAction("ActualizarUsuario");
        var usu = new Usuario(usuarioModificar);
        usuarioRepo.ModificarUsuario( usu.Id, usu);
        return RedirectToAction("Index");
    }

    public IActionResult Eliminar(int idUsuario){
        if(!EsAdmin()) return RedirectToRoute(new {controller = "Home", action="Index"});
        usuarioRepo.EliminarUsuario(idUsuario);
        return RedirectToAction("Index");
    }
     private bool EsAdmin()
    {
        if(HttpContext.Session != null && HttpContext.Session.GetString("Rol") == Enum.GetName(Rol.admin)) return true;
        return false;
    } 
    private bool EstaLogueado()
    {
            if (HttpContext.Session.GetString("NombreUsuario") != null) 
                return true;
                
            return false;
    }

}