using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;
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
        var usuarios = usuarioRepo.MostrarUsuarios();
        return View(usuarios);
    }

    [HttpGet]
    public IActionResult CrearUsuario(){
        return View(new Usuario());
    }

    [HttpGet]
    public IActionResult ActualizarUsuario(int idUsuario){
        return View(usuarioRepo.MostrarUsuarioPorId(idUsuario));
    }

    [HttpPost]
    public IActionResult CrearUsuario(Usuario nuevo){
        usuarioRepo.CrearUsuario(nuevo);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult ActualizarUsuario1( Usuario usuarioModificar){
        usuarioRepo.ModificarUsuario( usuarioModificar.Id, usuarioModificar);
        return RedirectToAction("Index");
    }

    public IActionResult Eliminar(int idUsuario){
        usuarioRepo.EliminarUsuario(idUsuario);
        return RedirectToAction("Index");
    }
}