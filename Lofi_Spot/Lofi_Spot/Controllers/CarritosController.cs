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

        public CarritosController(ICarritos icarritos)
        {
            this.icarritos = icarritos;
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
