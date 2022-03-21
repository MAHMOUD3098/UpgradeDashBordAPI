using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    //--ClsDescStatus class
    public class ClsDescStatus
    {
        public string DynaDocID { get; set; }
        public string IcoNote { get; set; }
        public string New_Order_Status { set; get; }

        public List<DrugAdminInfo> DrugAdminInfo { set; get; }
        public string Sheet_FromTable { set; get; }
        public string LabProcessType { set; get; }
        public string Order_key { get; set; }
        public string PLAN_ACTION_NOTE { get; set; }
        public string AttachNote { get; set; }
        public string InvResKey { get; set; }
        public string Note_P_ID { get; set; }
        public string Note_ID { get; set; }
        public string OrderInfo { get; set; }
        public string Code { get; set; }
        public string eps_key { get; set; }
        public string Order_type { get; set; }
        public string PID { get; set; }
        public string Serv_Desc { get; set; }
        public string Serv_Status { get; set; }
        public string Serv_Date { get; set; }
        public string Serv_time { get; set; }
        public string StInvOrder { get; set; }
        public string Icon_Status { get; set; }
        public string Status { get; set; }
        public string ReportKey { get; set; }
        public string SheetDefKey { get; set; }
        public string OrdKey { get; set; }
        public string ReportDesc { get; set; }
        public string ReportStatus { get; set; }
        public string NoteColor { get; set; }
        public string NotebtnsignV { get; set; }
        public bool IsSheet { get; set; }
        public string Staff_Name { get; set; }
        public string Staff_key { get; set; }
        public string SheetStatus { get; set; }
        public string Order_Status { get; set; }
        public string sigFlag { get; set; }
        public string Jd_Key { get; set; }
        public string OrdDet_Key { set; get; }
        public string IsEMRSignOff { set; get; }
        public string IconEMRSignOff { set; get; }
      //  public List<UserSignOff> UsersSignOff { set; get; }
        // public ClsDescStatus obj { get { return this; } }
        public List<SheetItem_1> Sheets { get; set; }
        public List<IT_Sheet> OptSheets { get; set; }

    }
}
