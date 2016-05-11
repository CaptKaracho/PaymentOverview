using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PO.Data;

namespace PO.BL.BLEntties
{
    public class UserData
    {
        public Data.USER User { get; set; }
        public List<Data.USER_ROLE_PAYMENT_GROUP> Groups { get; set; }

        public UserData()
        {
           this.User = new Data.USER();
            this.Groups = new List<Data.USER_ROLE_PAYMENT_GROUP>();
        }

        public UserData(USER ApplicationUser, List<USER_ROLE_PAYMENT_GROUP> Groups)
        {
            this.User = ApplicationUser;
            this.Groups = Groups;
        }

    }
}
