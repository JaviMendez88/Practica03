using Practica03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica03.Controllers
{

    public class ConsultaController : Controller
    {

        public ActionResult Index()
        {
            // Temporal mientras se construye la BD

            var compras = new List<PrincipalModel>
        {
            new PrincipalModel
            {
                IdCompra = 1,
                Descripcion = "Compra 1",
                Saldo = 500,
                Estado = "Pendiente"
            },
            new PrincipalModel
            {
                IdCompra = 2,
                Descripcion = "Compra 2",
                Saldo = 0,
                Estado = "Cancelado"
            }
        };

            var ordenado = compras
                .OrderBy(c => c.Estado == "Pendiente" ? 0 : 1)
                .ToList();

            return View(ordenado);
        }
    }

}