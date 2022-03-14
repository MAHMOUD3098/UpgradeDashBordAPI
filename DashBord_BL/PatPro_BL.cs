using DashBord_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
namespace DashBord_BL
{

   public class PatPro_BL
    {

        public string GetEMRAccessModule(string UserKey)
        {
            string Res = "";
            if (UserKey.Trim() == "")
            { return ""; }

            DashBord_DAL.PatPro_DL EMRAcc = new DashBord_DAL.PatPro_DL();
            EMRAcc.GetAccess(UserKey, false);
            if (EMRAcc.LaborartoryVisible == true)
            { Res += "lab,"; }
            if (EMRAcc.RadiologyVisible == true)
            { Res += "rad,"; }
            if (EMRAcc.MedicationsVisible == true)
            { Res += "med,"; }
            if (EMRAcc.ProceduresVisible == true)
            { Res += "proc,"; }
            if (EMRAcc.MedicalSheetsVisible == true)
            { Res += "sht,"; }
            if (EMRAcc.OperationsVisible == true)
            { Res += "opt,"; }
            if (EMRAcc.DoctorNotesVisible == true)
            { Res += "dnote,"; }
            if (EMRAcc.ConsultationsVisible == true)
            { Res += "cons,"; }
            if (EMRAcc.BloodBankVisible == true)
            { Res += "bbank,"; }
            if (EMRAcc.IVVisible == true)
            { Res += "ivs,"; }
            if (EMRAcc.AssessmentVisible == true)
            { Res += "Ass,"; }
            if (EMRAcc.ChemotherabyVisible == true)
            { Res += "Chemo,"; }
            if (EMRAcc.ConsumablesVisible == true)
            { Res += "Consum,"; }
            if (EMRAcc.DoctorNotesVisible == true)
            { Res += "pnote,"; }
            if (EMRAcc.VitalSignsVisible == true)
            { Res += "vs,"; }

            if (EMRAcc.FaceSheetVisible == true)
            { Res += "FaceSheetVisible,"; }
            if (EMRAcc.ClinicalHistoryVisible == true)
            { Res += "ClinicalHistoryVisible,"; }
            if (EMRAcc.DietVisible == true)
            { Res += "DietVisible,"; }
            if (EMRAcc.PatientSummaryVisible == true)
            { Res += "PatientSummaryVisible,"; }
            if (EMRAcc.MedicalRecordVisible == true)
            { Res += "MedicalRecordVisible,"; }
            if (EMRAcc.ImmunizationVisible == true)
            { Res += "ImmunizationVisible,"; }
            if (EMRAcc.DischargeOrderVisible == true)
            { Res += "DischargeOrderVisible,"; }
            if (EMRAcc.PatientAcuityVisible == true)
            { Res += "PatientAcuityVisible,"; }
            if (EMRAcc.TransfersVisible == true)
            { Res += "TransfersVisible,"; }
            if (EMRAcc.FinanceVisible == true)
            { Res += "FinanceVisible,"; }
            if (EMRAcc.CarePlanVisible == true)
            { Res += "CarePlanVisible,"; }
            if (EMRAcc.DoctorInstructionsVisible == true)
            { Res += "DoctorInstructionsVisible,"; }



            if (EMRAcc.PastMedicalHistoryVisible == true)
            { Res += "PastMedicalHistoryVisible,"; }
            if (EMRAcc.PastSurgicalHistoryVisible == true)
            { Res += "PastSurgicalHistoryVisible,"; }
            if (EMRAcc.FamilyHistoryVisible == true)
            { Res += "FamilyHistoryVisible,"; }
            if (EMRAcc.SocialHistoryVisible == true)
            { Res += "SocialHistoryVisible,"; }
            if (EMRAcc.HabitsVisible == true)
            { Res += "HabitsVisible,"; }
            if (EMRAcc.RiskFactorsVisible == true)
            { Res += "RiskFactorsVisible,"; }
            if (EMRAcc.MedicationHistoryVisible == true)
            { Res += "MedicationHistoryVisible,"; }
            if (EMRAcc.AllergiesVisible == true)
            { Res += "AllergiesVisible,"; }
            if (EMRAcc.FoodorNonDrugAllergiesVisible == true)
            { Res += "FoodorNonDrugAllergiesVisible,"; }
            if (EMRAcc.ConsiderationsVisible == true)
            { Res += "ConsiderationsVisible,"; }
            if (EMRAcc.CoMorbiditiesVisible == true)
            { Res += "CoMorbiditiesVisible,"; }




            if (EMRAcc.ClinicalHistoryEnable == true)
            { Res += "ClinicalHistoryEnable,"; }
            if (EMRAcc.DietEnable == true)
            { Res += "DietEnable,"; }
            if (EMRAcc.PatientSummaryEnable == true)
            { Res += "PatientSummaryEnable,"; }
            if (EMRAcc.MedicalRecordEnable == true)
            { Res += "MedicalRecordEnable,"; }
            if (EMRAcc.ImmunizationEnable == true)
            { Res += "ImmunizationEnable,"; }
            if (EMRAcc.DischargeOrderEnable == true)
            { Res += "DischargeOrderEnable,"; }
            if (EMRAcc.PatientAcuityEnable == true)
            { Res += "PatientAcuityEnable,"; }
            if (EMRAcc.TransfersEnable == true)
            { Res += "TransfersEnable,"; }
            if (EMRAcc.FinanceEnable == true)
            { Res += "FinanceEnable,"; }
            if (EMRAcc.PatientStatusSetupEnable == true)
            { Res += "PatientStatusSetupEnable,"; }
            if (EMRAcc.DiagnosisEnable == true)
            { Res += "DiagnosisEnable,"; }
            if (EMRAcc.MRPEnable == true)
            { Res += "MRPEnable,"; }
            if (EMRAcc.WTandHTEnable == true)
            { Res += "WTandHTEnable,"; }
            if (EMRAcc.LocationEnable == true)
            { Res += "LocationEnable,"; }
            if (EMRAcc.ClinicalSheetEnable == true)
            { Res += "ClinicalSheetEnable,"; }




            //read only
            if (EMRAcc.Laborartory == true)
            { Res += "labRO,"; }
            if (EMRAcc.Radiology == true)
            { Res += "radRO,"; }
            if (EMRAcc.Medications == true)
            { Res += "medRO,"; }
            if (EMRAcc.Procedures == true)
            { Res += "procRO,"; }
            if (EMRAcc.MedicalSheets == true)
            { Res += "shtRO,"; }
            if (EMRAcc.Operations == true)
            { Res += "optRO,"; }
            if (EMRAcc.DoctorNotes == true)
            { Res += "dnoteRO,"; }
            if (EMRAcc.Consultations == true)
            { Res += "consRO,"; }
            if (EMRAcc.BloodBank == true)
            { Res += "bbankRO,"; }
            if (EMRAcc.IV == true)
            { Res += "ivsRO,"; }
            if (EMRAcc.Assessment == true)
            { Res += "AssRO,"; }
            if (EMRAcc.Chemotheraby == true)
            { Res += "ChemoRO,"; }
            if (EMRAcc.Consumables == true)
            { Res += "ConsumRO,"; }
            if (EMRAcc.DoctorNotes == true)
            { Res += "pnoteRO,"; }
            if (EMRAcc.VitalSigns == true)
            { Res += "vsRO,"; }
            return Res;
        }

        public string SetOrderSheet(string Keys, string PID, string Eps_Key, string User_Id)
        {
            string res = "";
            DashBord_DAL.PatPro_DL sh = new PatPro_DL();
            //SheetsDL sh = new SheetsDL();
            if (Keys.Trim() != "")
            {
                Keys += "0";
                string[] kk = Keys.Split('^');
                foreach (string ss in kk)
                {
                    if (ss != "0")
                    {
                        string[] yy = ss.Split('|');
                        if (yy.Length == 1)
                        {
                            res += sh.SetOrderSheet(yy[0], PID, Eps_Key, User_Id) + "^";

                        }
                        else
                        {
                            if (yy[1].ToString() == "1")
                                res += sh.SetOrderSheet(yy[0], PID, Eps_Key, User_Id) + "^";
                            else
                                res += sh.SetOrderTemplate(yy[0], PID, Eps_Key, User_Id) + "^";
                        }

                    }
                }
            }
            return res;
        }

        public string GetActiveProblems( string Patient_ID, string Eps_Key, string HID, string Type)
        {
            if (Patient_ID.Trim() == "")
            { return JsonConvert.SerializeObject(new List<ActiveProblems>()); }
            if (Eps_Key.Trim() == "")
            { return JsonConvert.SerializeObject(new List<ActiveProblems>()); }
            if (HID.Trim() == "")
            { return JsonConvert.SerializeObject(new List<ActiveProblems>()); }
            List<ActiveProblems> ActiveProRes = new List<ActiveProblems>();
            DashBord_DAL.PatPro_DL ActivePro = new DashBord_DAL.PatPro_DL();
            DataTable dtresult = null;
            dtresult = ActivePro.GetActiveProblems(Patient_ID, Eps_Key, HID, Type);
            foreach (DataRow dr in dtresult.Rows)
            {
                ActiveProblems ActProRes = null;

                ActProRes = new ActiveProblems();//factory.createActiveProblems();

                ActProRes.PID = Patient_ID;
                if (dr["Attach"].ToString() != "0")
                {
                    ActProRes.AttachNote = "Images/Gen/page_attach.png";
                }
                else
                {
                    ActProRes.AttachNote = "";
                }

                if (dr["isPrimary"].ToString() == "1")
                {
                    ActProRes.IsPrim = "Images/Gen/star_yellow.ico";
                }
                else
                {
                    ActProRes.IsPrim = "";
                }

                if (dr["DIAGNOSIS_ST"].ToString() == "394775005")
                {
                    ActProRes.IsSolved = "1";
                }
                if (dr["DIAGNOSIS_ST"].ToString() == "88")
                {
                    ActProRes.Cho_Is_Free = "Free";
                }
                else
                {
                    ActProRes.Cho_Is_Free = "Normal";
                }
                ActProRes.Note_ID = dr["Note_id"].ToString();
                ActProRes.Eps_Key = dr["EPISODE_KEY"].ToString();
                ActProRes.User_Key = dr["staffkey"].ToString();
                ActProRes.viewtype = dr["viewtype"].ToString();
                ActProRes.Term = dr["Term"].ToString();
                ActProRes.Remarks = dr["Remarks"].ToString();
                //ActProRes.Eps_Key = Eps_Key;
                if (dr["Problem_Date"].ToString() != "")
                {
                    ActProRes.AP_Date = String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(dr["Problem_Date"].ToString()));
                }
                ActProRes.AP_Desc = dr["Latin_Description"].ToString().Trim();
                if (dr["Status_LatinName"].ToString() == "ACTIVE")
                {
                    if (dr["diagnosis_type"].ToString() == "1")
                    {
                        //ActProRes.IsPrim = "Images/Gen/star_yellow.ico";
                        ActProRes.AP_Desc += "(P)";
                    }
                    else
                    {
                        ActProRes.AP_Desc += "(F)";
                        //ActProRes.IsPrim = "";
                    }
                }

                ActProRes.AP_Status = dr["Status_LatinName"].ToString() + " " + dr["pat_type"].ToString();
                ActProRes.CHO_Status = dr["STATUS_LOCALNAME"].ToString() + " " + dr["pat_type"].ToString();
                ActProRes.AP_PKey = dr["ProblemKey"].ToString();
                ActProRes.AP_Sys_Key = dr["SYS_KEY"].ToString();
                if (dr["ProblemKey"].ToString() == "0")
                    ActProRes.Link_Key = dr["sys_key"].ToString();
                else
                    ActProRes.Link_Key = dr["ProblemKey"].ToString();
                if (dr["Note_Date"].ToString() != "")
                    ActProRes.Note_Date = String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(dr["Note_Date"].ToString()));
                ActProRes.Note_Text = dr["Note_Text"].ToString().Replace("class=\"atwho-query\"", "").Replace("class=\"atwho-inserted\"", "").Replace("data-atwho-at-query=", "");
                if (dr["Note_Time"].ToString() != "")
                    ActProRes.Note_Time = String.Format("{0:HH:mm}", Convert.ToDateTime(dr["Note_Time"].ToString()));
                ActProRes.Staff_name = dr["Staff_name"].ToString();

                if ((ActiveProRes.Where(appc => appc.AP_Sys_Key == dr["SYS_KEY"].ToString() && appc.AP_PKey == dr["ProblemKey"].ToString()).Count() == 0))
                {
                    ActiveProRes.Add(ActProRes);
                }

            }
            return JsonConvert.SerializeObject(ActiveProRes);
        }

        public string  GetCInfoData( string Patient_ID, string Eps_key, string HID)
        {
            List<DashBord_DAL.ClinicalInfo> CInfoRes = new List<ClinicalInfo>();

            DashBord_DAL.PatPro_DL CInfo = new DashBord_DAL.PatPro_DL();
            DataTable dtresult = null;
            //User_key = DashBord_DAL.PatPro_DL.getUserId
            dtresult = CInfo.GetCliniclInfo(Patient_ID, HID, Eps_key);
            foreach (DataRow dr in dtresult.Rows)
            {
                ClinicalInfo CInfoRec = null;
                if (CInfoRes.Where(ci => ci.CInfoServType == dr["ServType"].ToString()).ToList().Count > 0)
                {
                    CInfoRec = CInfoRes.Where(ci => ci.CInfoServType == dr["ServType"].ToString()).ToList()[0];
                }
                else
                {
                    CInfoRec = new ClinicalInfo();
                    CInfoRes.Add(CInfoRec);
                }
                CInfoRec.PID = Patient_ID;
                CInfoRec.CInfoTitle = dr["title"].ToString();
                CInfoRec.CInfoCode = dr["Code"].ToString();
                CInfoRec.CInfoServType = dr["ServType"].ToString();
                if (CInfoRec.CInfoTitle == "Food/ND Allergies")
                {
                    string dd = "";
                }
                if (CInfoRec.CInfoDesc.ToString() == "Not Assessed,  " && CInfoRec.CInfoTitle == dr["title"].ToString())
                {

                    CInfoRec.CInfoDesc = CInfoRec.CInfoDesc.Replace("Not Assessed, ", "");
                    if (CInfoRec.CInfoDesc.Contains(dr["Description"].ToString()) == false)
                    {


                        CInfoRec.CInfoDesc += dr["Description"].ToString() + ",  ";
                        CInfoRec.User_Key = dr["Staff_key"].ToString();
                    }
                }
                else
                {
                    if (CInfoRec.CInfoDesc.Contains(dr["Description"].ToString()) == false)
                    {

                        if (dr["title"].ToString() == "Past Medical History (PMH)")
                        {
                            CInfoRec.isList = "1";
                            ClinicalInfo_Dtl ccc = new ClinicalInfo_Dtl();
                            ccc.CInfoDesc = dr["Description"].ToString();
                            ccc.Eps_Key = dr["Code"].ToString();
                            List<EpsItem> obj = GetEpsInfo(ccc.Eps_Key);
                            if (obj.Count > 0)
                            {
                                ccc.Eps_Info = obj[0].content; ;
                                ccc.FromDate = obj[0].FromDate; ;
                                ccc.ToDate = obj[0].ToDate; ;
                            }
                            CInfoRec.objEps_Info.Add(ccc);
                        }
                        else
                        {
                            CInfoRec.CInfoDesc += dr["Description"].ToString() + ",  ";
                            CInfoRec.User_Key = dr["Staff_key"].ToString();
                        }
                    }
                }

            }

            dtresult = CInfo.GetDietInfo(Patient_ID, Eps_key);
            foreach (DataRow dr in dtresult.Rows)
            {
                ClinicalInfo CInfoRec = null;
                if (CInfoRes.Where(ci => ci.CInfoServType == dr["ServType"].ToString()).ToList().Count > 0)
                {
                    CInfoRec = CInfoRes.Where(ci => ci.CInfoServType == dr["ServType"].ToString()).ToList()[0];
                }
                else
                {
                    CInfoRec = new ClinicalInfo();
                    CInfoRes.Add(CInfoRec);
                }
                CInfoRec.PID = Patient_ID;
                CInfoRec.CInfoTitle = dr["title"].ToString();
                CInfoRec.CInfoDesc += dr["Description"].ToString() + ",  ";
                CInfoRec.CInfoServType = dr["ServType"].ToString();

            }




            return JsonConvert.SerializeObject(CInfoRes);
        }

        public List<EpsItem> GetEpsInfo(string EpsKey)
        {

            int Eps_type=0;

            string Oreg_Key = "";
            DashBord_DAL.PatPro_DL gen = new DashBord_DAL.PatPro_DL();

            List<EpsItem> res = new List<EpsItem>();
            DataTable DsDt = gen.GetEpisodeForInPatient(EpsKey);
            gen.FillDatatableByEps(EpsKey);
            //EpsItem tt2 = new EpsItem();
            //tt2.Eps_key = "WXWX";
            //#region "OutPatient"
            //foreach (DataRow Dr in Dsout.Rows)
            //{
            //    EpsItem tt = new EpsItem();
            //    tt.Eps_key = Dr["episode_key"].ToString();
            //    tt.PID = Dr["PATIENT_ID"].ToString();
            //    string cxccc = "";
            //    if (Dr["status"].ToString() == "2")
            //    {
            //        cxccc = "<span style=\"color:red;\">not payed </span>";

            //    }
            //    else if (Dr["status"].ToString() == "3")
            //    {
            //        cxccc = "<span style=\"color:red;\">payed </span>";

            //    }
            //    else if (Dr["status"].ToString() == "4")
            //    {
            //        cxccc = "<span style=\"color:red;\">Ended </span>";

            //    }
            //    else if (Dr["status"].ToString() == "5")
            //    {
            //        cxccc = "<span style=\"color:green;\">Started </span>";
            //    }
            //    if (Dr["episode_type"].ToString() == "1")
            //    {
            //        cxccc += "<span style=\"color:red;\">(Closed)</span>";
            //    }
            //    else if (Dr["episode_type"].ToString() == "0")
            //    { cxccc += "<span style=\"color:green;\">(Open)</span>"; }
            //    else


            //    { cxccc += "<span style=\"color:red;\">(Not Started)</span>"; }

            //    //tt.FromDate = "" + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["start_date"].ToString()));//Dr["start_date"].ToString();
            //    //if (Dr["end_date"].ToString() != "")
            //    //    tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["end_date"].ToString())); //Dr["end_date"].ToString();
            //    //else
            //    //    tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(DateTime.Now.ToString())); //Dr["end_date"].ToString();

            //    string date_ss = "";
            //    string date_ee = "";
            //    //if (Dr["fromtime"].ToString() == Dr["totime"].ToString())
            //    //{ }
            //    //else
            //    //{
            //    tt.FromDate = "" + Dr["fromtime"].ToString();//Dr["start_date"].ToString();
            //    if (Dr["end_date"].ToString() != "")
            //        tt.ToDate = " " + Dr["totime"].ToString(); //Dr["end_date"].ToString();
            //    else
            //        tt.ToDate = " " + Dr["totime"].ToString(); //Dr["end_date"].ToString();

            //    date_ss = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(Convert.ToDateTime(Dr["regtime"].ToString()).ToShortDateString() + " " + Dr["fromtime"].ToString()));
            //    try
            //    {
            //        date_ee = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(Convert.ToDateTime(Dr["regtime"].ToString()).ToShortDateString() + " " + Dr["totime"].ToString()));
            //    }
            //    catch
            //    {
            //        date_ee = Convert.ToDateTime(date_ss).AddMinutes(15).ToString("o");
            //    }
            //    double xx = (Convert.ToDateTime(date_ee) - Convert.ToDateTime(date_ss)).TotalMinutes;
            //    //}
            //    tt.start = Convert.ToDateTime(date_ss).ToString("o");//Convert.ToDateTime(Dr["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
            //    // tt.end = null;
            //    if (xx < 15)
            //    {
            //        tt.end = Convert.ToDateTime(date_ss).AddMinutes(15).ToString("o");//Convert.ToDateTime(Dr["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
            //    }
            //    else
            //    {
            //        tt.end = Convert.ToDateTime(date_ee).ToString("o");//Convert.ToDateTime(Dr["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
            //    }

            //    string info = "";
            //    string Html_Diagnosis = "";
            //    if (tt.Eps_key == "")
            //    {
            //        // info = "<strong>Status: </strong> Not Started";
            //        // Html_Diagnosis = " <br>  <strong> Diagnosis : </strong> no Data ";
            //        gen.Oreg_Key = Dr["oreg_Key"].ToString();
            //        info = gen.GetInPatLocation("0");
            //    }
            //    else
            //    {
            //        gen.Eps_type = 2;
            //        gen.Oreg_Key = Dr["oreg_Key"].ToString();
            //        info = gen.GetInPatLocation(tt.Eps_key);
            //        Html_Diagnosis = " <br> ";
            //        //DataTable dt = gen.GetDiagnosis(tt.Eps_key, tt.PID);
            //        DataRow[] drsss = gen.tbl_Diagnosis.Select("episod_key = " + tt.Eps_key);
            //        foreach (DataRow dr in drsss)
            //        {
            //            if (dr["isPrimary"].ToString() == "1")
            //            {
            //                Html_Diagnosis += "  <strong> Primary Diagnosis</strong>  <br> ";
            //                string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
            //                Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + " <strong>  (" + cxc + ") </strong> <br> ";
            //            }
            //            else if (dr["isPrimary"].ToString() == "0")
            //            {
            //                if (Html_Diagnosis.Contains("Secondary Diagnosis") == false)
            //                { Html_Diagnosis += " <strong> Secondary Diagnosis </strong>  <br>  "; }

            //                string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
            //                Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + "  <strong>  (" + cxc + ") </strong>  <br> ";
            //            }
            //        }


            //    }
            //    if (gen.InPatMRPKey == User_ID)
            //    {
            //        tt.className = "orange";
            //    }
            //    tt.content = "<div  data-toggle='tooltip' style='display:inblock;text-align:left;'  data-container='body'  data-placement='bottom'   data-animation='fade'  data-trigger='hover' " +
            //            " title='<img src=\"Images/Gen/clinic.png\" width=\"15\"  />  <strong>" + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["regtime"].ToString())) + " (From " + tt.FromDate + " To " + tt.ToDate + ")</strong> " + cxccc +
            //            " <br>  " + gen.Financial_type + " <br>  " + gen.InPatSpec + " - " + gen.InPatMRP + "  <br> " + gen.InPatNote + " " + info + "" + Html_Diagnosis + "' data-html='true'><img src='Images/Gen/clinic.png'  width='15'  /> <span >Outpatient(From " + tt.FromDate + " To " + tt.ToDate + ")</span></div>";
            //    tt.group = "<div style='cursor: POINTER;' id='DivTimeLineVisits'><img src='Images/Gen/clinic.png' width='15'  /> <span>Visits</span></div>";
            //    res.Add(tt);
            //}
            //#endregion
            #region "InPatient"

            foreach (DataRow Dr in DsDt.Rows)
            {
                EpsItem tt = new EpsItem();

                tt.Eps_key = Dr["episod_key"].ToString();
                string cxccc = Dr["episode_type"].ToString() == "1" ? "<span style=\"color:red;\">Closed</span>" : "<span style=\"color:green;\">Open</span>";
                tt.FromDate = "" + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["start_date"].ToString()));//Dr["start_date"].ToString();
                if (Dr["end_date"].ToString() != "")
                    tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["end_date"].ToString())); //Dr["end_date"].ToString();
                else
                    tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(DateTime.Now.ToString())); //Dr["end_date"].ToString();




                if (Dr["systime"].ToString() != "")
                    tt.start = Convert.ToDateTime(Convert.ToDateTime(Dr["start_date"].ToString()).ToShortDateString() + " " + Convert.ToDateTime(Dr["systime"].ToString()).ToShortTimeString()).ToString("o");//Convert.ToDateTime(Dr["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
                if (Dr["end_date"].ToString() != "")
                    tt.end = Convert.ToDateTime(Dr["end_date"].ToString()).ToString("o");//.ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
                else
                {
                    if (Dr["pat_episode_typ"].ToString() == "2")
                    {
                        tt.end = Convert.ToDateTime(Dr["start_date"].ToString()).AddHours(1).ToString("o");//.ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
                    }
                    else
                    {
                        tt.end = Convert.ToDateTime(DateTime.Now.ToString()).ToString("o");//.ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
                    }
                }
                
                //if (Dr["episode_type"].ToString() == "0")
                //{
                //    tt.BgColor = "Green";
                //    tt.Status = "Open";
                //}
                //else
                //{
                //    tt.BgColor = "Red";
                //    tt.Status = "Close";
                //}
                if (Dr["pat_episode_typ"].ToString() == "1")
                {
                    //GeneralDL gen = new GeneralDL();
                    Eps_type = 1;

                    string info = gen.GetInPatLocation(tt.Eps_key);


                    DataTable dt = gen.getDiagnosis(EpsKey);
                    DataRow[] drsss = dt.Select("episod_key = " + tt.Eps_key);
                    string Html_Diagnosis = " <br> ";
                    foreach (DataRow dr in drsss)
                    {
                        if (dr["isPrimary"].ToString() == "1")
                        {
                            Html_Diagnosis += "  <strong> Primary Diagnosis</strong>  <br> ";
                            string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
                            Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + " <strong>  (" + cxc + ") </strong> <br> ";
                        }
                        else if (dr["isPrimary"].ToString() == "0")
                        {
                            if (Html_Diagnosis.Contains("Secondary Diagnosis") == false)
                            { Html_Diagnosis += " <strong> Secondary Diagnosis </strong>  <br>  "; }

                            string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
                            Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + "  <strong>  (" + cxc + ") </strong>  <br> ";
                        }
                    }
                    if (gen.getInPatMRPKey(EpsKey)== gen.getUserId() )
                    {
                        tt.className = "orange";
                    }
                    tt.content = "   <img src='Images/Gen/adm.png' width='15'  /> <span >Inpatient(From " + tt.FromDate + " To " + tt.ToDate + ")</span>  " + cxccc +
                        "  <br>  " + gen.getFinancial_type(tt.PID) + " <br>  " + gen.getInPatSpec(tt.PID) + " - " + gen.getInPatMRPKey(EpsKey) + "  <br> " + gen.getInPatNote() + " " + info + "" + Html_Diagnosis + "'  ";
                    // tt.group = "<div style='cursor: POINTER;' id='DivTimeLineAdmissions'><img src='Images/Gen/adm.png' width='15'  /> <span>Admissions</span></div>";
                }
                else if (Dr["pat_episode_typ"].ToString() == "2")
                {
                    DataRow Drvv = gen.GetEpisodeForOutPatient(EpsKey).Rows[0];

                    if (Drvv["status"].ToString() == "2")
                    {
                        cxccc = "<span style=\"color:red;\">not payed </span>";

                    }
                    else if (Drvv["status"].ToString() == "3")
                    {
                        cxccc = "<span style=\"color:red;\">payed </span>";

                    }
                    else if (Drvv["status"].ToString() == "4")
                    {
                        cxccc = "<span style=\"color:red;\">Ended </span>";

                    }
                    else if (Drvv["status"].ToString() == "5")
                    {
                        cxccc = "<span style=\"color:green;\">Started </span>";
                    }
                    if (Drvv["episode_type"].ToString() == "1")
                    {
                        cxccc += "<span style=\"color:red;\">(Closed)</span>";
                    }
                    else if (Drvv["episode_type"].ToString() == "0")
                    { cxccc += "<span style=\"color:green;\">(Open)</span>"; }
                    else


                    { cxccc += "<span style=\"color:red;\">(Not Started)</span>"; }

                    //tt.FromDate = "" + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Drvv["start_date"].ToString()));//Drvv["start_date"].ToString();
                    //if (Drvv["end_date"].ToString() != "")
                    //    tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Drvv["end_date"].ToString())); //Drvv["end_date"].ToString();
                    //else
                    //    tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(DateTime.Now.ToString())); //Drvv["end_date"].ToString();

                    string date_ss = "";
                    string date_ee = "";
                    //if (Drvv["fromtime"].ToString() == Drvv["totime"].ToString())
                    //{ }
                    //else
                    //{
                    tt.FromDate = "" + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["start_date"].ToString()));//Dr["start_date"].ToString();
                    if (Dr["end_date"].ToString() != "")
                        tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["end_date"].ToString())); //Dr["end_date"].ToString();
                    else
                        tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(DateTime.Now.ToString())); //Dr["end_date"].ToString();
                    string info = "";
                    string Html_Diagnosis = "";
                    if (Drvv["regtime"].ToString() != "")
                    {
                        date_ss = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(Convert.ToDateTime(Drvv["regtime"].ToString()).ToShortDateString() + " " + Drvv["fromtime"].ToString()));
                        try
                        {
                            date_ee = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(Convert.ToDateTime(Drvv["regtime"].ToString()).ToShortDateString() + " " + Drvv["totime"].ToString()));
                        }
                        catch
                        {
                            date_ee = Convert.ToDateTime(date_ss).AddMinutes(15).ToString("o");
                        }
                        double xx = (Convert.ToDateTime(date_ee) - Convert.ToDateTime(date_ss)).TotalMinutes;
                        //}
                        tt.start = Convert.ToDateTime(date_ss).ToString("o");//Convert.ToDateTime(Drvv["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
                                                                             // tt.end = null;
                        if (xx < 15)
                        {
                            tt.end = Convert.ToDateTime(date_ss).AddMinutes(15).ToString("o");//Convert.ToDateTime(Drvv["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
                        }
                        else
                        {
                            tt.end = Convert.ToDateTime(date_ee).ToString("o");//Convert.ToDateTime(Drvv["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
                        }


                        if (tt.Eps_key == "")
                        {
                            // info = "<strong>Status: </strong> Not Started";
                            // Html_Diagnosis = " <br>  <strong> Diagnosis : </strong> no Data ";
                            Oreg_Key = Drvv["oreg_Key"].ToString();
                            info = gen.GetInPatLocation("0");
                        }
                        else
                        {
                            Eps_type = 2;
                            Oreg_Key = Drvv["oreg_Key"].ToString();
                            info = gen.GetInPatLocation(tt.Eps_key);
                            Html_Diagnosis = " <br> ";
                            DataTable dt_Diagn = gen.getDiagnosis(tt.Eps_key);
                            DataRow[] drsss = dt_Diagn.Select("episod_key = " + tt.Eps_key);
                            foreach (DataRow dr in drsss)
                            {
                                if (dr["isPrimary"].ToString() == "1")
                                {
                                    Html_Diagnosis += "  <strong> Primary Diagnosis</strong>  <br> ";
                                    string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
                                    Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + " <strong>  (" + cxc + ") </strong> <br> ";
                                }
                                else if (dr["isPrimary"].ToString() == "0")
                                {
                                    if (Html_Diagnosis.Contains("Secondary Diagnosis") == false)
                                    { Html_Diagnosis += " <strong> Secondary Diagnosis </strong>  <br>  "; }

                                    string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
                                    Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + "  <strong>  (" + cxc + ") </strong>  <br> ";
                                }
                            }


                        }
                        
                        if (gen.getInPatMRPKey(EpsKey) == gen.getUserId())
                        {
                            tt.className = "orange";
                        }
                    }
                    string vvvdata = Drvv["regtime"].ToString() != "" ? String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Drvv["regtime"].ToString())) : "";
                    tt.content = "   <img src='Images/Gen/clinic.png'  width='15'  /> <span >Outpatient(From " + tt.FromDate + " To " + tt.ToDate + ") " + cxccc + "</span>      " +
                            " <br>  " + gen.getFinancial_type(tt.PID) + " <br>  " + gen.getInPatSpec(tt.PID) + " - " + gen.getInPatMRPKey(EpsKey) + "  <br> " + gen.getInPatNote() + " " + info + "" + Html_Diagnosis + "' ";
                    tt.group = "<div style='cursor: POINTER;' id='DivTimeLineVisits'><img src='Images/Gen/clinic.png' width='15'  /> <span>Visits</span></div>";
                }
                else if (Dr["pat_episode_typ"].ToString() == "9")
                {
                    // tt.PatType = "External Service: ";
                }



                tt.PID = Dr["PATIENT_ID"].ToString();
                res.Add(tt);
            }
            #endregion
            //res.Add(tt2);

            return res;
        }



        // new project 
        public string GetIsOrderEpisode(string Eps_Key)
        {
            string isOrderEpisode = "";
            string str = "";
            DashBord_DAL.PatPro_DL pp = new PatPro_DL();
            DataTable dt = pp.GetIsOrderEpisode(Eps_Key);
            if (dt.Rows.Count > 0)
                str = dt.Rows[0]["ExServices"].ToString();
            if (str == "9")
                isOrderEpisode = "Account Closed";
            return isOrderEpisode;
        }


        public string GetEnableOrderSets(string HID)
        {
            if (HID.Trim() == "")
            {
                return "";
            }
            DashBord_DAL.PatPro_DL obj = new PatPro_DL();
            return obj.GetEnableOrderSets(HID);
        }

        public string GetUserDefScreen(string User_Id)
        {
            DashBord_DAL.PatPro_DL dal = new PatPro_DL();
            DataTable dt = dal.GetUserDefScreen(User_Id);
            string userDefScreen = "";
            if (dt.Rows.Count > 0)
                return userDefScreen = dt.Rows[0][0].ToString();
            return "";
        }

        //  this fun return Eps_Status 
        public string Eps_Status(string Eps_Key) => new DashBord_DAL.PatPro_DL().Eps_Status(Eps_Key);

        //  this fun return GetGender 
        public string GetGender(string PID) => new DashBord_DAL.PatPro_DL().GetGender(PID);




        public string GetAssessmentsData(
        string Patient_ID,
        DateTime FromDate,
        DateTime ToDate)
        {
            DashBord_DAL.PatPro_DL assessmentsDl = new PatPro_DL();
            List<Assessments> assessmentsData = new List<Assessments>();
            foreach (DataRow row in (InternalDataCollectionBase)assessmentsDl.GetAssessmentsData(Patient_ID, FromDate, ToDate).Rows)
            {
                Assessments assessments = new Assessments();
                assessments.EpisodeKey = row["EpisodeKey"].ToString();
                assessments.Description = row["Description"].ToString();
                assessments.PATIENT_ID = row["PATIENT_ID"].ToString();
                assessments.ReportKey = row["ReportKey"].ToString();
                assessments.DateTimeStamp = string.Format("{0:dd-MMM-yyyy HH:mm}", (object)Convert.ToDateTime(row["DateTimeStamp"].ToString()));
                assessments.SheetDefKey = row["SheetDefKey"].ToString();
                assessments.SheetKey = row["SheetKey"].ToString();
                assessments.Staff_name = row["Staff_name"].ToString();
                assessments.Status = row["Status"].ToString();
                assessments.TemplateKey = row["TemplateKey"].ToString();
                assessments.User_Key = row["Staff_Key"].ToString();
                assessments.AttachNote = !(row["Attach"].ToString() != "0") ? "" : "Images/Gen/page_attach.png";
                if (assessments.Status == "0")
                {
                    assessments.Ico_Status = "Images/SheetImages/new_sht.ico";
                    assessments.Desc_Status = "Not Signed";
                }
                else
                {
                    assessments.Ico_Status = "Images/SheetImages/sign_sht.ico";
                    assessments.Desc_Status = "Signed";
                }
                assessmentsData.Add(assessments);
            }
            return JsonConvert.SerializeObject(assessmentsData);
        }


        public static string GetLastVisit(string PID, string Eps_key)
        {
            string lastVisit = "";
            DataTable dt = DashBord_DAL.PatPro_DL.GetLastVisit(PID, Eps_key);
            foreach (DataRow row in (InternalDataCollectionBase)dt.Rows)
            {
                lastVisit = string.Format("{0:yyyy-MM-dd}", (object)Convert.ToDateTime(dt.Rows[0]["start_date"].ToString()));
                lastVisit = Convert.ToDateTime(lastVisit).ToString("o");
            }
            return lastVisit;
        }



    }
}
