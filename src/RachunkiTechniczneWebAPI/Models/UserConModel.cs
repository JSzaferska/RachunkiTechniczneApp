using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RachunkiTechniczneWebApi.Models
{
    public class UserConModel
    {
        public int IdCon { get; set; }
        public int IdUser { get; set; }

        public User User { get; set; }
        public ContractModel Contract { get;set; }
    }
}
