using System;
using PO.Data;

namespace PO.BL
{
    public class BLBase : IDisposable
    {
        public string Username { get; set; }

        public BLBase()
        {
            this.Username = "NoUser";
            RepContext = new RepositoryBase();
        }

        public BLBase(string User)
        {
            this.Username = string.IsNullOrEmpty(User) == true ? "NoUser" : User;
            RepContext = new RepositoryBase();
        }

        public RepositoryBase RepContext { get; set; }

        public void Dispose()
        {
            if (RepContext != null)
                RepContext = null;
        }
    }
}
