using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositorios;
namespace kanban.Controllers;

public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;
    private TareaRepository TareaRepo;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        TareaRepo = new TareaRepository();
    }

    [HttpGet]
    public IActionResult Index(){
        var Tareas = TareaRepo.MostrarTareas();
        return View(Tareas);
    }

    [HttpGet]
    public IActionResult CrearTarea(){
        return View(new Tarea());
    }

    [HttpGet]
    public IActionResult ActualizarTarea(int idTarea){
        return View(TareaRepo.MostrarPorId(idTarea));
    }
    
    [HttpPost]
    public IActionResult ActualizarTarea( Tarea TareaModificar){
        TareaRepo.ModificarTarea( TareaModificar.Id, TareaModificar);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult CrearTarea(int idTablero,Tarea nuevo){
        TareaRepo.CrearTarea(idTablero, nuevo);
        return RedirectToAction("Index");
    }

   

    public IActionResult Eliminar(int idTarea){
        TareaRepo.EliminarTarea(idTarea);
        return RedirectToAction("Index");
    }
}