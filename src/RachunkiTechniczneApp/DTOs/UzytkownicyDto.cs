using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RachunkiTechniczneApp.DTO
{
    internal class UzytkownicyDto
    {
        public int Id_uzyt { get; set; }
        public string Wlasciciel { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public bool Czy_admin { get; set; }

        public IList<Uzyt_konDto> Uzyt_kon { get; set; }
    }
}
