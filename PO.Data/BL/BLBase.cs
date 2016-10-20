using System;
using PO.Data.Repository;
using PO.Data.BL.BLEntties;
using System.Collections.Generic;

//using System.;

namespace PO.Data.BL
{
    public class BLBase : IDisposable
    {
        public Repository.RepositoryGeneric Rep { get; set; }


        public BLBase()
        {
            Rep = new Repository.RepositoryGeneric("NoUser");
        }

        public BLBase(string User)
        {
            Rep = new RepositoryGeneric(string.IsNullOrEmpty(User) == true ? "NoUser" : User);
        }

        public List<ResourceData> GetResourceData(int Typ)
        {
            return Rep.GetResourceData(Typ);

        }

        public void Dispose()
        {

        }
    }
}
