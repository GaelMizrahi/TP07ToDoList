using Microsoft.AspNetCore.Mvc;
using TP07.Models;

namespace tp07.Controllers
{
    public class AccountController : Controller
    {
    
       
        public IActionResult Login()
        {
            string idStr = HttpContext.Session.GetString("id");
            if (idStr != null) return RedirectToAction("CargarTareas", "Home");
            return View();
        }


    [HttpPost]
        public IActionResult Login(string username, string password)
        {
            
            Usuario usuario = BD.Login(username, password);
            if (usuario == null)
            {
                ViewBag.mensaje = "Usuario o contraseña inválidos.";
                return View();
            }

            
            HttpContext.Session.SetString("id", usuario.ID.ToString());

           

            
            BD.ActualizarFechaLogin(usuario.ID);

            return RedirectToAction("cargarTareas", "Home");
        }
        public IActionResult Registro()
        {
            string idStr = HttpContext.Session.GetString("id");
            if (!string.IsNullOrEmpty(idStr)) return RedirectToAction("CargarTareas", "Home");
            return View();
        }

        
        [HttpPost]

        
       

        
       
        public IActionResult Registro(string username, string password, string nombre, string apellido, string foto)
        {
            
            Usuario usuario = new Usuario
            {
                username = username,
                password = password,
                nombre = nombre,
                apellido = apellido,
                foto = foto,
                ultimoLogin = new DateTime()
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
