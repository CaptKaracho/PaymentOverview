using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PO.BL.BLEntties;
using PO.Data;
using System.Data.Entity;

namespace PO.BL
{
    public class BLUser : BLBase
    {
        public BLUser() : base() { }
        public BLUser(string User) : base(User) { }

        public UserData Login(string Username, string Password)
        {
            UserData _Return = new UserData();

            var _user = RepContext.USER.FirstOrDefault(f => f.USERNAME == Username && f.PASSWORD == Password);

            if (_user != null)
            {
                _Return.User = _user;

                _Return.Groups = RepContext.USER_ROLE_PAYMENT_GROUP
                    .Where(w => w.USER_ID == _user.USER_ID)
                    .Include(i => i.ROLE)
                    .ToList();

            }
            return _Return;
        }

    }


}