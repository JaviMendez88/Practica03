using Practica03.EntityFramework;
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

        Practica03DBEntities db = new Practica03DBEntities();

        public ActionResult Index()
        {
            var compras = db.PrincipalTB
                .OrderBy(c => c.Estado == "Pendiente" ? 0 : 1)
                .ToList();

            return View(compras);
        }

    }
}