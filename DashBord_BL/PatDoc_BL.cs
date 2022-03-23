using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBord_DAL;
using Newtonsoft.Json;
using static DashBord_BL.ConstantsVariables;
//using static DashBord_DAL.ConstantsVariables;

namespace DashBord_BL
{
    public class PatDoc_BL
    {
      private  DashBord_DAL.PatDoc_DL dal;
        private RepositoryDb<object>   df;

        public PatDoc_BL()
        {
            df = new RepositoryDb<object>();
            dal = new DashBord_DAL.PatDoc_DL(df.getDal());
        }
        public string GetDocsForPat(string PID)
        {
            
            List<DashBord_DAL.Staff> docs = new List<DashBord_DAL.Staff>();
            DataTable DsDt = dal.GetDocsForPat(PID);
            foreach (DataRow Dr in DsDt.Rows)
            {
                DashBord_DAL.Staff dd = new DashBord_DAL.Staff();
                dd.Staff_key = Dr["staff_key"].ToString();
                dd.Staff_Name = Dr["Staff_name"].ToString();
                dd.Staff_Icon = "Images/Gen/doctor.ico";
                docs.Add(dd);
            }
            return JsonConvert.SerializeObject(docs);
        }

        //--GetSheetsResults in BL
        public string GetSheetsResults(string Patient_ID, DateTime FromDate, DateTime ToDate, string HID, string Eps_Key)
        {
            List<Sheet> SheetRes = new List<Sheet>();
            //SheetsDL Proc = new SheetsDL();
            //GeneralDL Gen = new GeneralDL();
            // replace with our dal //
        //    DashBord_DAL.PatDoc_DL da = new PatDoc_DL();
            DataTable dtfvr = dal.EMRFavorites(dal.getUserId());
            DataTable dtsoff = dal.EMRSignOff("9", dal.getUserId(), Patient_ID);
            DataTable dtresult = null;

            SheetFactory factory = new SheetFactory();

            dtresult = dal.GetSheetsOPTData(Patient_ID, FromDate, ToDate);
            foreach (DataRow dr in dtresult.Rows)
            {
                if (SheetRes.Where(raad => raad.SheetType == dr["SheetType"].ToString() && raad.SheetCode == "0").Count() == 0)
                {
                    Sheet SheetRecTT = factory.createSheet();
                    SheetRecTT.User_Key = dal.getUserId();
                    SheetRecTT.SheetCode = "0";

                    SheetRecTT.SheetDesc = dr["SheetType"].ToString();
                    SheetRecTT.SheetType = dr["SheetType"].ToString();

                    SheetRecTT.SheetClass = "SheetClassCSS " + dr["SheetType"].ToString();

                    SheetRecTT.PID = Patient_ID;
                    SheetRecTT.SheetOrd_Key = "0";
                    SheetRecTT.Sheet_Status = "0";
                    SheetRecTT.Sheet_Sheetkey = "0";
                    SheetRecTT.SheetDescStatus = "";//.Split("<br>".ToCharArray());
                    SheetRecTT.SheetStatus = ConstantsVariables.SheetStatus.Recoreded;
                    SheetRes.Add(SheetRecTT);
                }
                Sheet SheetRec = factory.createSheet();
                SheetRec.User_Key = dr["Surgeon"].ToString();
                SheetRec.SheetCode = dr["OPT_sheetdefkey"].ToString();
                // SheetRes.Add(SheetRec);
                SheetRec.SheetP_Key = dr["sys_key_Parent"].ToString();
                if (SheetRes.Where(raad => raad.SheetP_Key == dr["sys_key_Parent"].ToString() && raad.SheetType == dr["SheetType"].ToString()).Count() == 0)
                {
                    SheetRes.Add(SheetRec);
                }
                SheetRec.SheetOrd_Key = dr["OPT_sheet_key"].ToString();
                SheetRec.Sheet_Status = dr["satus"].ToString();
                SheetRec.Sheet_Sheetkey = dr["OPT_sheetdefkey"].ToString();
                SheetRec.OrderType = "3";

                SheetRec.Eps_Key = dr["EPISODE_KEY"].ToString();
                SheetRec.SheetDate = dr["ORDERDATE"].ToString();
                SheetRec.SheetDesc = dr["Description"].ToString() + "(" + dr["OPT_sheet_desc"].ToString() + ")";
                SheetRec.SheetType = dr["SheetType"].ToString();
                SheetRec.SheetTime = dr["Order_Time"].ToString();
                SheetRec.SheetClass = "SheetClassV " + dr["sheettype"].ToString();

                SheetRec.PID = dr["Patient_id"].ToString();
                SheetRec.SheetDescStatus = dr["InvordStatus"].ToString();//.Split("<br>".ToCharArray());

                bool xxcc = dal.IsEMRFavorites(SheetRec.SheetCode, "4", dal.getUserId(), dtfvr);
                if (xxcc == true)
                {
                    SheetRec.IsEMRFavorites = "1";
                    SheetRec.IconEMRFavorites = "Images/Gen/star_yellow.ico";
                }
                else
                {
                    SheetRec.IsEMRFavorites = "0";
                    SheetRec.IconEMRFavorites = "Images/Gen/star_grey.ico";
                }
                xxcc = dal.IsEMRSignOff(SheetRec.SheetOrd_Key, "9", dal.getUserId(), Patient_ID, dtsoff);
                if (xxcc == true)
                {
                    SheetRec.IsEMRSignOff = "1";
                    SheetRec.IconEMRSignOff = "Images/Gen/eye.png";

                }
                else
                {
                    SheetRec.IsEMRSignOff = "0";
                    SheetRec.IconEMRSignOff = "Images/Gen/eye_close.png";
                }
                try
                {
                    DataRow[] drs = dtsoff.Select("Service_Key = " + SheetRec.SheetOrd_Key);
                    if (drs.Length > -1)
                    {
                        SheetRec.UsersSignOff = new List<UserSignOff>();
                        foreach (DataRow sodr in drs)
                        {
                            UserSignOff so = new UserSignOff();
                            so.User_Key = sodr["staff_key"].ToString();
                            so.User_Name = sodr["staff_name"].ToString();
                            so.User_view_Date = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(sodr["SignOff_Date"].ToString()));  //sodr["SignOff_Date"].ToString();
                            SheetRec.UsersSignOff.Add(so);
                        }
                    }
                }
                catch { }
                SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Recoreded;
            }


            dtresult = dal.GetSheetsProcData(Patient_ID, FromDate, ToDate);
            foreach (DataRow dr in dtresult.Rows)
            {
                if (SheetRes.Where(raad => raad.SheetType == dr["SheetType"].ToString() && raad.SheetCode == "0").Count() == 0)
                {
                    Sheet SheetRecTT = factory.createSheet();
                    SheetRecTT.User_Key = dal.getUserId();
                    SheetRecTT.SheetCode = "0";
                    // SheetRes.Add(SheetRec);

                    SheetRecTT.SheetDesc = dr["SheetType"].ToString();
                    SheetRecTT.SheetType = dr["SheetType"].ToString();

                    SheetRecTT.SheetClass = "SheetClassCSS " + dr["SheetType"].ToString();

                    SheetRecTT.PID = Patient_ID;
                    SheetRecTT.SheetOrd_Key = "0";
                    SheetRecTT.Sheet_Status = "0";
                    SheetRecTT.Sheet_Sheetkey = "0";
                    SheetRecTT.SheetDescStatus = "";//.Split("<br>".ToCharArray());
                    SheetRecTT.SheetStatus = ConstantsVariables.SheetStatus.Recoreded;
                    SheetRes.Add(SheetRecTT);
                }
                Sheet SheetRec = factory.createSheet();
                SheetRec.User_Key = dr["userid"].ToString();
                SheetRec.SheetCode = dr["PROCEDURE_KEY"].ToString();
                // SheetRes.Add(SheetRec);
                if (SheetRes.Where(raad => raad.SheetCode == dr["PROCEDURE_KEY"].ToString()).Count() == 0)
                {
                    SheetRes.Add(SheetRec);
                }
                SheetRec.SheetOrd_Key = dr["SYS_KEY"].ToString();
                SheetRec.Sheet_Status = dr["status"].ToString();
                SheetRec.Sheet_Sheetkey = dr["sheet_key"].ToString();
                SheetRec.OrderType = "2";

                SheetRec.Eps_Key = dr["EPISODE_KEY"].ToString();
                SheetRec.SheetDate = dr["ORDERDATE"].ToString();
                SheetRec.SheetDesc = dr["LATIN_DESC"].ToString();
                SheetRec.SheetType = dr["SheetType"].ToString();
                SheetRec.SheetTime = dr["Order_Time"].ToString();
                SheetRec.SheetClass = "SheetClassV " + dr["sheettype"].ToString();

                SheetRec.PID = dr["Patient_id"].ToString();
                SheetRec.SheetDescStatus = dr["InvordStatus"].ToString();//.Split("<br>".ToCharArray());

                bool xxcc = dal.IsEMRFavorites(SheetRec.SheetCode, "4", dal.getUserId(), dtfvr);
                if (xxcc == true)
                {
                    SheetRec.IsEMRFavorites = "1";
                    SheetRec.IconEMRFavorites = "Images/Gen/star_yellow.ico";
                }
                else
                {
                    SheetRec.IsEMRFavorites = "0";
                    SheetRec.IconEMRFavorites = "Images/Gen/star_grey.ico";
                }
                xxcc = dal.IsEMRSignOff(SheetRec.SheetOrd_Key, "9", dal.getUserId(), Patient_ID, dtsoff);
                if (xxcc == true)
                {
                    SheetRec.IsEMRSignOff = "1";
                    SheetRec.IconEMRSignOff = "Images/Gen/eye.png";

                }
                else
                {
                    SheetRec.IsEMRSignOff = "0";
                    SheetRec.IconEMRSignOff = "Images/Gen/eye_close.png";
                }
                try
                {
                    DataRow[] drs = dtsoff.Select("Service_Key = " + SheetRec.SheetOrd_Key);
                    if (drs.Length > -1)
                    {
                        SheetRec.UsersSignOff = new List<UserSignOff>();
                        foreach (DataRow sodr in drs)
                        {
                            UserSignOff so = new UserSignOff();
                            so.User_Key = sodr["staff_key"].ToString();
                            so.User_Name = sodr["staff_name"].ToString();
                            so.User_view_Date = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(sodr["SignOff_Date"].ToString()));  //sodr["SignOff_Date"].ToString();
                            SheetRec.UsersSignOff.Add(so);
                        }
                    }
                }
                catch { }
                SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Recoreded;
            }


            #region Sheets
            //dtresult = Proc.GetSheetsData(Patient_ID, FromDate, ToDate);
            dtresult = dal.GetSheetsData(Patient_ID, FromDate, ToDate);
            foreach (DataRow dr in dtresult.Rows)
            {
                if (SheetRes.Where(raad => raad.SheetType == dr["SheetType"].ToString() && raad.SheetCode == "0").Count() == 0)
                {
                    Sheet SheetRecTT = factory.createSheet();
                    SheetRecTT.User_Key = dal.getUserId();
                    SheetRecTT.SheetCode = "0";
                    // SheetRes.Add(SheetRec);

                    SheetRecTT.SheetDesc = dr["SheetType"].ToString();
                    SheetRecTT.SheetType = dr["SheetType"].ToString();
                    SheetRecTT.Sheetsort = dr["SheetType"].ToString() + "0";

                    SheetRecTT.SheetClass = "SheetClassCSS " + dr["SheetType"].ToString();

                    SheetRecTT.PID = Patient_ID;
                    SheetRecTT.SheetOrd_Key = "0";
                    SheetRecTT.Sheet_Status = "0";
                    SheetRecTT.Sheet_Sheetkey = "0";
                    SheetRecTT.SheetDescStatus = "";//.Split("<br>".ToCharArray());
                    SheetRecTT.SheetStatus = ConstantsVariables.SheetStatus.Recoreded;
                    SheetRes.Add(SheetRecTT);
                }
                Sheet SheetRec = factory.createSheet();
                SheetRec.User_Key = dr["userid"].ToString();
                SheetRec.SheetCode = dr["SYS_KEY"].ToString();
                // SheetRes.Add(SheetRec);
                if (SheetRes.Where(raad => raad.SheetCode == dr["SYS_KEY"].ToString()).Count() == 0)
                {
                    SheetRes.Add(SheetRec);
                }
                SheetRec.SheetOrd_Key = dr["R_KEY"].ToString();
                SheetRec.Sheet_Status = dr["status"].ToString();
                SheetRec.Sheet_Sheetkey = dr["sheet_key"].ToString();
                SheetRec.OrderType = "1";

                SheetRec.Eps_Key = dr["EPISODE_KEY"].ToString();
                SheetRec.SheetDate = dr["order_date"].ToString();
                SheetRec.SheetDesc = dr["DESCRIPTION"].ToString();
                SheetRec.SheetType = dr["SheetType"].ToString();
                SheetRec.Sheetsort = dr["SheetType"].ToString() + "1";
                SheetRec.SheetTime = dr["Order_Time"].ToString();
                SheetRec.SheetClass = "SheetClassV " + dr["sheettype"].ToString();

                SheetRec.PID = dr["Patient_id"].ToString();
                SheetRec.SheetDescStatus = dr["InvordStatus"].ToString();//.Split("<br>".ToCharArray());

                bool xxcc = dal.IsEMRFavorites(SheetRec.SheetCode, "5", dal.getUserId(), dtfvr);
                if (xxcc == true)
                {
                    SheetRec.IsEMRFavorites = "1";
                    SheetRec.IconEMRFavorites = "Images/Gen/star_yellow.ico";
                }
                else
                {
                    SheetRec.IsEMRFavorites = "0";
                    SheetRec.IconEMRFavorites = "Images/Gen/star_grey.ico";
                }
                xxcc = dal.IsEMRSignOff(SheetRec.SheetOrd_Key, "9", dal.getUserId(), Patient_ID, dtsoff);
                if (xxcc == true)
                {
                    SheetRec.IsEMRSignOff = "1";
                    SheetRec.IconEMRSignOff = "Images/Gen/eye.png";

                }
                else
                {
                    SheetRec.IsEMRSignOff = "0";
                    SheetRec.IconEMRSignOff = "Images/Gen/eye_close.png";
                }
                try
                {
                    DataRow[] drs = dtsoff.Select("Service_Key = " + SheetRec.SheetOrd_Key);
                    if (drs.Length > -1)
                    {
                        SheetRec.UsersSignOff = new List<UserSignOff>();
                        foreach (DataRow sodr in drs)
                        {
                            UserSignOff so = new UserSignOff();
                            so.User_Key = sodr["staff_key"].ToString();
                            so.User_Name = sodr["staff_name"].ToString();
                            so.User_view_Date = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(sodr["SignOff_Date"].ToString()));  //sodr["SignOff_Date"].ToString();
                            SheetRec.UsersSignOff.Add(so);
                        }
                    }
                }
                catch { }
                switch (dr["gvstatus"].ToString().ToUpper())
                {
                    case "RECORDED NOT SIGNED":
                        SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Recoreded;
                        break;
                    case "SIGNED":
                        SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Signed;
                        break;
                    case "CANCELLED":
                        SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Cancelled;
                        break;
                }
            }
            #endregion


            #region Templates
            //dtresult = Proc.GetTemplatesData(Patient_ID, FromDate, ToDate);
            dtresult = dal.GetTemplatesData(Patient_ID, FromDate, ToDate);
            foreach (DataRow dr in dtresult.Rows)
            {
                if (SheetRes.Where(raad => raad.SheetType == dr["Type"].ToString() && raad.SheetCode == "0").Count() == 0)
                {
                    Sheet SheetRecTT = factory.createSheet();
                    SheetRecTT.User_Key = dal.getUserId();
                    SheetRecTT.SheetCode = "0";
                    // SheetRes.Add(SheetRec);

                    SheetRecTT.SheetDesc = dr["Type"].ToString();
                    SheetRecTT.SheetType = dr["Type"].ToString();

                    SheetRecTT.SheetClass = "SheetClassCSS " + dr["Type"].ToString();

                    SheetRecTT.PID = Patient_ID;
                    SheetRecTT.SheetOrd_Key = "0";
                    SheetRecTT.Sheet_Status = "0";
                    SheetRecTT.Sheet_Sheetkey = "0";
                    SheetRecTT.SheetDescStatus = "";//.Split("<br>".ToCharArray());
                    SheetRecTT.SheetStatus = ConstantsVariables.SheetStatus.Recoreded;
                    SheetRes.Add(SheetRecTT);
                }
                Sheet SheetRec = factory.createSheet();
                SheetRec.User_Key = dr["userid"].ToString();
                SheetRec.SheetCode = dr["def_key"].ToString();
                // SheetRes.Add(SheetRec);
                if (SheetRes.Where(raad => raad.SheetCode == dr["def_key"].ToString()).Count() == 0)
                {
                    SheetRes.Add(SheetRec);
                }
                SheetRec.SheetOrd_Key = dr["sys_key"].ToString() == "" ? "0" : dr["sys_key"].ToString();
                SheetRec.Sheet_Status = dr["status"].ToString();
                SheetRec.Sheet_Sheetkey = dr["def_key"].ToString();
                SheetRec.OrderType = "10";

                SheetRec.Eps_Key = dr["EPISODE_KEY"].ToString();
                SheetRec.SheetDate = dr["order_date"].ToString();
                SheetRec.SheetDesc = dr["ShortHand"].ToString();
                SheetRec.SheetType = dr["Type"].ToString();
                SheetRec.SheetTime = dr["order_date"].ToString();
                SheetRec.SheetClass = "SheetClassV " + dr["type"].ToString();
                SheetRec.PID = dr["Patient_id"].ToString();

                switch (dr["status"].ToString().ToUpper())
                {
                    case "0":
                        SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Recoreded;
                        break;
                    case "1":
                        SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Signed;
                        break;
                    case "-1":
                        SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Cancelled;
                        break;
                }
            }
            #endregion


            #region SheetsSysPara
            dtresult = dal.GetSheetsDataEps(Eps_Key, Patient_ID, HID);
            foreach (DataRow dr in dtresult.Rows)
            {
                if (SheetRes.Where(raad => raad.SheetType == dr["SheetType"].ToString() && raad.SheetCode == "0").Count() == 0)
                {
                    Sheet SheetRecTT = factory.createSheet();
                    SheetRecTT.User_Key = dal.getUserId();
                    SheetRecTT.SheetCode = "0";
                    // SheetRes.Add(SheetRec);

                    SheetRecTT.SheetDesc = dr["SheetType"].ToString();
                    SheetRecTT.SheetType = dr["SheetType"].ToString();

                    SheetRecTT.SheetClass = "SheetClassCSS " + dr["SheetType"].ToString();

                    SheetRecTT.PID = Patient_ID;
                    SheetRecTT.SheetOrd_Key = "0";
                    SheetRecTT.Sheet_Status = "0";
                    SheetRecTT.Sheet_Sheetkey = "0";
                    SheetRecTT.SheetDescStatus = "";//.Split("<br>".ToCharArray());
                    SheetRecTT.SheetStatus = ConstantsVariables.SheetStatus.Recoreded;
                    SheetRes.Add(SheetRecTT);
                }
                Sheet SheetRec = factory.createSheet();
                SheetRec.User_Key = dr["userid"].ToString();
                SheetRec.SheetCode = dr["SYS_KEY"].ToString();
                // SheetRes.Add(SheetRec);
                if (SheetRes.Where(raad => raad.SheetCode == dr["SYS_KEY"].ToString()).Count() == 0)
                {
                    SheetRes.Add(SheetRec);
                }
                SheetRec.SheetOrd_Key = dr["R_KEY"].ToString();
                SheetRec.Sheet_Status = dr["status"].ToString();
                SheetRec.Sheet_Sheetkey = dr["sheet_key"].ToString();
                SheetRec.OrderType = "1";

                SheetRec.Eps_Key = dr["EPISODE_KEY"].ToString();
                SheetRec.SheetDate = dr["order_date"].ToString();
                SheetRec.SheetDesc = dr["DESCRIPTION"].ToString();
                SheetRec.SheetType = dr["SheetType"].ToString();
                SheetRec.SheetTime = dr["Order_Time"].ToString();
                SheetRec.SheetClass = "SheetClassV " + dr["sheettype"].ToString();

                SheetRec.PID = dr["Patient_id"].ToString();
                SheetRec.SheetDescStatus = dr["InvordStatus"].ToString();//.Split("<br>".ToCharArray());

                bool xxcc = dal.IsEMRFavorites(SheetRec.SheetCode, "5", dal.getUserId(), dtfvr);
                if (xxcc == true)
                {
                    SheetRec.IsEMRFavorites = "1";
                    SheetRec.IconEMRFavorites = "Images/Gen/star_yellow.ico";
                }
                else
                {
                    SheetRec.IsEMRFavorites = "0";
                    SheetRec.IconEMRFavorites = "Images/Gen/star_grey.ico";
                }
                xxcc = dal.IsEMRSignOff(SheetRec.SheetOrd_Key, "9", dal.getUserId(), Patient_ID, dtsoff);
                if (xxcc == true)
                {
                    SheetRec.IsEMRSignOff = "1";
                    SheetRec.IconEMRSignOff = "Images/Gen/eye.png";

                }
                else
                {
                    SheetRec.IsEMRSignOff = "0";
                    SheetRec.IconEMRSignOff = "Images/Gen/eye_close.png";
                }
                try
                {
                    DataRow[] drs = dtsoff.Select("Service_Key = " + SheetRec.SheetOrd_Key);

                    if (drs.Length > -1)
                    {
                        SheetRec.UsersSignOff = new List<UserSignOff>();
                        foreach (DataRow sodr in drs)
                        {
                            UserSignOff so = new UserSignOff();
                            so.User_Key = sodr["staff_key"].ToString();
                            so.User_Name = sodr["staff_name"].ToString();
                            so.User_view_Date = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(sodr["SignOff_Date"].ToString()));  //sodr["SignOff_Date"].ToString();
                            SheetRec.UsersSignOff.Add(so);
                        }
                    }
                }
                catch { }
                switch (dr["gvstatus"].ToString().ToUpper())
                {
                    case "RECORDED NOT SIGNED":
                        SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Recoreded;
                        break;
                    case "SIGNED":
                        SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Signed;
                        break;
                    case "CANCELLED":
                        SheetRec.SheetStatus = ConstantsVariables.SheetStatus.Cancelled;
                        break;
                }
            }
            #endregion


            List<Sheet> shtres = new List<Sheet>();
            List<Sheet> shtres12 = SheetRes.Where(raad => raad.SheetCode == "0").ToList();
            foreach (Sheet s in shtres12)
            {
                shtres.Add(s);
                int Co = 0;
                foreach (Sheet sht in SheetRes)
                {
                    if (s.SheetType.ToUpper() == sht.SheetType.ToUpper())
                    {
                        if (sht.SheetCode != "0")
                        {
                            shtres.Add(sht);
                            Co++;
                        }
                    }
                }
                s.SheetCount = Co.ToString(); ;
            }

            List<Sheet> DrugResSorted = shtres.OrderByDescending(o => o.SheetType).ToList();
            List<SheetUI> SheetResUI = shtres.Cast<SheetUI>().ToList();

            //List<SheetUI> SheetResUI = SheetResBus.Cast<SheetUI>().ToList();

            foreach (SheetUI SheetItem in SheetResUI)
            {
                SheetItem.UpdateUI();
            }

            return JsonConvert.SerializeObject(SheetResUI);
        }

        //--GetAllPNotes BL
        public string GetAllPNotes(string PID, string User_ID, DateTime FromDate, DateTime ToDate)
        {

            List<Staff> DocPNoteUser = new List<Staff>();

            List<ClsDescStatus> res = new List<ClsDescStatus>();
            DataTable DsPallDt = null;

           // DashBord_DAL.PatDoc_DL db_access = new PatDoc_DL();
            DsPallDt = dal.GetPNotes(PID, User_ID, FromDate, ToDate);

            foreach (DataRow dr in DsPallDt.Rows)
            {
                // StringBuilder str = new StringBuilder();
                ClsDescStatus rs = new ClsDescStatus();
                rs.NotebtnsignV = "Collapsed";
                rs.PLAN_ACTION_NOTE = dr["PLAN_ACTION_NOTE"].ToString().Replace("class=\"atwho-query\"", "").Replace("class=\"atwho-inserted\"", "").Replace("data-atwho-at-query=", "");
                if (rs.PLAN_ACTION_NOTE.Trim() != "")
                {
                    rs.PLAN_ACTION_NOTE = "" + rs.PLAN_ACTION_NOTE.Trim();
                }
                rs.Serv_Desc = dr["Note_Text"].ToString().Replace("class=\"atwho-query\"", "").Replace("class=\"atwho-inserted\"", "").Replace("data-atwho-at-query=", "");
                rs.Order_Status = dr["status"].ToString();
                if (dr["Attach"].ToString() != "0")
                {
                    rs.AttachNote = "Images/Gen/page_attach.png";
                }
                else
                {
                    rs.AttachNote = "";
                }
                switch (dr["status"].ToString().ToUpper())
                {
                    case "0":
                        rs.SheetStatus = "Recorded";
                        break;
                    case "1":
                        rs.SheetStatus = "Signed";
                        break;
                    case "-1":
                        rs.SheetStatus = "Cancelled";
                        break;
                }

                rs.Sheet_FromTable = dr["fromsheets"].ToString();
                rs.StInvOrder = dr["Note_Text"].ToString().Replace("class=\"atwho-query\"", "").Replace("class=\"atwho-inserted\"", "").Replace("data-atwho-at-query=", "");
                rs.ReportKey = dr["ReportKey"].ToString();
                rs.eps_key = dr["EPISOD_KEY"].ToString();
                rs.OrdKey = dr["Note_id"].ToString();
                rs.Note_P_ID = dr["P_Note_ID"].ToString();
                rs.SheetDefKey = dr["Sheetkey"].ToString();
                rs.Staff_Name = dr["Staff_Name"].ToString();
                Staff sfff = new Staff();
                sfff.Staff_Name = rs.Staff_Name;

                if (DocPNoteUser.Where(ci => ci.Staff_Name == sfff.Staff_Name).ToList().Count == 0)
                {
                    DocPNoteUser.Add(sfff);
                }
                rs.ReportDesc = dr["description"].ToString();
                rs.ReportStatus = dr["status"].ToString();
                rs.Jd_Key = dr["jd_key"].ToString();
                rs.Staff_key = dr["note_signature"].ToString();
                rs.sigFlag = dr["sigFlag"].ToString();

                rs.Serv_Date = dr["Note_Date"].ToString() == "" ? DateTime.Now.ToShortDateString() : String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dr["Note_Date"].ToString()));// Idr["Collectdate"].ToString();
                rs.Serv_time = dr["Note_time"].ToString() == "" ? DateTime.Now.ToShortDateString() : String.Format("{0:HH:mm}", Convert.ToDateTime(dr["Note_time"].ToString()));// Idr["Collectdate"].ToString();
                if (dr["mods"].ToString() == "0" && dr["Modified"].ToString() == "1"
                || dr["mods"].ToString() == "1" && dr["Modified"].ToString() == "0")
                {
                    rs.NoteColor = "Red";
                }
                if (dr["fromsheets"].ToString() == "1")
                {
                    rs.IsSheet = true;
                }
                if (rs.IsSheet == true)
                {
                    if (rs.ReportStatus == "0")
                    {
                        rs.Icon_Status = "Images/SheetImages/new_sht.ico";
                        rs.NotebtnsignV = "Visible";
                    }
                    else if (rs.ReportStatus == "1")
                        rs.Icon_Status = "Images/SheetImages/sign_sht.ico";
                    else if (rs.ReportStatus == "-1")
                        rs.Icon_Status = "Images/SheetImages/cancel_sht.ico";

                    if (rs.ReportKey != "")
                    {
                        if (rs.ReportDesc == "")
                        {
                            rs.ReportDesc = "Report";
                        }
                    }
                    else
                    {
                        rs.ReportDesc = "Not Reported";
                    }
                }
                else
                {
                    rs.Icon_Status = "Images/PNoteImages/PNotes.png";
                }
                rs.PID = PID;
                rs.Order_type = "PNotes";
                res.Add(rs);
            }

            return JsonConvert.SerializeObject(res);
        }

        //--GetDocNGrp BL
        public string GetDocNGrp(string PID)
        {
           // DashBord_DAL.PatDoc_DL noe = new PatDoc_DL();
            List<ClsDocNGroup> res = new List<ClsDocNGroup>();
            DataTable DsDNG = dal.GetDocNoteGroup(PID);
            ClsDocNGroup g11 = new ClsDocNGroup();
            g11.Grp_key = "0";
            g11.Grp_desc = "All Group";
            res.Add(g11);
            foreach (DataRow dr in DsDNG.Rows)
            {
                ClsDocNGroup g = new ClsDocNGroup();
                g.Grp_key = dr["jd_key"].ToString();
                g.Grp_desc = dr["jd_ldesc"].ToString();
                res.Add(g);
            }
            return JsonConvert.SerializeObject(res);
        }

        public string SetOrderSheetSysParam(string Keys, string PID, string Eps_Key, string User_Id, string isPrivateSheet)
        {
            DashBord_DAL.PatPro_DL sheetsDl = new PatPro_DL(df.getDal());
            string str1 = "";
            if (Keys.Trim() != "")
            {
                Keys += "0";
                string str2 = Keys;
                char[] chArray = new char[1] { '^' };
                foreach (string str3 in str2.Split(chArray))
                {
                    if (str3 != "0")
                    {
                        string[] strArray = str3.Split('|');
                        str1 = strArray.Length != 1 ? (!(strArray[1].ToString() == "1") ? str1 + sheetsDl.SetOrderTemplate(strArray[0], PID, Eps_Key, User_Id) + "^" : str1 + sheetsDl.SetOrderSheet(strArray[0], PID, Eps_Key, User_Id) + "^") : str1 + sheetsDl.SetOrderSheet(strArray[0], PID, Eps_Key, User_Id) + "^";
                    }
                }
            }
            return str1;
        }

        public string SheetisPriavate(string HID)
        {
            string str = "";
          //  DashBord_DAL.PatDoc_DL dl = new PatDoc_DL();
            DataTable data = dal.SheetisPriavate(HID);
            if (data.Rows.Count > 0)
                str = data.Rows[0][0].ToString();
            str = "";
            return str;
        }

        // has NO implementation at all
        public void GetWebServerIP()
        {
           // DashBord_DAL.PatDoc_DL dl = new PatDoc_DL();
        }

        public string getNoteCount(string Patient_ID, DateTime FromDate, DateTime ToDate, string U_id)
        {
            //DashBord_DAL.PatDoc_DL dl = new PatDoc_DL();
            return dal.getNoteCount(Patient_ID, FromDate, ToDate, U_id);
        }

        public string getSheetReportsDef(string HId)
        {
            //DashBord_DAL.PatDoc_DL dl = new PatDoc_DL();
            return dal.getSheetReportsDef(HId);
        }

        public List<SheetsRep> getSheetReports(string HId)
        {
            //DashBord_DAL.PatDoc_DL dl = new PatDoc_DL();
            List<SheetsRep> sheetReports = new List<SheetsRep>();
            string str = dal.getSheetReports(HId);
            if (str == "")
                str = "0";

            DataTable data = dal.getSheetReportsBySysKey(str);
            sheetReports.Add(new SheetsRep()
            {
                id = "-444499",
                text = "Add Document"
            });

            foreach (DataRow row in data.Rows)
                sheetReports.Add(new SheetsRep()
                {
                    text = row["Description"].ToString(),
                    id = row["sys_key"].ToString()
                });


            return (sheetReports);
        }

        public List<Sheet> GetSheetsResultsByOrderKey(string Patient_ID, string OrderKey, string User_ID)
        {
            //DashBord_DAL.PatDoc_DL dl = new PatDoc_DL();
            //return JsonConvert.SerializeObject(dl.GetSheetsResultsByOrderKey(Patient_ID, OrderKey, User_ID));
            List<SheetUI> list = new List<SheetUI>();
            SheetFactory factory = new SheetFactory();
            List<Sheet> source = new List<Sheet>();
           // DashBord_DAL.PatDoc_DL dl = new PatDoc_DL();
            DataTable dtf1 = dal.EMRFavorites(dal.getUserId());
            DataTable dtf2 = dal.EMRSignOff("9", dal.getUserId(), Patient_ID);
            foreach (DataRow row in dal.GetSheetsDataByOrderKey(Patient_ID, OrderKey).Rows)
            {
                DataRow dr = row;
                if (source.Where<Sheet>((Func<Sheet, bool>)(raad => raad.SheetType == dr["SheetType"].ToString() && raad.SheetCode == "0")).Count<Sheet>() == 0)
                {
                    Sheet sheet = factory.createSheet();
                    sheet.User_Key = dal.getUserId();
                    sheet.SheetCode = "0";
                    sheet.SheetDesc = dr["SheetType"].ToString();
                    sheet.SheetType = dr["SheetType"].ToString();
                    sheet.Sheetsort = dr["SheetType"].ToString() + "0";
                    sheet.SheetClass = "SheetClassCSS " + dr["SheetType"].ToString();
                    sheet.PID = Patient_ID;
                    sheet.SheetOrd_Key = "0";
                    sheet.Sheet_Status = "0";
                    sheet.Sheet_Sheetkey = "0";
                    sheet.SheetDescStatus = "";
                    sheet.SheetStatus = SheetStatus.Recoreded;
                    source.Add(sheet);
                }
                Sheet sheet1 = factory.createSheet();
                sheet1.User_Key = dr["userid"].ToString();
                sheet1.SheetCode = dr["SYS_KEY"].ToString();
                if (source.Where<Sheet>((Func<Sheet, bool>)(raad => raad.SheetCode == dr["SYS_KEY"].ToString())).Count<Sheet>() == 0)
                    source.Add(sheet1);
                sheet1.SheetOrd_Key = dr["R_KEY"].ToString();
                sheet1.Sheet_Status = dr["status"].ToString();
                sheet1.Sheet_Sheetkey = dr["sheet_key"].ToString();
                sheet1.OrderType = "1";
                sheet1.Eps_Key = dr["EPISODE_KEY"].ToString();
                sheet1.SheetDate = dr["order_date"].ToString();
                sheet1.SheetDesc = dr["DESCRIPTION"].ToString();
                sheet1.SheetType = dr["SheetType"].ToString();
                sheet1.Sheetsort = dr["SheetType"].ToString() + "1";
                sheet1.SheetTime = dr["Order_Time"].ToString();
                sheet1.SheetClass = "SheetClassV " + dr["sheettype"].ToString();
                sheet1.PID = dr["Patient_id"].ToString();
                sheet1.SheetDescStatus = dr["InvordStatus"].ToString();
                if (dal.IsEMRFavorites(sheet1.SheetCode, "5", dal.getUserId(), dtf1))
                {
                    sheet1.IsEMRFavorites = "1";
                    sheet1.IconEMRFavorites = "Images/Gen/star_yellow.ico";
                }
                else
                {
                    sheet1.IsEMRFavorites = "0";
                    sheet1.IconEMRFavorites = "Images/Gen/star_grey.ico";
                }
                if (dal.IsEMRSignOff(sheet1.SheetOrd_Key, "9", dal.getUserId(), Patient_ID, dtf2))
                {
                    sheet1.IsEMRSignOff = "1";
                    sheet1.IconEMRSignOff = "Images/Gen/eye.png";
                }
                else
                {
                    sheet1.IsEMRSignOff = "0";
                    sheet1.IconEMRSignOff = "Images/Gen/eye_close.png";
                }
                try
                {
                    DataRow[] dataRowArray = dtf2.Select("Service_Key = " + sheet1.SheetOrd_Key);
                    if (dataRowArray.Length > -1)
                    {
                        sheet1.UsersSignOff = new List<UserSignOff>();
                        foreach (DataRow dataRow in dataRowArray)
                            sheet1.UsersSignOff.Add(new UserSignOff()
                            {
                                User_Key = dataRow["staff_key"].ToString(),
                                User_Name = dataRow["staff_name"].ToString(),
                                User_view_Date = string.Format("{0:yyyy-MM-dd HH:mm}", (object)Convert.ToDateTime(dataRow["SignOff_Date"].ToString()))
                            });
                    }
                }
                catch
                {
                }
                string upper = dr["gvstatus"].ToString().ToUpper();
                if (!(upper == "RECORDED NOT SIGNED"))
                {
                    if (!(upper == "SIGNED"))
                    {
                        if (upper == "CANCELLED")
                            sheet1.SheetStatus = SheetStatus.Cancelled;
                    }
                    else
                        sheet1.SheetStatus = SheetStatus.Signed;
                }
                else
                    sheet1.SheetStatus = SheetStatus.Recoreded;
            }
            foreach (DataRow row in dal.GetTemplatesDataByOrderKey(Patient_ID, OrderKey).Rows)
            {
                DataRow dr = row;
                if (source.Where<Sheet>((Func<Sheet, bool>)(raad => raad.SheetType == dr["Type"].ToString() && raad.SheetCode == "0")).Count<Sheet>() == 0)
                {
                    Sheet sheet = factory.createSheet();
                    sheet.User_Key = dal.getUserId();
                    sheet.SheetCode = "0";
                    sheet.SheetDesc = dr["Type"].ToString();
                    sheet.SheetType = dr["Type"].ToString();
                    sheet.SheetClass = "SheetClassCSS " + dr["Type"].ToString();
                    sheet.PID = Patient_ID;
                    sheet.SheetOrd_Key = "0";
                    sheet.Sheet_Status = "0";
                    sheet.Sheet_Sheetkey = "0";
                    sheet.SheetDescStatus = dr["InvordStatus"].ToString();
                    sheet.SheetStatus = SheetStatus.Recoreded;
                    source.Add(sheet);
                }
                Sheet sheet2 = factory.createSheet();
                sheet2.User_Key = dr["userid"].ToString();
                sheet2.SheetCode = dr["def_key"].ToString();
                if (source.Where<Sheet>((Func<Sheet, bool>)(raad => raad.SheetCode == dr["def_key"].ToString())).Count<Sheet>() == 0)
                    source.Add(sheet2);
                sheet2.SheetOrd_Key = dr["orderkey"].ToString() == "" ? "0" : dr["orderkey"].ToString();
                sheet2.Sheet_Status = dr["status"].ToString();
                sheet2.Sheet_Sheetkey = dr["def_key"].ToString();
                sheet2.OrderType = "10";
                sheet2.Eps_Key = dr["EPISODE_KEY"].ToString();
                sheet2.SheetDate = dr["order_date"].ToString();
                sheet2.SheetDesc = dr["ShortHand"].ToString();
                sheet2.SheetType = dr["Type"].ToString();
                sheet2.SheetTime = dr["order_date"].ToString();
                sheet2.SheetClass = "SheetClassV " + dr["type"].ToString();
                sheet2.PID = dr["Patient_id"].ToString();
                string upper = dr["status"].ToString().ToUpper();
                if (!(upper == "0"))
                {
                    if (!(upper == "1"))
                    {
                        if (upper == "-1")
                            sheet2.SheetStatus = SheetStatus.Cancelled;
                    }
                    else
                        sheet2.SheetStatus = SheetStatus.Signed;
                }
                else
                    sheet2.SheetStatus = SheetStatus.Recoreded;
                if (dr["isprivatesheet"].ToString() == "1")
                {
                    sheet2.IsPrivate = "1";
                    sheet2.IconPrivate = "Images/Gen/Lock.png";
                }
                else
                {
                    sheet2.IsPrivate = "0";
                    sheet2.IconPrivate = "Images/Gen/Unlock.png";
                }
                if (dal.IsEMRFavorites(sheet2.SheetCode, "88", dal.getUserId(), dtf1))
                {
                    sheet2.IsEMRFavorites = "1";
                    sheet2.IconEMRFavorites = "Images/Gen/star_yellow.ico";
                }
                else
                {
                    sheet2.IsEMRFavorites = "0";
                    sheet2.IconEMRFavorites = "Images/Gen/star_grey.ico";
                }
            }
           // List<SheetUI> SheetResUI = source.Cast<SheetUI>().ToList();
            foreach (Sheet sheetUi in source)
            {
                sheetUi.SheetStatusDesc = sheetUi.SheetStatus.ToString();
                sheetUi.SheetStatusDesc = sheetUi.SheetStatusDesc.Replace("Recoreded", "Recorded");
                if (sheetUi.SheetDate != null)
                {
                    sheetUi.SheetDateDisplay = String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(sheetUi.SheetDate.ToString()));  // this.InvDate.ToString();
                }
                else
                {
                    if (sheetUi.SheetCode == "0")
                    {
                        sheetUi.SheetStatusDesc = "Recorded";
                    }
                    else
                    {
                        sheetUi.SheetStatusDesc = "Open";
                    }
                }
                if (sheetUi.SheetTime != null)
                    sheetUi.SheetTimeDisplay = String.Format("{0:HH:mm}", Convert.ToDateTime(sheetUi.SheetTime.ToString()));  // this.InvDate.ToString();

                if (sheetUi.OrderType == "2")
                {
                    sheetUi.SheetStatusImg = "Images/ProcImages/book_open.ico";
                }
                else if (sheetUi.OrderType == "3")
                {
                    sheetUi.SheetStatusImg = "Images/OPTImages/OrderOPT.png";
                }
                else
                {
                    switch (sheetUi.SheetStatus)
                    {
                        case ConstantsVariables.SheetStatus.Cancelled:
                            sheetUi.SheetStatusImg = "Images/SheetImages/cancel_sht.ico";
                            break;
                        case ConstantsVariables.SheetStatus.Recoreded:
                            sheetUi.SheetStatusImg = "Images/SheetImages/new_sht.ico";
                            break;
                        case ConstantsVariables.SheetStatus.Signed:
                            sheetUi.SheetStatusImg = "Images/SheetImages/sign_sht.ico";
                            break;
                    }
                }
            }
               // sheetUi.UpdateUI();
            return (source);
        }

        public string getQuery(string query)
        {
          //  DashBord_DAL.PatDoc_DL dl = new PatDoc_DL();
            return dal.executeQuery(query);
        }
       
    }
}
