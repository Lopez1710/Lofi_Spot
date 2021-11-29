using Lofi_Spot.Dominio;
using Lofi_Spot.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Controllers
{
    public class ReciboController : Controller
    {
        private IFactura ifactura;

        public ReciboController(IFactura ifactura) 
        {
            this.ifactura = ifactura;
        }

        public IActionResult Recibo()
        {
            ViewBag.NF = ElementosEstaticos.NF;
            ViewBag.Df = ElementosEstaticos.DF;
            ViewBag.Us = ElementosEstaticos.usuario;
            ViewBag.F = ElementosEstaticos.Fecha;
            ViewBag.H = ElementosEstaticos.Hora;

            return View();
        }
    }
}
