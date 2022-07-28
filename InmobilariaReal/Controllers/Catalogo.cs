using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InmobilariaReal.Models;
using InmobilariaReal.Models.ViewModels;

namespace InmobilariaReal.Controllers
{
    public class Catalogo : Controller
    {
        private readonly CasarealContext _DBContext;
        public Catalogo(CasarealContext dBContext)
        {
            _DBContext = dBContext;
        }

        public IActionResult Index()
        {
            List<Producto> lista = _DBContext.Productos.Include(c => c.oCategoria).ToList();
            return View(lista);
            
        }
        //REGISTRA LOS DATOS
        [HttpGet]
        public IActionResult Producto_Detalle(int idProducto)
        {
            ProductoVM oProductoVM = new ProductoVM()
            {
                oProducto =new Producto(),
                oListaCategoria=_DBContext.Categoria.Select(categoria=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                {
                    Text=categoria.Nombre,
                    Value=categoria.Idcategoria.ToString()
                }).ToList()
            };

            if (idProducto != 0)
            {
                oProductoVM.oProducto = _DBContext.Productos.Find(idProducto);
            }


            return View(oProductoVM);
        }
        //GUARDA LOS DATOS Y SE REGISTRA
        [HttpPost]
        public IActionResult Producto_Detalle(ProductoVM oProductoVM)
        {
            if (oProductoVM.oProducto.IdProducto == 0)
            {
                _DBContext.Productos.Add(oProductoVM.oProducto);

            }
            else
            {
                _DBContext.Productos.Update(oProductoVM.oProducto);
            }
           
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Catalogo");
        }

        [HttpGet]
        public IActionResult Eliminar(int idProducto)
        {
            Producto oProducto = _DBContext.Productos.Include(c => c.oCategoria).Where(e => e.IdProducto == idProducto).FirstOrDefault();

            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Eliminar(Producto oProducto)
        {
            _DBContext.Productos.Remove(oProducto);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Catalogo");
        }
    }
}
