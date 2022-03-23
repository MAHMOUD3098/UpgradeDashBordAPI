using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DashBord_BL;
using Newtonsoft.Json;
namespace UpgradeDashBord_API.Controllers
{
    public class PatDocmentsController : ApiController
    {
        private DashBord_BL.EMRLogic<object> Logcs;
        public PatDocmentsController()
        {
            Logcs = new DashBord_BL.EMRLogic<object>(1);
        }
        [HttpGet]
        public async  Task<dynamic> GetDocsForPat(string PID)
        {
            try
            {
                //  DashBord_BL.PatDoc_BL Logc = new DashBord_BL.PatDoc_BL();
                List<DashBord_BL.Staff> rettaksemr = new List<DashBord_BL.Staff>();

                 await Task.Run(() => {
                    rettaksemr = Logcs.GetPatDoc_BL().GetDocsForPat(PID);
                    
                    });
                return rettaksemr;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [HttpGet]
        public async Task<string> GetSheetsResults(string Patient_ID, DateTime FromDate, DateTime ToDate, string HID, string Eps_Key)
        {
            try
            {
             //   DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();

                return await Task.Run(() => Logcs.GetPatDoc_BL().GetSheetsResults(Patient_ID, FromDate, ToDate, HID, Eps_Key));
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }

        [HttpGet]
        public async Task<string> GetAllPNotes(string PID, string User_ID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
               // DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();

                return await Task.Run(() => Logcs.GetPatDoc_BL().GetAllPNotes(PID, User_ID, FromDate, ToDate));
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }

        [HttpGet]
        public async Task<string> GetDocNGrp(string PID)
        {
            try
            {
                //DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();

                return await Task.Run(() => Logcs.GetPatDoc_BL().GetDocNGrp(PID));
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }

        [HttpGet]
        public async Task SetOrderSheetSysParam(string PID, string Eps_Key, string User_Id, string HID)
        {
            try
            {
                // DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                await Task.Run(() =>
                {
                    if (PID.Trim() == "" || Eps_Key.Trim() == "" || User_Id.Trim() == "" || HID.Trim() == "")
                        return;
                    string str1 = "select SYSPARAMETERS.episodesheets from SYSPARAMETERS where HospitalID =  " + HID;
                    string str2 = Logcs.GetPatDoc_BL().getQuery(str1);
                    string str3 = str2.Replace(",", "^");
                    if (!(str2 != ""))
                        return;
                    string str4 = "select count(*)  as cc from msheetorder where sheet_key in (" + str2 + ") and episode_key = " + Eps_Key;

                    if (Logcs.GetPatDoc_BL().getQuery(str4).ToString() == "0")
                        Logcs.GetPatDoc_BL().SetOrderSheetSysParam(str3 + "^", PID, Eps_Key, User_Id, "0");
                });
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        [HttpGet]
        public async Task<string> SheetisPriavate(string HID)
        {
            try
            {
               // DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                return await Task.Run(() => Logcs.GetPatDoc_BL().SheetisPriavate(HID));
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
        public async Task<string> getNoteCount(string Patient_ID, DateTime FromDate, DateTime ToDate, string U_id)
        {
            try
            {
                //DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                return await Task.Run(() => Logcs.GetPatDoc_BL().getNoteCount(Patient_ID, FromDate, ToDate, U_id));
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        [HttpGet]
        public async Task<string> getSheetReportsDef(string HId)
        {
            try
            {
               // DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                return await Task.Run(() => Logcs.GetPatDoc_BL().getSheetReportsDef(HId));
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        [HttpGet]
        public async Task<dynamic> getSheetReports(string HId)
        {
            try
            {
                // DashBord_BL.PatDoc_BL logic = new DashBord_BL.PatDoc_BL();
                List<DashBord_BL.SheetsRep> rettaksemr = new List<DashBord_BL.SheetsRep>();
                await Task.Run(() => {

                    rettaksemr = Logcs.GetPatDoc_BL().getSheetReports(HId);
                });
              
                return rettaksemr;
              
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [HttpGet]
        public async Task<dynamic> GetSheetsResultsByOrderKey(string Patient_ID, string OrderKey, string User_ID)
        {
            try
            {
                List<DashBord_BL.Sheet> rettaksemr = new List<DashBord_BL.Sheet>();
                await Task.Run(() => {

                    rettaksemr = Logcs.GetPatDoc_BL().GetSheetsResultsByOrderKey(Patient_ID, OrderKey, User_ID);
                });

                return rettaksemr;
                //return Logcs.GetPatDoc_BL().GetSheetsResultsByOrderKey(Patient_ID, OrderKey, User_ID);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
        
    }
}
