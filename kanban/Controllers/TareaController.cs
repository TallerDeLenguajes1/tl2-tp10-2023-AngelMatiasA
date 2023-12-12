using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kanban.Models;
using Repositorios;
using kanban.ViewModels; // Asegúrate de incluir el espacio de nombres para los ViewModels

namespace kanban.Controllers;

public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;
    private TareaRepository TareaRepo;
    private UsuarioRepository UsuarioRepo; // Agregado para obtener la lista de usuarios
    private TableroRepository TableroRepo; // Agregado para obtener la lista de tableros

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        TareaRepo = new TareaRepository();
        UsuarioRepo = new UsuarioRepository(); // Inicializado el repositorio de usuarios
        TableroRepo = new TableroRepository(); // Inicializado el repositorio de tableros
    }

    [HttpGet]
    public IActionResult Index()
    {
        if (EsAdmin())
        {
            var tareas = TareaRepo.MostrarTareas();
            var tareasVM = new ListarTareasViewModel(tareas); // Usando ViewModel para listar tareas
            return View(tareasVM);
        }
        else if (EsOperador()) // Método EsOperador agregado
        {
            var tareas = TareaRepo.MostrarTareasPorUsuario((int)HttpContext.Session.GetInt32("id")!);
            var tareaVM = new ListarTareasViewModel(tareas);
            return View(tareaVM);
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }

    [HttpGet]
    public IActionResult CrearTarea()
    {
        if (EsAdmin())
        {
            var viewModel = new CrearTareaViewModel(TableroRepo.MostrarTableros(), UsuarioRepo.MostrarUsuarios()); // Usando ViewModel para crear tarea
            return View(viewModel);
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }

    [HttpPost]
    public IActionResult CrearTarea(CrearTareaViewModel tareaVM)
    {
        if (EsAdmin() && ModelState.IsValid) // Validación del modelo
        {
            var tareaNueva = new Tarea(tareaVM); // Conversión de ViewModel a Modelo
            TareaRepo.CrearTarea(tareaNueva.Id_Tablero, tareaNueva);
            return RedirectToAction("Index");
        }
        return View(tareaVM); // Devolver la vista con errores de validación
    }

    [HttpGet]
    public IActionResult ActualizarTarea(int idTarea)
    {
        if (EsAdmin())
        {
            var tareaAMod = TareaRepo.MostrarPorId(idTarea);
            var tareaVM = new ModificarTareaViewModel(tareaAMod); // Usando ViewModel para modificar tarea
            return View(tareaVM);
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
    }

    [HttpPost]
    public IActionResult ActualizarTarea(ModificarTareaViewModel tareaVM)
    {
        if (EsAdmin() && ModelState.IsValid) // Validación del modelo
        {
            var tareaModificar = new Tarea(tareaVM); // Conversión de ViewModel a Modelo
            TareaRepo.ModificarTarea(tareaModificar.Id, tareaModificar);
            return RedirectToAction("Index");
        }
        return View(tareaVM); // Devolver la vista con errores de validación
    }

    public IActionResult Eliminar(int idTarea)
    {
        if (EsAdmin())
        {
            TareaRepo.EliminarTarea(idTarea);
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }
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

// public class TareaController : Controller
// {
//     private readonly ILogger<TareaController> _logger;
//     private TareaRepository TareaRepo;

//     public TareaController(ILogger<TareaController> logger)
//     {
//         _logger = logger;
//         TareaRepo = new TareaRepository();
//     }

//     [HttpGet]
//     public IActionResult Index(){
//         var tareasAux = new List<Tarea>();

//         var tareas = TareaRepo.MostrarTareas();
//         if(tareas == null) return View(tareasAux);
//         return View(tareas);
//     }

//     [HttpGet]
//     public IActionResult CrearTarea(){
//         return View(new Tarea());
//     }

//     [HttpGet]
//     public IActionResult ActualizarTarea(int idTarea){
//         return View(TareaRepo.MostrarPorId(idTarea));
//     }
    
//     [HttpPost]
//     public IActionResult ActualizarTarea( Tarea TareaModificar){
//         TareaRepo.ModificarTarea( TareaModificar.Id, TareaModificar);
//         return RedirectToAction("Index");
//     }

//     [HttpPost]
//     public IActionResult CrearTarea(int idTablero,Tarea nuevo){
//         TareaRepo.CrearTarea(idTablero, nuevo);
//         return RedirectToAction("Index");
//     }

   

//     public IActionResult Eliminar(int idTarea){
//         TareaRepo.EliminarTarea(idTarea);
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