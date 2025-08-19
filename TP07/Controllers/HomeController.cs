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
         return RedirectToAction("Login,AccountController");
    }
    public IActionResult cargarTareas()
    {
       string idStr = HttpContext.Session.GetString("id");
          

            int id = int.Parse(idStr);
            List<Tarea> lista = BD.TraerTareas(idUsuario);

            ViewBag.ListaTareas = lista;
            return View("ListaTareas");
    }


   public IActionResult CrearTarea( string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
      string idStr = HttpContext.Session.GetString("id");
           
            return View();
    }
          public IActionResult CrearTareaGuardar(string titulo, string descripcion, DateTime fecha)
        {
            string idStr = HttpContext.Session.GetString("id");
            

            int idUsuario = int.Parse(idStr);

            Tarea tarea = new Tarea
            {
                Titulo = titulo,
                Descripcion = descripcion,
                Fecha = fecha == default ? DateTime.Now : fecha,
                Finalizada = false,
                IdUsuario = idUsuario
            };

            BD.CrearTarea(tarea);
              ViewBag.ListaTareas = BD.TraerTareas(idUsuario);
            return View("ListaTareas");
        }

    public IActionResult modificarTarea( string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
          
        
            string idStr = HttpContext.Session.GetString("id");
            

            Tarea tarea = BD.TraerTareaAEditar(idStr);
            

            return View(tarea);
        
    }
          public IActionResult EditarTareaGuardar(int id, string titulo, string descripcion, DateTime fecha, bool finalizada)
        {
            string idStr = HttpContext.Session.GetString("id");
            

            int idUsuario = int.Parse(idStr);

            Tarea tarea = new Tarea
            {
                Id = id,
                Titulo = titulo,
                Descripcion = descripcion,
                Fecha = fecha == default ? DateTime.Now : fecha,
                Finalizada = finalizada,
                IdUsuario = idUsuario
            };

            BD.ActualizarTarea(tarea);
             ViewBag.ListaTareas = BD.TraerTareas(idUsuario);
            return View("ListaTareas");
        }
    public IActionResult finalizarTarea( )
    {
         string idStr = HttpContext.Session.GetString("id");
           int idUsuario = int.Parse(idStr);
            BD.FinalizarTarea(id);
            
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
