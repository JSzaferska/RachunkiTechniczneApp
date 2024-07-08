using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RachunkiTechniczneApp.DTOs
{
    internal class InwenturaDto
    {
        public DateTime Data { get; set; }
        public string Kontrakt18 { get; set; }
        public string Waluta { get; set; }
        public string Konto {  get; set; }
        public string Subkonto { get; set; }
        public decimal Saldo { get; set; }
    }
}
