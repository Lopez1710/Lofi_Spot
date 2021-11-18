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
    public class ProductoController : Controller
    {
        private IProductos iproducto;
        private ICategorias icategoria;
        public ProductoController(IProductos iproducto,ICategorias icategoria)
        {
            this.iproducto = iproducto;
            this.icategoria = icategoria;
        }
        public IActionResult ProductoCarrusel()
        {
            var categorias = icategoria.List();
            var productos = iproducto.List();
            var idct = productos.GroupBy(x => x.CategoriaID).ToList();

            List<Categorias> ct = new List<Categorias>();
            foreach (var item in idct)
            {
                var dato = categorias.Where(x => x.CategoriaID == item.Key).Select(x => x).FirstOrDefault();
                ct.Add(dato);
            }

            ViewBag.Categoria = ct;
            ViewBag.Producto = productos;
            return View();
            
        }
         public IActionResult ProductoEspesificacion(int id)
        {
            var lista = iproducto.List();
            var Producto = from pro in lista
                           where pro.ProductoID == id
                           select pro;
            List<int> cant = new List<int>();
            for (int i = 1; i <= Producto.Select(x => x.Cantidad).FirstOrDefault(); i++)
            {
                if (cant.Count() <= 9)
                {
                    cant.Add(i);
                }
                else
                {
                    break;
                }

            }
            ViewBag.Cant = cant;
            ViewBag.Pro = Producto;
            return View();
        }
    }

}
