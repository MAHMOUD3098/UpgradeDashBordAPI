using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    public class Utilities
    {
        //MedicaDAL.DBInteraction dbcon = null;
        public Utilities()
        {
            //dbcon = new MedicaDAL.DBInteraction(true);
        }
        public static string FormatDate(DateTime dt)
        {
            string res = "";
            res = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
            res += " 23:59:59.000";
            return res;
        }
        public static string FormatDateFrom(DateTime dt)
        {
            string res = "";
            res = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
            res += " 00:00:00.000";
            return res;
        }
        public static string FormatDateClr(DateTime dt)
        {
            string res = "";
            res = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
            res += "";
            return res;
        }
        public string GetWebServerIP()
        {
            //return dbcon.GetWebServerPath;
            return "";
        }
    }
}
