using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositorios;
namespace Controllers;

public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;
    private TableroRepository TableroRepo;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        TableroRepo = new TableroRepository();
    }

    [HttpGet]
    public IActionResult Index(){
        var Tableros = TableroRepo.MostrarTableros();
        return View(Tableros);
    }

    [HttpGet]
    public IActionResult CrearTablero(){
        return View(new Tablero());
    }

    [HttpPost]
    public IActionResult CrearTablero(Tablero nuevo){
        TableroRepo.CrearTablero(nuevo);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult ActualizarTablero(int idTablero){
        return View(TableroRepo.MostrarPorId(idTablero));
    }



    [HttpPost]
    public IActionResult ActualizarTablero1( Tablero TableroModificar){
        TableroRepo.ModificarTablero( TableroModificar.Id, TableroModificar);
        return RedirectToAction("Index");
    }

    public IActionResult Eliminar(int idTablero){
        TableroRepo.EliminarTablero(idTablero);
        return RedirectToAction("Index");
    }
}