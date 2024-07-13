using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RachunkiTechniczneWebApi.Models
{
    public class ContractModel
    {
        
        public int Id_con { get; set; }
        public int Id_in { get; set; }
        public string Contract { get; set; }
        public string Contract18 { get; set; }
        public string Product_code { get; set; }
        public string Currency { get; set; }
        public DateTime Opening_date { get; set; }
        public int Is_correct { get; set; }
        public float Correct_balance { get; set; }
        public string Comment { get; set; }

        public Inventory Inventory { get; set; }
        public User User { get; set; }
        public IList<UserConModel> UserCon { get; set; }
    }
}
