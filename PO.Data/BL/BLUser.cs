﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PO.Data;
using System.Data.Entity;
using PO.Data.BL.BLEntties;

namespace PO.Data.BL
{
    public class BLUser : BLBase
    {
        public BLUser() : base()
        {

        }
        public BLUser(string User) : base(User)
        {
        }

        public UserData Login(string Username, string Password)
        {
            UserData _Return = new UserData();

            var _user = Rep.Context.USER
                                    .AsNoTracking()
                                    .FirstOrDefault(f => f.USERNAME == Username && f.PASSWORD == Password);

            if (_user != null)
            {
                _Return.User = _user;

                _Return.Groups = Rep.Context.USER_ROLE_PAYMENT_GROUP
                                    .Where(w => w.USER_ID == _user.USER_ID)
                                    .Include(i => i.ROLE)
                                    .Include(i => i.PAYMENT_GROUP)
                                    .AsNoTracking()
                                    .ToList();

            }
            return _Return;
        }

    }


}