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
    public IActionResult cargarTareas(int idUsuario)
    {
        
        List<Tarea> listaTareas = BD.TraerTareas(idUsuario);
        return View("ListaTareas");
    }


   public IActionResult CrearTareas(int id, string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
      Tarea tarea = new tarea(id, titulo, descripcion, fecha, finalizada);  
      BD.CrearTarea(tarea); 
      return View("CrearTareas");
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
