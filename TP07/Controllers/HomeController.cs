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
        int id= int.Parse(HttpContext.Session.GetString("id"));
        List<Tarea> listaTareas;
        ViewBag.listaTareas = BD.TraerTareas(id);
        return View("ListaTareas");
    }


   public IActionResult CrearTarea( string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
     int id= int.Parse(HttpContext.Session.GetString("id"));
     Tarea tarea = new tarea(titulo, descripcion, fecha, finalizada, id);  
      BD.CrearTarea(tarea); 
      return View("ListaTareas");
    }
    public IActionResult modificarTarea( string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
    Tarea tarea = new tarea(id, titulo, descripcion, fecha, finalizada);  
      BD.ActualizarTarea(tarea);
      return View ("ListaTareas");
    }
    public IActionResult finalizarTarea(int id)
    {
        BD.FinalizarTarea(id);
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
