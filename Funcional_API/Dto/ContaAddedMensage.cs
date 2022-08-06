using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Funcional_API.Dto
{
    public class ContaAddedMensage
    {
        public int conta { get; set; }
        public double saldo { get; set; }
        public double valor { get; set; }
        public string message { get; set; }
    }
}
