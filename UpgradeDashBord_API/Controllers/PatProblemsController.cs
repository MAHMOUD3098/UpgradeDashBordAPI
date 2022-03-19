using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace UpgradeDashBord_API.Controllers
{
    public class PatProblemsController : ApiController
    {
        public string GetEMRAccessModule(int UserKey)
        {
            try
            {
                string rettaksemr = "";
                DashBord_BL.PatPro_BL Logc = new DashBord_BL.PatPro_BL();
               // rettaksemr = await Task.Run(() =>Logc.GetEMRAccessModule(UserKey.ToString()));
                //Task<string> sd = new Task<string>(()=>Logc.GetEMRAccessModule(UserKey.ToString()));
                //sd.Start();
                //await sd;
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







        // new api 





        [HttpGet]
        public string GetIsOrderEpisode(string Eps_Key)
        {
            try
            {

                return new DashBord_BL.PatPro_BL().GetIsOrderEpisode(Eps_Key);
            }
            catch (Exception er)
            {
                return er.ToString();
            }

        }



        public string GetEnableOrderSets(string HID)
        {

            try
            {
                DashBord_BL.PatPro_BL objBus = new DashBord_BL.PatPro_BL();
                return objBus.GetEnableOrderSets(HID);
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }

        [HttpGet]
        public string GetUserDefScreen(string User_Id, string PID)
        {
            try
            {
                // find problem api 2 pramaters  and implement need  1 pramaters
                DashBord_BL.PatPro_BL ppb = new DashBord_BL.PatPro_BL();
                return ppb.GetUserDefScreen(User_Id);
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }

        [HttpGet]
        public string Eps_Status(string Eps_Key)
        {
            try
            {
                DashBord_BL.PatPro_BL esb = new DashBord_BL.PatPro_BL();
                return esb.Eps_Status(Eps_Key);
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }

        public string GetGender(string PID)
        {
            try
            {
                DashBord_BL.PatPro_BL esb = new DashBord_BL.PatPro_BL();
                return esb.GetGender(PID);
            }
            catch (Exception er)
            {
                return er.ToString();
            }
        }



        public dynamic GetAssessmentsData(
        string Patient_ID,
        DateTime FromDate,
        DateTime ToDate)
        {
            try
            {
                DashBord_BL.PatPro_BL gab = new DashBord_BL.PatPro_BL();
                return gab.GetAssessmentsData(Patient_ID, FromDate, ToDate);
            }
            catch (Exception er)
            {

                return er.ToString();
            }


        }



        public string GetLastVisit(string PID, string Eps_key)
        {
            try
            {
                return DashBord_BL.PatPro_BL.GetLastVisit(PID, Eps_key);
            }
            catch (Exception er)
            {

                return er.ToString();
            }
        }




        [HttpGet]
        public string GetLocalIPAddress()
        {
            try
            {
                string str = "";
                HttpRequest request = HttpContext.Current.Request;
                foreach (string serverVariable in request.ServerVariables)
                    str = str + serverVariable + "=" + request.ServerVariables[serverVariable] + "       xxxx       ";
                return ((HttpContextBase)this.Request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            catch (Exception er)
            {

                return er.ToString();
            }
        }
    }
}
