using System;
using System.Collections.Generic;
using System.Reflection;
using PO.Data.BL.BLEntties;
using PO.Data.EF;

namespace PO.Data.Repository
{
    public class Repository : IDisposable
    {
        public PODataContext Context { get; set; }
        public string Username { get; set; }
        public Data.SQL.DBAccess DBAccess { get; set; }

        #region Constructor
        public Repository()
        {
            this.Context = new PODataContext();
            this.Username = "NoUser";
            this.Context.Configuration.LazyLoadingEnabled = false;
            this.DBAccess = new SQL.DBAccess(this.Context.Database.Connection.ConnectionString);

        }
        public Repository(string Username)
        {
            this.Context = new PODataContext();
            this.Username = Username;
            this.Context.Configuration.LazyLoadingEnabled = false;
            this.DBAccess = new SQL.DBAccess(this.Context.Database.Connection.ConnectionString);

        }
        #endregion

        #region T ChangeProperty (Insert/Update)

        public object SetChangeProperties<TObject>(TObject ChangedObject) where TObject : class
        {
            PropertyInfo _Prop1 = null;
            PropertyInfo _Prop2 = null;
            if (this.Context.Entry(ChangedObject).State == System.Data.Entity.EntityState.Modified)
            {
                _Prop1 = ChangedObject.GetType().GetProperty("UPDATE_AT");
                _Prop2 = ChangedObject.GetType().GetProperty("UPDATE_BY");
            }
            if (this.Context.Entry(ChangedObject).State == System.Data.Entity.EntityState.Added)
            {
                _Prop1 = ChangedObject.GetType().GetProperty("INSERT_AT");
                _Prop2 = ChangedObject.GetType().GetProperty("INSERT_BY");
            }

            if (_Prop1 != null && _Prop2 != null)
            {
                if (_Prop1 != null)
                {
                    Type _T = Nullable.GetUnderlyingType(_Prop1.PropertyType) ?? _Prop1.PropertyType;

                    object safeValue = (DateTime.Now == null) ? null : Convert.ChangeType(DateTime.Now, _T);

                    _Prop1.SetValue(ChangedObject, safeValue, null);
                }
                _Prop2.SetValue(ChangedObject, Convert.ChangeType(Username, _Prop2.PropertyType), null);
            }

            return ChangedObject;
        }
        public object SetChangeProperties<TObject>(List<TObject> ChangedObject) where TObject : class
        {
            foreach (var _T in ChangedObject)
            {
                SetChangeProperties<TObject>(_T);
            }

            return ChangedObject;
        }

        #endregion

        public List<ResourceData> GetResourceData(int Typ)
        {
            List<ResourceData> _Return = new List<ResourceData>();
            this.DBAccess.Command = new System.Data.SqlClient.SqlCommand("GetResourceData", DBAccess.Connection);
            this.DBAccess.Command.CommandType = System.Data.CommandType.StoredProcedure;

            this.DBAccess.Command.Parameters.Add(
              new System.Data.SqlClient.SqlParameter("Typ", Typ));

            this.DBAccess.Connection.Open();

            this.DBAccess.Reader = this.DBAccess.Command.ExecuteReader();
            while (this.DBAccess.Reader.Read())
            {
                _Return.Add(new ResourceData(this.DBAccess.Reader));
            }
            this.DBAccess.Reader.Close();
            return _Return;
        }

        #region Payment
        public List<Data.BL.BLEntties.PaymentDataSingle> GetPaymentSingle(int Granularity)
        {
            List<Data.BL.BLEntties.PaymentDataSingle> _Return = new List<BL.BLEntties.PaymentDataSingle>();
            this.DBAccess.Command = new System.Data.SqlClient.SqlCommand("Payment_GetSingle", DBAccess.Connection);
            this.DBAccess.Command.CommandType = System.Data.CommandType.StoredProcedure;
            this.DBAccess.Command.Parameters.Add(
                new System.Data.SqlClient.SqlParameter("Granularity", Granularity));

            this.DBAccess.Connection.Open();

            this.DBAccess.Reader = this.DBAccess.Command.ExecuteReader();
            while (this.DBAccess.Reader.Read())
            {
                _Return.Add(new BL.BLEntties.PaymentDataSingle(this.DBAccess.Reader));
            }
            this.DBAccess.Reader.Close();
            return _Return;
        }

        #endregion

        void IDisposable.Dispose()
        {
            if (this != null)
            {
                this.Context.Dispose();
                this.DBAccess.Dispose();
            }
        }
    }
}
