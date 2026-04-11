using Practica03.EntityFramework;
using Practica03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica03.Controllers
{
    public class AbonosController : Controller
    {

        Practica03DBEntities db = new Practica03DBEntities();

        public ActionResult Create()
        {
            var comprasPendientes = db.PrincipalTB
                .Where(c => c.Estado == "Pendiente")
                .ToList();

            ViewBag.Compras = new SelectList(comprasPendientes, "IdCompra", "Descripcion");

            return View();
        }

        public JsonResult ObtenerSaldo(int id)
        {
            var compra = db.PrincipalTB.Find(id);
            return Json(compra.Saldo, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Create(AbonosTB abono)
        {
            var compra = db.PrincipalTB.Find(abono.IdCompra);

            if (abono.MontoAbono > compra.Saldo)
            {
                ModelState.AddModelError("", "El abono no puede ser mayor al saldo");

                // Recarga del dropdown de compras pendientes
                var comprasPendientes = db.PrincipalTB
                    .Where(c => c.Estado == "Pendiente")
                    .ToList();

                ViewBag.Compras = new SelectList(comprasPendientes, "IdCompra", "Descripcion");

                return View(abono);
            }

            db.AbonosTB.Add(abono);

            compra.Saldo -= abono.MontoAbono;

            if (compra.Saldo == 0)
            {
                compra.Estado = "Cancelado";
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Consulta");
        }

    }
}