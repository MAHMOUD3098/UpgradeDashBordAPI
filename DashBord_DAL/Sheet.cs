using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    //--Sheet class
    public class Sheet
    {
        public string User_Key { set; get; }
        public string SheetCode { set; get; }
        public string Sheetsort { set; get; }
        public string SheetCount { set; get; }

        public string IsPrivate { set; get; }
        public string IconPrivate { set; get; }


        public string SheetDesc { set; get; }
        public string SheetType { set; get; }
        public string OrderType { set; get; }

        public string SheetDate { set; get; }

        public string SheetTime { set; get; }
        public string SheetClass { set; get; }

        public ConstantsVariables.SheetStatus SheetStatus { set; get; }

        public string SheetDescStatus { set; get; }

        public string PID { set; get; }

        public string Eps_Key { set; get; }

        public string IsEMRFavorites { set; get; }
        public string IconEMRFavorites { set; get; }
        public string SheetOrd_Key { set; get; }
        public string SheetP_Key { set; get; }

        public string Sheet_Status { set; get; }
        public string Sheet_Sheetkey { set; get; }
        public string Sheet_FromTable { set; get; }

        public string IsEMRSignOff { set; get; }
        public string IconEMRSignOff { set; get; }
        public List<UserSignOff> UsersSignOff { set; get; }
    }
}
