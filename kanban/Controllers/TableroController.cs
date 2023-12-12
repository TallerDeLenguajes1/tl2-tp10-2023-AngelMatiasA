using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kanban.Models;
using Repositorios;
using kanban.ViewModels; // Asegúrate de incluir el espacio de nombres para los ViewModels

namespace kanban.Controllers;

public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;
    private TableroRepository TableroRepo;
    private UsuarioRepository UsuarioRepo; // Agregado para obtener la lista de usuarios

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        TableroRepo = new TableroRepository();
        UsuarioRepo = new UsuarioRepository(); // Inicializado el repositorio de usuarios
    }

    [HttpGet]
    public IActionResult Index()
    {
        if (EsAdmin())
        {
            var Tableros = TableroRepo.MostrarTableros();
            
            var TableroVM = new ListarTableroViewModel(Tableros); // Usando ViewModel para listar tableros
            return View(TableroVM);
        }
        else if (EsOperador()) // Método EsOperador agregado
        {
            var tablero = TableroRepo.MostrarPorUsuarioId((int)HttpContext.Session.GetInt32("id"));
            var tableroVM = new ListarTableroViewModel(tablero);
            return View(tableroVM);
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }

    [HttpGet]
    public IActionResult CrearTablero()
    {
        if (EsAdmin())
        {
            return View(new CrearTableroViewModel(UsuarioRepo.MostrarUsuarios())); // Usando ViewModel para crear tablero
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }

    [HttpPost]
    public IActionResult CrearTablero(CrearTableroViewModel tableroVM)
    {
        if (ModelState.IsValid) // Validación del modelo
        {
            var tableroNuevo = new Tablero(tableroVM); // Conversión de ViewModel a Modelo
            TableroRepo.CrearTablero(tableroNuevo);
            return RedirectToAction("Index");
        }
        return View(tableroVM); // Devolver la vista con errores de validación
    }

    [HttpGet]
    public IActionResult ActualizarTablero(int idTablero)
    {
        if (EsAdmin())
        {
            var TableroAMod = TableroRepo.MostrarPorId(idTablero);
            var tableroVM = new ActualizarTableroViewModel(TableroAMod); // Usando ViewModel para modificar tablero
            return View(tableroVM);
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }

    [HttpPost]
    public IActionResult ActualizarTablero(ActualizarTableroViewModel tableroVM)
    {
        if (ModelState.IsValid) // Validación del modelo
        {
            var TableroModificar = new Tablero(tableroVM); // Conversión de ViewModel a Modelo
            TableroRepo.ModificarTablero(TableroModificar.Id, TableroModificar);
            return RedirectToAction("Index");
        }
        return View(tableroVM); // Devolver la vista con errores de validación
    }

    public IActionResult Eliminar(int idTablero)
    {
        TableroRepo.EliminarTablero(idTablero);
        return RedirectToAction("Index");
    }

    private bool EsAdmin()
    {
        if (HttpContext.Session != null && HttpContext.Session.GetString("Rol") == Enum.GetName(typeof(Rol), Rol.admin))
            return true;
        return false;
    }

    private bool EsOperador() // Método EsOperador agregado
    {
        if (HttpContext.Session != null && HttpContext.Session.GetString("Rol") == Enum.GetName(typeof(Rol), Rol.operador))
            return true;
        return false;
    }

    private bool EstaLogueado()
    {
        if (HttpContext.Session.GetString("NombreUsuario") != null)
            return true;

        return false;
    }
}




// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using kanban.Models;
// using Repositorios;
// namespace kanban.Controllers;

// public class TableroController : Controller
// {
//     private readonly ILogger<TableroController> _logger;
//     private TableroRepository TableroRepo;

//     public TableroController(ILogger<TableroController> logger)
//     {
//         _logger = logger;
//         TableroRepo = new TableroRepository();
//     }

//     [HttpGet]
//     public IActionResult Index(){
//         var Tableros = TableroRepo.MostrarTableros();
//         return View(Tableros);
//     }

//     [HttpGet]
//     public IActionResult CrearTablero(){
//         return View(new Tablero());
//     }

//     [HttpPost]
//     public IActionResult CrearTablero(Tablero nuevo){
//         TableroRepo.CrearTablero(nuevo);
//         return RedirectToAction("Index");
//     }
//     [HttpGet]
//     public IActionResult ActualizarTablero(int idTablero){
//         return View(TableroRepo.MostrarPorId(idTablero));
//     }

//     [HttpPost]
//     public IActionResult ActualizarTablero( Tablero TableroModificar){
//         TableroRepo.ModificarTablero( TableroModificar.Id, TableroModificar);
//         return RedirectToAction("Index");
//     }

//     public IActionResult Eliminar(int idTablero){
//         TableroRepo.EliminarTablero(idTablero);
//         return RedirectToAction("Index");
//     }
//        private bool EsAdmin()
//     {
//         if(HttpContext.Session != null && HttpContext.Session.GetString("Rol") == Enum.GetName(Rol.admin)) return true;
//         return false;
//     } 
//     private bool EstaLogueado()
//     {
//             if (HttpContext.Session.GetString("NombreUsuario") != null) 
//                 return true;
                
//             return false;
//     }

// }