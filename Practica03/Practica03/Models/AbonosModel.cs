using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Practica03.Models
{
    public class AbonosModel
    {

        public int IdAbono { get; set; }
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoAbono { get; set; }
        public PrincipalModel Principal { get; set; }


    }
}