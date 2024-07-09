using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RachunkiTechniczneWebApi.Models
{
    public class User
    {
        public int Id_user { get; set; }
        public string Owner { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Is_admin { get; set; }

        public IList<UserConModel> UserCon { get; set; }
    }
}
