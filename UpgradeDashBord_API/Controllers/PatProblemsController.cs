using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UpgradeDashBord_API.Controllers
{
    public class PatProblemsController : ApiController
    {
        public string GetEMRAccessModule(int UserKey)
        {
            try
            {
                DashBord_BL.PatPro_BL Logc = new DashBord_BL.PatPro_BL();

                return Logc.GetEMRAccessModule(UserKey.ToString());
            }
            catch(Exception er)
            {
                return er.ToString();
            }
        }
      

        [HttpGet]
        public string SetOrderSheet(string Keys, string PID  ,int Eps_Key , int User_Id  ,int isprivatesheet )
        {
            try
            {
                DashBord_BL.PatPro_BL Logc = new DashBord_BL.PatPro_BL();


                return Logc.SetOrderSheet(Keys, PID, Eps_Key.ToString(), User_Id.ToString());
            }
            catch(Exception er)
            {
                return er.ToString();
            }
        }

        [HttpGet]
        public string GetActiveProblemsProcessed(string Patient_ID ,int Eps_key  , int HID  , int intType)
        {
            try
            {
                DashBord_BL.PatPro_BL Logc = new DashBord_BL.PatPro_BL();

                return Logc.GetActiveProblems(Patient_ID, Eps_key.ToString(), HID.ToString(), intType.ToString());
            }
            catch(Exception er)
            {
                return er.ToString();
            }
        }

        [HttpGet]
        public string GetCInfoResults(string Patient_ID, int Eps_Key, int User_ID, int HID)
        {
            try
            {
                DashBord_BL.PatPro_BL Logc = new DashBord_BL.PatPro_BL();

                return Logc.GetCInfoData(Patient_ID, Eps_Key.ToString(), HID.ToString());
            }
            catch(Exception er)
            {
                return er.ToString();
            }
        }
    }
}
