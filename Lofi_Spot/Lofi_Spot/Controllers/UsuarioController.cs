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
        private ITarjetas itarjetas;
        private IDirecciones idirecciones;

        public UsuarioController(IUsuarios iusuario, INumeroCarrito inumerocarrito, ITarjetas itarjetas, IDirecciones idirecciones)
        {
            this.inumerocarrito = inumerocarrito;
            this.iusuario = iusuario;
            this.itarjetas = itarjetas;
            this.idirecciones = idirecciones;
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Login(int id)
        {
            ElementosEstaticos.IDProducto = id;
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Usuarios usuario)
        {
            var existe = iusuario.List().Where(x => (x.Email == usuario.Email || x.Nick == usuario.Nick)).Select(x => x.UsuarioID).FirstOrDefault();

            if (existe == 0) {
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
                var email = iusuario.List().Where(x => x.Email == usuario.Email).Select(x => x.UsuarioID).FirstOrDefault();
                var Nick = iusuario.List().Where(x => x.Nick == usuario.Nick).Select(x => x.UsuarioID).FirstOrDefault();

                if (Nick != 0 && email != 0)
                {
                    ViewBag.nick = 2;
                    ViewBag.email = 1;
                }
                else if (Nick != 0)
                {
                    ViewBag.nick = 2;
                }
                else if (email != 0)
                {
                    ViewBag.email = 1;
                }

                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(string User, string Pass)
        {

            var Ncarrito = inumerocarrito.List();
            var Lista = iusuario.List();
            var autentificacion = (from usuario in Lista
                                   where ((usuario.Email == User || usuario.Nick == User)
                                   & usuario.Pass == Pass)
                                   select usuario).ToList();

            ElementosEstaticos.usuario = autentificacion;

            var IDUser = autentificacion.Select(x => x.UsuarioID).FirstOrDefault();
            var Tarjeta = autentificacion.Select(x => x.TarjetaID).FirstOrDefault();
            var Rol = autentificacion.Select(x => x.RolID).FirstOrDefault();
            var Direccion = autentificacion.Select(x => x.DireccionID).FirstOrDefault();
            var CarritoN = Ncarrito.Where(x => x.UsuarioID == IDUser).Select(x => x.NumeroCarritoID).FirstOrDefault();

            if (IDUser != 0)
            {
                if (ElementosEstaticos.IDProducto != 0)
                {
                    ElementosEstaticos.IDUser = IDUser;
                    ElementosEstaticos.Tarjeta = Tarjeta;
                    ElementosEstaticos.Rol = Rol;
                    ElementosEstaticos.Direccion = Direccion;
                    ElementosEstaticos.NumeroCarrito = CarritoN;

                    return Redirect("/Producto/ProductoEspesificacion/" + ElementosEstaticos.IDProducto);
                }
                else {
                    ElementosEstaticos.IDUser = IDUser;
                    ElementosEstaticos.Tarjeta = Tarjeta;
                    ElementosEstaticos.Rol = Rol;
                    ElementosEstaticos.Direccion = Direccion;
                    ElementosEstaticos.NumeroCarrito = CarritoN;

                    return Redirect("/Producto/ProductoCarrusel");
                }
            }
            else
            {
                var existe = iusuario.List().Where(x => (x.Email == User || x.Nick == User)).Select(x => x).ToList();
                ViewBag.error = existe.Count();

                return View();
            }
        }

        public IActionResult CTarjeta()
        {
            if (ElementosEstaticos.IDUser == 0)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CTarjeta(string Tarjeta, string Mes, string Year, string CVV, string Nombre)
        {

            string fecha = Mes + "/" + Year;
            DateTime F = Convert.ToDateTime(fecha);

            var usuario = ElementosEstaticos.usuario;
            var existe = itarjetas.List().Where(x => x.TarjetaID == Convert.ToInt32(Tarjeta) & x.Fecha == F & x.CVV == Convert.ToInt32(CVV)).Select(x => x).ToList();

            if (existe.Count() != 0)
            {
                Usuarios user = new Usuarios();
                user.UsuarioID = ElementosEstaticos.IDUser;
                user.Nick = usuario.Select(x => x.Nick).FirstOrDefault();
                user.Email = usuario.Select(x => x.Email).FirstOrDefault();
                user.Pass = usuario.Select(x => x.Pass).FirstOrDefault();
                user.TarjetaID = Convert.ToInt32(Tarjeta);
                user.DireccionID = 1;
                user.RolID = ElementosEstaticos.Rol;

                iusuario.Update(user);

                ElementosEstaticos.Tarjeta = Convert.ToInt32(Tarjeta);

                return Redirect("/Carritos/Listado");
            }
            else
            {
                ViewBag.Error = 1;
                return View();
            }

        }
        public IActionResult Direccion()
        {
            if (ElementosEstaticos.IDUser != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public IActionResult Direccion(string Departamento, string Localidad, int CP)
        {
            if (ElementosEstaticos.IDUser != 0)
            {
                var existe = idirecciones.List().Where(x => x.Departamento == Departamento & x.Localidad == Localidad & x.CP == CP).Select(x => x).ToList();

                
                if (existe.Count() != 0)
                {
                    Usuarios us = new Usuarios();

                    us.UsuarioID = ElementosEstaticos.usuario.Select(x => x.UsuarioID).FirstOrDefault();
                    us.Nick = ElementosEstaticos.usuario.Select(x => x.Nick).FirstOrDefault();
                    us.Email = ElementosEstaticos.usuario.Select(x => x.Email).FirstOrDefault();
                    us.Pass = ElementosEstaticos.usuario.Select(x => x.Pass).FirstOrDefault();
                    us.TarjetaID = ElementosEstaticos.usuario.Select(x => x.TarjetaID).FirstOrDefault();
                    us.RolID = ElementosEstaticos.usuario.Select(x => x.RolID).FirstOrDefault();
                    us.DireccionID = existe.Select(x => x.DireccionID).FirstOrDefault();
                    iusuario.Update(us);
                    ElementosEstaticos.Direccion = existe.Select(x => x.DireccionID).FirstOrDefault();

                    var usuario = iusuario.List().Where(x => x.UsuarioID == ElementosEstaticos.IDUser).Select(x => x).ToList();
                    ElementosEstaticos.usuario = usuario;

                    return Redirect("/Carritos/Listado");
                }
                else
                {
                    Direcciones direc = new Direcciones();

                    direc.Departamento = Departamento;
                    direc.Localidad = Localidad;
                    direc.CP = CP;

                    idirecciones.Insert(direc);

                    var direccion = idirecciones.List().Where(x => x.Departamento == Departamento & x.Localidad == Localidad & x.CP == CP).Select(x => x).ToList();

                    Usuarios us = new Usuarios();

                    us.UsuarioID = ElementosEstaticos.usuario.Select(x => x.UsuarioID).FirstOrDefault();
                    us.Nick = ElementosEstaticos.usuario.Select(x => x.Nick).FirstOrDefault();
                    us.Email = ElementosEstaticos.usuario.Select(x => x.Email).FirstOrDefault();
                    us.Pass = ElementosEstaticos.usuario.Select(x => x.Pass).FirstOrDefault();
                    us.TarjetaID = ElementosEstaticos.usuario.Select(x => x.TarjetaID).FirstOrDefault();
                    us.RolID = ElementosEstaticos.usuario.Select(x => x.RolID).FirstOrDefault();
                    us.DireccionID = direccion.Select(x => x.DireccionID).FirstOrDefault();
                    iusuario.Update(us);
                    ElementosEstaticos.Direccion = direccion.Select(x => x.DireccionID).FirstOrDefault();

                    var usuario = iusuario.List().Where(x => x.UsuarioID == ElementosEstaticos.IDUser).Select(x => x).ToList();
                    ElementosEstaticos.usuario = usuario;

                    return Redirect("/Carritos/Listado");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult CerrarSesion()
        {
            ElementosEstaticos.IDUser = 0;
            ElementosEstaticos.Tarjeta = 0;
            ElementosEstaticos.Direccion = 0;
            ElementosEstaticos.Rol = 0;

            ElementosEstaticos.usuario = null;
            ElementosEstaticos.carritos = null;
            ElementosEstaticos.DF = null;

            return RedirectToAction("Login");
        }

        public IActionResult Terminos()
        { 
            return View();
        }
    }
}
