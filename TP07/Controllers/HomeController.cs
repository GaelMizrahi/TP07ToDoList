using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07.Models;

namespace tp07.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
          return RedirectToAction("Login", "Account");    }
    public IActionResult cargarTareas()
    {
       string idStr = HttpContext.Session.GetString("id");
          

            int id = int.Parse(idStr);
            List<Tarea> lista = BD.TraerTareas(id);

            ViewBag.ListaTareas = lista;
            return View("ListaTareas");
    }


   public IActionResult CrearTareaGuardar( string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
    
           
            return View();
    }
    [HttpPost]
          public IActionResult CrearTareaGuardar(string titulo, string descripcion, DateTime fecha)
        {
            string idStr = HttpContext.Session.GetString("id");
            

            int idUsuario = int.Parse(idStr);

            Tarea tarea = new Tarea
            {
                titulo = titulo,
                descripcion = descripcion,
                fecha = fecha == default ? DateTime.Now : fecha,
                finalizada = false,
                idUsuario = idUsuario
            };

            BD.CrearTarea(tarea);
              ViewBag.ListaTareas = BD.TraerTareas(idUsuario);
            return View("ListaTareas");
        }
           public IActionResult EditarTareaGuardar ()
           {
                Tarea tarea = BD.TraerTarea(id);
    return View("editarTareas", tarea);

           }

          [HttpPost]
          public IActionResult EditarTareaGuardar( string titulo, string descripcion, DateTime fecha, bool finalizada)
        {
            string idStr = HttpContext.Session.GetString("id");
            

            int idUsuario = int.Parse(idStr);

            Tarea tarea = new Tarea
            {
                  ID = id,
                titulo = titulo,
                descripcion = descripcion,
                fecha = fecha == default ? DateTime.Now : fecha,
                finalizada = finalizada,
                idUsuario = idUsuario
            };

            BD.ActualizarTarea(tarea);
             ViewBag.ListaTareas = BD.TraerTareas(idUsuario);
            return View("ListaTareas");
        }
    public IActionResult finalizarTarea( )
    {
            BD.FinalizarTarea(id);
    string idStr = HttpContext.Session.GetString("id");
    int idUsuario = int.Parse(idStr);
    ViewBag.ListaTareas = BD.TraerTareas(idUsuario);
    return View("ListaTareas");

      
    }
         public IActionResult EliminarTarea(int id)
        {
            string idStr = HttpContext.Session.GetString("id");
        

            int idUsuario = int.Parse(idStr);
            BD.EliminarTarea(id);
            
            ViewBag.ListaTareas = BD.TraerTareas(idUsuario);
            return View("ListaTareas");
        }

        
        public IActionResult Privacy()
    {
        return View();
    }


}
