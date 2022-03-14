using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    public class ActiveProblems
    {
        public string AP_Sys_Key { set; get; }
        public string PID { set; get; }
        public string AttachNote { set; get; }
        public string IsPrim { set; get; }
        public string IsSolved { set; get; }
        public string FandP { set; get; }
        public string Eps_Key { set; get; }
        public string AP_Status { set; get; }
        public string CHO_Status { set; get; }
        public string AP_Desc { set; get; }
        public string AP_Date { set; get; }
        public string AP_PKey { set; get; }
        public string Term { set; get; }
        public string Remarks { set; get; }



        public string User_Key { set; get; }
        public string viewtype { set; get; }

        public string Note_ID { set; get; }
        public string Cho_Is_Free { set; get; }

        public string Note_Text { set; get; }
        public string Note_Date { set; get; }
        public string Note_Time { set; get; }
        public string Staff_name { set; get; }
        public string Link_Key { set; get; }
    }
}
