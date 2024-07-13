using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RachunkiTechniczneWebApi.Models
{
    public class Inventory
    {
        public int Id_in { get; set; }
        public DateTime Date { get; set; }
        public string Contract18 { get; set; }
        public string Currency { get; set; }
        public string Account {  get; set; }
        public string SubAccount { get; set; }
        public decimal Balance { get; set; }
    }
}
