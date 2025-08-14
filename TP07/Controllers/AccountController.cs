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
    public  IActionResult Login(string UserName, string Password)
    {
        Usuario usuario = BD.Login(username, password);
        if(usuario.ID != null)
        {
         HttpContext.Session.SetString("id", id.ToString());
         return View("listaTareas");
        }
        else {return View("Login");}
    }
    public  IActionResult Registro(string UserName, string Password, string Nombre, string Apellido, string Foto)
    {           
        Usuario usuario = new usuario(UserName, Password, Nombre, Apellido, Foto);
        bool seRegistro = BD.registrar(usuario);
        return View("Login");       
    }

     public  IActionResult CerrarSesion(string UserName, string Password)
    {
        Usuario usuario = BD.Login(username, password);
        usuario.ID = 0;
         HttpContext.Session.SetString("id", id.ToString());
         return View("Login");
    }


}