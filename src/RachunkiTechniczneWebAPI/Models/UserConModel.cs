using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RachunkiTechniczneWebApi.Models
{
    public class UserConModel
    {
        public int Id_con { get; set; }
        public int Id_user { get; set; }

        public User User { get; set; }
        public ContractModel Contract { get;set; }
    }
}
