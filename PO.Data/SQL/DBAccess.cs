using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PO.Data.SQL
{
    public class DBAccess : IDisposable
    {
        public string Connectionstring { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }

        public SqlDataReader Reader { get; set; }
        public DBAccess(string Connetionstring)
        {
            this.Connection = new SqlConnection(Connetionstring);
            this.Connectionstring = Connetionstring;


        }

        public void Dispose()
        {
            this.Connection.Dispose();
        }
    }
}
