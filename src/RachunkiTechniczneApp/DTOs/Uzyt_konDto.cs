using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RachunkiTechniczneApp.DTO
{
    internal class Uzyt_konDto
    {
        public int Id_kon { get; set; }
        public int Id_uzyt { get; set; }

        public UzytkownicyDto UzytkownicyDto { get; set; }
        public KontraktyDto KontraktyDto { get;set; }
    }
}
