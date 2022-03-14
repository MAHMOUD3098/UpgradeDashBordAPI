using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    //public class CInfoFactory
    //{

    //    public  ClinicalInfo createCInfo()
    //    {
    //        return new ClinicalInfo();
    //    }
    //}
    public class ClinicalInfo
    {
        public ClinicalInfo()
        {
            objEps_Info = new List<ClinicalInfo_Dtl>();
        }

        public List<ClinicalInfo_Dtl> objEps_Info = null;
        public string CInfoServType { set; get; }

        public string CInfoTitle { set; get; }

        public string CInfoDesc = "";
        public string CInfoCode { set; get; }

        public string PID { set; get; }
        public string isList = "0";
        public string User_Key { set; get; }
        // public List<ClinicalInfo_Dtl> Eps_Info { set; get; }
    }
}
