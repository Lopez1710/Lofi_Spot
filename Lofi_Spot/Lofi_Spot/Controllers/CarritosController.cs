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
        private IDetalleFactura idetalleFactura;
        private IFactura ifactura;

        public CarritosController(ICarritos icarritos, IDetallesDeCompras idetalles, IDetalleFactura idetalleFactura, IFactura ifactura)
        {
            this.icarritos = icarritos;
            this.idetalles = idetalles;
            this.idetalleFactura = idetalleFactura;
            this.ifactura = ifactura;
        }

        public IActionResult Listado()
        {
            if (ElementosEstaticos.IDUser != 0) {
                var lista = icarritos.List().Where(x => (x.NumeroCarritoID == ElementosEstaticos.NumeroCarrito) & x.estado == 1).Select(x => x).ToList();
                ElementosEstaticos.carritos = lista;
                ViewBag.ls = lista;
                ViewBag.CB = ElementosEstaticos.comprobacion;

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
                if (ElementosEstaticos.carritos.Count() != 0)
                {
                    decimal total = 0;
                    Factura F = new Factura();

                    F.Fecha = DateTime.Now;
                    F.NumeroCarritoID = ElementosEstaticos.NumeroCarrito;

                    ifactura.insert(F);

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
                        cr.Fecha = DateTime.Now;
                        icarritos.Update(cr);
                    }

                    var carrito = ElementosEstaticos.carritos;
                    DetalleDeCompras dtc = new DetalleDeCompras();
                    dtc.NumeroCarritoID = ElementosEstaticos.NumeroCarrito;
                    dtc.Total = total;
                    idetalles.Insert(dtc);

                    var nf = ifactura.Listado().Where(x => x.NumeroCarritoID == ElementosEstaticos.NumeroCarrito).OrderByDescending(x => x.Fecha).Select(x => x).FirstOrDefault();
                    ElementosEstaticos.NF = nf.FacturaID;
                    ElementosEstaticos.Fecha = nf.Fecha.ToShortDateString();
                    ElementosEstaticos.Hora = nf.Fecha.ToShortTimeString();

                    foreach (var datos in ElementosEstaticos.carritos)
                    {
                        DetalleFactura factura = new DetalleFactura();

                        factura.Cantidad = datos.Cantidad;
                        factura.Precio = datos.Producto.Precio;
                        factura.Producto = datos.Producto.Producto;
                        factura.FacturaID = nf.FacturaID;

                        idetalleFactura.insert(factura);
                    }
                    var DF = idetalleFactura.Listado().Where(x => x.FacturaID == nf.FacturaID).Select(x => x).ToList();
                    ElementosEstaticos.DF = DF;
                    return Redirect("/Recibo/Recibo");
                }
                else 
                {
                    ElementosEstaticos.comprobacion = 1;
                    return RedirectToAction("Listado");
                }
            }
            else if (ElementosEstaticos.Tarjeta == 1)
            {
                return Redirect("/Usuario/CTarjeta");
            }
            else if (ElementosEstaticos.Direccion == 1)
            {
                return Redirect("/Usuario/Direccion");
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
        [HttpPost]
        public IActionResult EliminarP(int id)
        {
           
            var elm = ElementosEstaticos.carritos.Where(x => x.CarritoID == id).Select(x=>x).ToList();

            Carritos car = new Carritos();

            car.CarritoID = elm.Select(x => x.CarritoID).FirstOrDefault();
            car.Cantidad = elm.Select(x => x.Cantidad).FirstOrDefault();
            car.ProductoID = elm.Select(x => x.ProductoID).FirstOrDefault();
            car.NumeroCarritoID = elm.Select(x => x.NumeroCarritoID).FirstOrDefault();
            car.estado = elm.Select(x => x.estado).FirstOrDefault();
            car.Fecha = elm.Select(x => x.Fecha).FirstOrDefault();

            icarritos.Delete(car);



            return RedirectToAction("Listado");
        }
    }
}
