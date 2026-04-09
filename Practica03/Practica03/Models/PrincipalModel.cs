using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica03.Models
{
    public class PrincipalModel
    {

        public int IdCompra { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal Saldo { get; set; }
        public string Estado { get; set; }

    }
}