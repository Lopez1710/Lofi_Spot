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
            var lista = icarritos.List().Where(x => x.NumeroCarritoID == ElementosEstaticos.NumeroCarrito).Select(x => x).ToList();

            ViewBag.ls = lista;

            return View();
        }
        [HttpGet]
        public IActionResult RealizarCompra()
        {
            var lista = icarritos.List().Where(x => x.NumeroCarritoID == ElementosEstaticos.NumeroCarrito).Select(x => x).ToList();
            decimal total = 0;
            foreach (var datos in lista)
            {
                decimal suma = (datos.Cantidad * datos.Producto.Precio);
                total += suma;
            }

            DetalleDeCompras dtc = new DetalleDeCompras();
            dtc.NumeroCarritoID = ElementosEstaticos.NumeroCarrito;
            dtc.Total = total;

            idetalles.Insert(dtc);
            return Redirect("/Producto/ProductoCarrusel");
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
