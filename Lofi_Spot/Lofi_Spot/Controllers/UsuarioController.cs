using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarios iusuario;
        public UsuarioController(IUsuarios iusuario)
        {
            this.iusuario = iusuario;
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Usuarios usuario)
        {
            Usuarios us = new Usuarios();
            us.Nick = usuario.Nick;
            us.Email = usuario.Email;
            us.Pass = usuario.Pass;
            us.RolID = 2;
            iusuario.Insert(us);
            return View();
        }

        [HttpPost]
        public IActionResult Login(string User, string Pass)
        {
            var Lista = iusuario.List();
            foreach (var iteracion in Lista)
            {
                if (iteracion.Email.Equals(User) && iteracion.Pass.Equals(Pass))
                {
                    Redirect("/Home/Index");
                }
                else
                {
                    return View("Registro");
                }

            }

            return View();
        }
    }
}
