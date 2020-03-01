using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using CarCenter.Models;
using CarCenter.Services;

namespace CarCenter.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The factura.
        /// </summary>
        private readonly FacturaService facturaService = new FacturaService();

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>Index.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Facturars the specified cedula.
        /// </summary>
        /// <param name="cedula">The cedula.</param>
        /// <returns>Factura del cliente.</returns>
        [HttpGet]
        public ActionResult Facturar(string cedula)
        {
            Factura factura = facturaService.GetInfoFactura(cedula);

            if (factura.clNombre is null)
            {                
                ViewBag.Message = $"No se encontro información para el cliente con numero de cédula: {cedula}";
                return View("NoData");
            }

            GetTotalValue(factura);
            if (factura.presupuesto > 0 && factura.totalCobro > factura.presupuesto)
            {
                ViewBag.Message = $"El valor total de la factura: {factura.totalCobro.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"))} " +
                    $"supera el presupuesto establecido por el cliente: {factura.presupuesto.ToString("C", CultureInfo.CreateSpecificCulture("es-CO"))}";
                return View("NoData");
            }

            return View(factura);
        }

        /// <summary>
        /// Gets the total value.
        /// </summary>
        /// <param name="factura">The factura.</param>
        private void GetTotalValue(Factura factura)
        {
            factura.total = 0;
            foreach (var mtto in factura.mantenimientos)
            {
                mtto.totalServ = mtto.servicios.Sum(x => x.precio);
                mtto.totalRep = mtto.repuestos.Sum(x => x.totalRepDesc);
                if (mtto.totalRep > 3000000)
                {
                    mtto.totalServ = mtto.totalServ / 2;
                    foreach (var ser in mtto.servicios)
                    {
                        ser.precioDesc = ser.precio / 2;
                    }
                }

                mtto.totalMtto = mtto.totalServ + mtto.totalRep;
                factura.total = factura.total + mtto.totalMtto;
            }

            factura.iva = factura.total * 0.19;
            factura.totalCobro = factura.total + factura.iva;
        }
    }
}