using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    public class MedcaDalDB : IRepository
    {
        private MedicaDAL.DBInteraction dbcon;
        public MedcaDalDB()
        {
            dbcon = new MedicaDAL.DBInteraction();
        }
        public void ExecNonQuery(string query)
        {
           // dbcon = new MedicaDAL.DBInteraction();
            dbcon.ExecNonQuery(query);
        }

        public DataTable GetData(string query)
        {
            //dbcon = new MedicaDAL.DBInteraction();
            return dbcon.GetData(query);
        }
        public string UserKey()
        {
           // dbcon = new MedicaDAL.DBInteraction();
            return dbcon.UserKey;
        }
        public object ExecScalarQuery(string query)
        {
            //dbcon = new MedicaDAL.DBInteraction();
            return dbcon.ExecScalarQuery( query);
        }
        public string HospitalId()
        {
          //  dbcon = new MedicaDAL.DBInteraction();
            return dbcon.HospitalId;
        }
        
    }
}
