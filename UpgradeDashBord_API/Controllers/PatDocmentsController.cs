using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DashBord_BL;
using Newtonsoft.Json;
namespace UpgradeDashBord_API.Controllers
{
    public class PatDocmentsController : ApiController
    {
        [HttpGet]
        public string GetDocsForPat(string PID)
        {
            try
            {
                DashBord_BL.PatDoc_BL Logc = new DashBord_BL.PatDoc_BL();

                return Logc.GetDocsForPat(PID);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        public string GetSheetsResults(string Patient_ID, DateTime FromDate, DateTime ToDate, string HID, string Eps_Key)
        {
            try
            {
                DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();

                return logic.GetSheetsResults(Patient_ID, FromDate, ToDate, HID, Eps_Key);
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }

        [HttpGet]
        public string GetAllPNotes(string PID, string User_ID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();

                return logic.GetAllPNotes(PID, User_ID, FromDate, ToDate);
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }

        [HttpGet]
        public string GetDocNGrp(string PID)
        {
            try
            {
                DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();

                return logic.GetDocNGrp(PID);
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }

        [HttpGet]
        public void SetOrderSheetSysParam(string PID, string Eps_Key, string User_Id, string HID)
        {
            try
            {
                DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                if (PID.Trim() == "" || Eps_Key.Trim() == "" || User_Id.Trim() == "" || HID.Trim() == "")
                    return;
                string str1 = "select SYSPARAMETERS.episodesheets from SYSPARAMETERS where HospitalID =  " + HID;
                string str2 = logic.getQuery(str1);
                string str3 = str2.Replace(",", "^");
                if (!(str2 != ""))
                    return;
                string str4 = "select count(*)  as cc from msheetorder where sheet_key in (" + str2 + ") and episode_key = " + Eps_Key;

                if (logic.getQuery(str4).ToString() == "0")
                    logic.SetOrderSheetSysParam(str3 + "^", PID, Eps_Key, User_Id, "0");
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpGet]
        public string SheetisPriavate(string HID)
        {
            try
            {
                DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                return logic.SheetisPriavate(HID);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public void GetWebServerIP()
        {
            try
            { }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpGet]
        public string getNoteCount(string Patient_ID, DateTime FromDate, DateTime ToDate, string U_id)
        {
            try
            {
                DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                return logic.getNoteCount(Patient_ID, FromDate, ToDate, U_id);
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        [HttpGet]
        public string getSheetReportsDef(string HId)
        {
            try
            {
                DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                return logic.getSheetReportsDef(HId);
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        [HttpGet]
        public dynamic getSheetReports(string HId)
        {
            try
            {
                DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                var df = logic.getSheetReports(HId);
                return df;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [HttpGet]
        public dynamic GetSheetsResultsByOrderKey(string Patient_ID, string OrderKey, string User_ID)
        {
            try
            {
                DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                return logic.GetSheetsResultsByOrderKey(Patient_ID, OrderKey, User_ID);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
