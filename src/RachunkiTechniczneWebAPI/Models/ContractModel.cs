using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RachunkiTechniczneWebApi.Models
{
    public class ContractModel
    {
        
        public int IdCon { get; set; }
        public string Contract { get; set; }
        public string Contract18 { get; set; }
        public string ProductCode { get; set; }
        public string Currency { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }

        public IList<UserConModel> UserCon { get; set; }
    }
}
