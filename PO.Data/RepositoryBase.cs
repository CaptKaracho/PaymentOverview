using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.Data
{
    public class RepositoryBase : DataContext, IDisposable
    {
        public RepositoryBase()
        {
            
            this.Configuration.LazyLoadingEnabled = false;
        }


        void IDisposable.Dispose()
        {
            if (this != null)
                this.Dispose();
        }
    }
}
