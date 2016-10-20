using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PO.Data.EF;

namespace PO.Data.BL.BLEntties
{
    public class UserData
    {
        public USER User { get; set; }
        public List<USER_ROLE_PAYMENT_GROUP> Groups { get; set; }

        public UserData()
        {
            this.User = new USER();
            this.Groups = new List<USER_ROLE_PAYMENT_GROUP>();
        }

        public UserData(USER ApplicationUser, List<USER_ROLE_PAYMENT_GROUP> Groups)
        {
            this.User = ApplicationUser;
            this.Groups = Groups;
        }

    }
}
