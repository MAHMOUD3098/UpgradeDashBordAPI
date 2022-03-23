using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
   public interface IRepository
    {
         DataTable GetData(string query);
       // DataTable GetData(string query);
        void ExecNonQuery(string query);

        string  UserKey();
        string HospitalId();
        object ExecScalarQuery(string query); 
    }
}
