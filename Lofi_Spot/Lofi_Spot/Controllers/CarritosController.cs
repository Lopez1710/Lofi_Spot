using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Controllers
{
    public class CarritosController : Controller
    {
        private ICarritos icarritos;
        private IDetallesDeCompras idetalles;

        public CarritosController(ICarritos icarritos, IDetallesDeCompras idetalles)
        {
            this.icarritos = icarritos;
            this.idetalles = idetalles;
        }

        public IActionResult Listado()
        {
            if (ElementosEstaticos.IDUser != 0) {
                var lista = icarritos.List().Where(x => (x.NumeroCarritoID == ElementosEstaticos.NumeroCarrito) & x.estado == 1).Select(x => x).ToList();
                ElementosEstaticos.carritos = lista;
                ViewBag.ls = lista;

                return View();
            }
            else
            {
                return Redirect("/Usuario/Login");
            }
        }
        [HttpGet]
        public IActionResult RealizarCompra()
        {
            if (ElementosEstaticos.Direccion != 1 & ElementosEstaticos.Tarjeta != 1) {
                decimal total = 0;
                foreach (var datos in ElementosEstaticos.carritos)
                {
                    decimal suma = (datos.Cantidad * datos.Producto.Precio);
                    total += suma;

                    Carritos cr = new Carritos();
                    cr.CarritoID = datos.CarritoID;
                    cr.Cantidad = datos.Cantidad;
                    cr.ProductoID = datos.ProductoID;
                    cr.NumeroCarritoID = datos.NumeroCarritoID;
                    cr.estado = 0;
                    icarritos.Update(cr);
                }


                DetalleDeCompras dtc = new DetalleDeCompras();
                dtc.NumeroCarritoID = ElementosEstaticos.NumeroCarrito;
                dtc.Total = total;
                idetalles.Insert(dtc);
                return Redirect("/Producto/ProductoCarrusel");
            }
            else if (ElementosEstaticos.Direccion == 1)
            {
                return Redirect("/Direccion/Datos");
            }
            else if (ElementosEstaticos.Tarjeta == 1 )
            {
                return Redirect("/Tarjeta/Datos");
            }
            else
            {
                return Redirect("/Usuario/Login");
            }
        }
     
        
        [HttpPost]
        public IActionResult GuardarCarrito(Carritos carritos)
        {
            int ProductoEvaluado = carritos.ProductoID;
            if (ElementosEstaticos.IDUser != 0) 
            {

                Carritos Car = new Carritos();

                Car.Cantidad = carritos.Cantidad;
                Car.ProductoID = carritos.ProductoID;
                Car.NumeroCarritoID = ElementosEstaticos.NumeroCarrito;
                Car.estado = 1;//El numero significa el estado en que esta en espera la compra.
                icarritos.Insert(Car);

                return Redirect("/Producto/ProductoCarrusel");
            }
            else
            {
                return Redirect("/Usuario/Login/"+ProductoEvaluado);
            }
        }
    }
}
