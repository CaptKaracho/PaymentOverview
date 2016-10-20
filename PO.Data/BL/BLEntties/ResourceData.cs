using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.Data.BL.BLEntties
{
    public class ResourceData
    {
        public Data.ResourceTyp Type { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }

        public ResourceData()
        {
            Type = ResourceTyp.Unknow;
        }
        public ResourceData(System.Data.IDataReader Reader)
        {
            if (Reader.FieldCount >= 1 && Reader[0] != null)
                this.Type = (Data.ResourceTyp)Reader.GetInt32(0);
            if (Reader.FieldCount >= 2 && Reader[1] != null)
                this.Id = Reader.GetInt32(1);
            if (Reader.FieldCount >= 3 && Reader[2] != null)
                this.Description = Reader[2].ToString();
        }
    }
}
