using Lofi_Spot.Dominio;
using Lofi_Spot.Models;
using Lofi_Spot.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lofi_Spot.Controllers
{
    /*Para probar el proyecto tiene que haber registros en rol, targeta, direccion, producto y categoria*/
    /*Los mas inportantes son rol, tarjeta y direccion*/
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUsuarios iusuarios;
        private IProductos iproductos;
        private ICategorias icategorias;

        public HomeController(ILogger<HomeController> logger, IUsuarios iusuarios,IProductos iproductos, ICategorias icategorias)
        {
            _logger = logger;
            this.iusuarios = iusuarios;
            this.iproductos = iproductos;
            this.icategorias = icategorias;
        }

        public IActionResult Index()
        {
            var usuario = iusuarios.List().Where(x => x.UsuarioID == ElementosEstaticos.IDUser).Select(x => x).ToList();
            var producto = iproductos.List().ToList();
            var categorias = icategorias.List().ToList();
            var idct = producto.GroupBy(x => x.CategoriaID).ToList();

            List<Productos> pd = new List<Productos>();

            foreach (var item in producto)
            {
                if (pd.Count()<=3) 
                {
                    pd.Add(item);

                }
                else
                {
                    break;
                }
            }

            List<Categorias> ct = new List<Categorias>();

            foreach (var item in idct)
            {
                if (ct.Count() <= 2)
                {   
                    var dato = categorias.Where(x => x.CategoriaID == item.Key).Select(x => x).FirstOrDefault();
                    ct.Add(dato);
                }
                else
                {
                    break;
                }
            }

            ViewBag.categorias = ct;
            ViewBag.producto = pd;
            ViewBag.usercount = usuario.Count();
            ViewBag.user = usuario;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
