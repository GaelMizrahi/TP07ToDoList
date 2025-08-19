using Microsoft.AspNetCore.Mvc;
using TP07.Models;

namespace tp07.Controllers
{
    public class AccountController : Controller
    {
    
        [HttpGet]
        public IActionResult Login()
        {
            string idStr = HttpContext.Session.GetString("id");
            if (idStr == null) return RedirectToAction("CargarTareas", "Home");
            return View();
        }


    
        public IActionResult Login(string username, string password)
        {
            
            Usuario usuario = BD.Login(username, password);
            if (usuario == null)
            {
                ViewBag.mensaje = "Usuario o contraseña inválidos.";
                return View();
            }

            
            HttpContext.Session.SetString("id", usuario.Id.ToString());

           

            
            BD.ActualizarFechaLogin(usuario.Id);

            return RedirectToAction("CargarTareas", "Home");
        }

        
        public IActionResult Registro()
        {
            string id = HttpContext.Session.GetString("id");
           
            return View();
        }

        
       
        public IActionResult Registro(string username, string password, string nombre, string apellido, string foto)
        {
            
            Usuario usuario = new Usuario
            {
                Username = username,
                Password = password,
                Nombre = nombre,
                Apellido = apellido,
                Foto = foto,
                UltimoLogin = null
            };

            
            bool seRegistro = BD.registrar(usuario);
            if (!seRegistro)
            {
                ViewBag.Error = "El username ya existe.";
                return View(usuario);
            }

            

        
            return RedirectToAction("Login");
        }

    
        public IActionResult CerrarSesion()
        {
           
            HttpContext.Session.Remove("id");
            HttpContext.Session.Remove("username");
            HttpContext.Session.Clear();
          ViewBag.Mensaje = "Sesión cerrada correctamente.";
            return RedirectToAction("Login");
        }
    }
}
