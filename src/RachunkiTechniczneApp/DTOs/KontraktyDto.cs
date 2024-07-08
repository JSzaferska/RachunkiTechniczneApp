using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RachunkiTechniczneApp.DTO
{
    internal class KontraktyDto
    {
        
        public int Id_kon { get; set; }
        public string Kontrakt { get; set; }
        public string Kontrakt18 { get; set; }
        public string Kod_produktu { get; set; }
        public string Waluta { get; set; }
        public DateTime Data_otwarcia { get; set; }
        public DateTime Data_zamkniecia { get; set; }

        public IList<Uzyt_konDto> Uzyt_kon { get; set; }
    }
}
