using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Controllers
{

    /*Para probar el proyecto tiene que haber registros en rol, targeta, direccion, producto y categoria*/
    /*Los mas inportantes son rol, tarjeta y direccion*/
    public class UsuarioController : Controller
    {
        private IUsuarios iusuario;
        private INumeroCarrito inumerocarrito;
        public UsuarioController(IUsuarios iusuario,INumeroCarrito inumerocarrito)
        {
            this.inumerocarrito = inumerocarrito;
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
            var existe = iusuario.List().Where(x => x.Email == usuario.Email).Select(x => x.UsuarioID).FirstOrDefault();

            if (existe==0) {
                Usuarios us = new Usuarios();
                us.Nick = usuario.Nick;
                us.Email = usuario.Email;
                us.Pass = usuario.Pass;
                us.RolID = 2;  /*el id 2 de la tabla rol identifica al usuario como cliente*/
                us.TarjetaID = 1; /*el id 1 uno de la tabla tarjeta carese de valor y es solo para verificaviones mas adelante */
                us.DireccionID = 1; /*el id 1 uno de la tabla Direccion carese de valor y es solo para verificaviones mas adelante */
                iusuario.Insert(us);




                /*------------------------esta parte de codigo es para asignarle un carrito al usuario----------------------------*/
                var iduser = iusuario.List().Where(x => x.Email == usuario.Email).Select(x => x.UsuarioID).FirstOrDefault();
                NumeroCarritos nc = new NumeroCarritos();
                nc.UsuarioID = iduser;
                inumerocarrito.Insert(nc);
                /*---------------------------------------------------------------------------------------------------------------*/

                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.rep = 1;
                return View();
            }
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
