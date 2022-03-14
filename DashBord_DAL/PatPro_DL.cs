using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicaDAL;


namespace DashBord_DAL
{

    public class EpsItem
    {
        public string Eps_key { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public string FromDateDis { get; set; }
        public string ToDateDis { get; set; }

        public string Status { get; set; }
        public string PatType { get; set; }
        public string PID { get; set; }



        public string content { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string group { get; set; }
        public string className { get; set; }
        public string MoreData { get; set; }
        public string MoreDataTip { get; set; }

    }
    public class PatPro_DL
    {
        public string LAccessCode;
        public string LPatAccessCode;
        public bool VitalSigns;
        public bool Laborartory;
        public bool Radiology;
        public bool Medications;
        public bool Chemotheraby;
        public bool Procedures;
        public bool MedicalSheets;
        public bool Operations;
        public bool DoctorNotes;
        public bool NurseNotes;
        public bool DoctorInstructions;
        public bool Consultations;
        public bool PatientStatus;
        public bool Consumables;
        public bool BloodBank;
        public bool CarePlan;
        public bool PatientEducation;
        public bool IV;
        public bool Assessment;
        public bool FaceSheet;
        public bool VitalSignsVisible;
        public bool LaborartoryVisible;
        public bool RadiologyVisible;
        public bool MedicationsVisible;
        public bool ChemotherabyVisible;
        public bool ProceduresVisible;
        public bool MedicalSheetsVisible;
        public bool OperationsVisible;
        public bool DoctorNotesVisible;
        public bool NurseNotesVisible;
        public bool DoctorInstructionsVisible;
        public bool ConsultationsVisible;
        public bool PatientStatusVisible;
        public bool ConsumablesVisible;
        public bool BloodBankVisible;
        public bool CarePlanVisible;
        public bool PatientEducationVisible;
        public bool IVVisible;
        public bool AssessmentVisible;
        public bool FaceSheetVisible;
        public bool ClinicalHistoryVisible;
        public bool DietVisible;
        public bool PatientSummaryVisible;
        public bool MedicalRecordVisible;
        public bool ImmunizationVisible;
        public bool DischargeOrderVisible;
        public bool PatientAcuityVisible;
        public bool TransfersVisible;
        public bool FinanceVisible;
        public bool ClinicalHistoryEnable;
        public bool DietEnable;
        public bool PatientSummaryEnable;
        public bool MedicalRecordEnable;
        public bool ImmunizationEnable;
        public bool DischargeOrderEnable;
        public bool PatientAcuityEnable;
        public bool TransfersEnable;
        public bool FinanceEnable;
        public bool PatientStatusSetupEnable;
        public bool DiagnosisEnable;
        public bool WTandHTEnable;
        public bool MRPEnable;
        public bool LocationEnable;
        public bool ClinicalSheetEnable;

        public bool PastMedicalHistoryVisible;
        public bool PastSurgicalHistoryVisible;
        public bool FamilyHistoryVisible;
        public bool SocialHistoryVisible;
        public bool HabitsVisible;
        public bool RiskFactorsVisible;
        public bool MedicationHistoryVisible;
        public bool AllergiesVisible;
        public bool FoodorNonDrugAllergiesVisible;
        public bool ConsiderationsVisible;
        public bool CoMorbiditiesVisible;




        private MedicaDAL.DBInteraction dbcon;

        //public DateTime Utilities { get; private set; }

        public PatPro_DL()
        {
            dbcon = new MedicaDAL.DBInteraction(true);
        }

        //public bool VitalSignsVisible { get; private set; }


        public string getUserId()
        {
            return dbcon.UserKey;
        }

        public void GetAccess(string UserKey, bool isReadonly)
        {

            VitalSignsVisible = true;
            LaborartoryVisible = true;
            RadiologyVisible = true;
            MedicationsVisible = true;
            ProceduresVisible = true;
            MedicalSheetsVisible = true;
            OperationsVisible = true;
            DoctorNotesVisible = true;


            PastMedicalHistoryVisible = true;
            PastSurgicalHistoryVisible = true;
            FamilyHistoryVisible = true;
            SocialHistoryVisible = true;
            HabitsVisible = true;
            RiskFactorsVisible = true;
            MedicationHistoryVisible = true;
            AllergiesVisible = true;
            FoodorNonDrugAllergiesVisible = true;
            ConsiderationsVisible = true;
            CoMorbiditiesVisible = true;

            NurseNotesVisible = true;
            ChemotherabyVisible = true;
            DoctorInstructionsVisible = true;
            ConsultationsVisible = true;
            PatientStatusVisible = true;
            ConsumablesVisible = true;
            BloodBankVisible = true;
            PatientEducationVisible = true;
            CarePlanVisible = true;
            IVVisible = true;
            AssessmentVisible = true;
            FaceSheetVisible = true;
            ClinicalHistoryVisible = true;
            DietVisible = true;
            PatientSummaryVisible = true;
            MedicalRecordVisible = true;
            ImmunizationVisible = true;
            DischargeOrderVisible = true;
            PatientAcuityVisible = true;
            TransfersVisible = true;
            FinanceVisible = true;
            ClinicalHistoryEnable = true;
            DietEnable = true;
            PatientSummaryEnable = true;
            MedicalRecordEnable = true;
            ImmunizationEnable = true;
            DischargeOrderEnable = true;
            PatientAcuityEnable = true;
            TransfersEnable = true;
            FinanceEnable = true;
            PatientStatusSetupEnable = true;
            DiagnosisEnable = true;
            WTandHTEnable = true;
            MRPEnable = true;
            LocationEnable = true;
            ClinicalSheetEnable = true;
            DataTable EmrAcc = dbcon.GetData("select EMRAccess,PatStatusAccess,PatStatusEnabled from staff,jobdescription where staff.staff_fk = jo" +
            "bdescription.jd_key and staff_key =  " + UserKey);
            if (EmrAcc.Rows.Count > 0)
            {
                if (!(EmrAcc.Rows[0]["PatStatusAccess"] is DBNull))
                {
                    LPatAccessCode = EmrAcc.Rows[0]["PatStatusAccess"].ToString();
                    ClinicalHistoryVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(0, 1)));
                    DietVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(1, 1)));
                    PatientSummaryVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(2, 1)));
                    MedicalRecordVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(3, 1)));
                    ImmunizationVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(4, 1)));
                    DischargeOrderVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(5, 1)));
                    PatientAcuityVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(6, 1)));
                    TransfersVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(7, 1)));
                    FinanceVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(8, 1)));

                    PastMedicalHistoryVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(9, 1)));
                    PastSurgicalHistoryVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(10, 1)));
                    FamilyHistoryVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(11, 1)));
                    SocialHistoryVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(12, 1)));
                    HabitsVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(13, 1)));
                    RiskFactorsVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(14, 1)));
                    MedicationHistoryVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(15, 1)));
                    AllergiesVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(16, 1)));
                    FoodorNonDrugAllergiesVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(17, 1)));
                    ConsiderationsVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(18, 1)));
                    CoMorbiditiesVisible = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(19, 1)));

                }
                if (!(EmrAcc.Rows[0]["PatStatusEnabled"] is DBNull))
                {
                    LPatAccessCode = EmrAcc.Rows[0]["PatStatusEnabled"].ToString();
                    ClinicalHistoryEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(0, 1)));
                    DietEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(1, 1)));
                    PatientSummaryEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(2, 1)));
                    MedicalRecordEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(3, 1)));
                    ImmunizationEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(4, 1)));
                    DischargeOrderEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(5, 1)));
                    PatientAcuityEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(6, 1)));
                    TransfersEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(7, 1)));
                    FinanceEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(8, 1)));
                    //PatientStatusSetupEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(9, 1)));
                    DiagnosisEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(10, 1)));
                    //WTandHTEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(11, 1)));
                    //MRPEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(12, 1)));
                    //LocationEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(13, 1)));
                    //ClinicalSheetEnable = !Convert.ToBoolean(double.Parse(LPatAccessCode.Substring(14, 1)));
                }
                if (!(EmrAcc.Rows[0]["EMRAccess"] is DBNull))
                {
                    // GetAccess = EmrAcc.Rows[0]["EMRAccess"].ToString();
                    LAccessCode = EmrAcc.Rows[0]["EMRAccess"].ToString();
                    if ((double.Parse(LAccessCode.Substring(0, 1)) < 2))
                    {
                        VitalSigns = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(0, 1))) || isReadonly);
                    }
                    else
                    {
                        VitalSignsVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(0, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(1, 1)) < 2))
                    {
                        Laborartory = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(1, 1))) || isReadonly);
                    }
                    else
                    {
                        LaborartoryVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(1, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(2, 1)) < 2))
                    {
                        Radiology = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(2, 1))) || isReadonly);
                    }
                    else
                    {
                        RadiologyVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(2, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(3, 1)) < 2))
                    {
                        Medications = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(3, 1))) || isReadonly);
                    }
                    else
                    {
                        MedicationsVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(3, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(4, 1)) < 2))
                    {
                        Chemotheraby = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(4, 1))) || isReadonly);
                    }
                    else
                    {
                        ChemotherabyVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(4, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(5, 1)) < 2))
                    {
                        Procedures = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(5, 1))) || isReadonly);
                    }
                    else
                    {
                        ProceduresVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(5, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(6, 1)) < 2))
                    {
                        MedicalSheets = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(6, 1))) || isReadonly);
                    }
                    else
                    {
                        MedicalSheetsVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(6, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(7, 1)) < 2))
                    {
                        Operations = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(7, 1))) || isReadonly);
                    }
                    else
                    {
                        OperationsVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(7, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(8, 1)) < 2))
                    {
                        DoctorNotes = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(8, 1))) || isReadonly);
                    }
                    else
                    {
                        DoctorNotesVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(8, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(9, 1)) < 2))
                    {
                        NurseNotes = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(9, 1))) || isReadonly);
                    }
                    else
                    {
                        NurseNotesVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(9, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(10, 1)) < 2))
                    {
                        DoctorInstructions = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(10, 1))) || isReadonly);
                    }
                    else
                    {
                        DoctorInstructionsVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(10, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(11, 1)) < 2))
                    {
                        Consultations = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(11, 1))) || isReadonly);
                    }
                    else
                    {
                        ConsultationsVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(11, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(12, 1)) < 2))
                    {
                        PatientStatus = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(12, 1))) || isReadonly);
                    }
                    else
                    {
                        PatientStatusVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(12, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(13, 1)) < 2))
                    {
                        Consumables = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(13, 1))) || isReadonly);
                    }
                    else
                    {
                        ConsumablesVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(13, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(13, 1)) < 2))
                    {
                        Consumables = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(13, 1))) || isReadonly);
                    }
                    else
                    {
                        ConsumablesVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(13, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(14, 1)) < 2))
                    {
                        BloodBank = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(14, 1))) || isReadonly);
                    }
                    else
                    {
                        BloodBankVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(14, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(15, 1)) < 2))
                    {
                        PatientEducation = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(15, 1))) || isReadonly);
                    }
                    else
                    {
                        PatientEducationVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(15, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(16, 1)) < 2))
                    {
                        CarePlan = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(16, 1))) || isReadonly);
                    }
                    else
                    {
                        CarePlanVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(16, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(17, 1)) < 2))
                    {
                        IV = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(17, 1))) || isReadonly);
                    }
                    else
                    {
                        IVVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(17, 1)));
                    }
                    if ((double.Parse(LAccessCode.Substring(18, 1)) < 2))
                    {
                        Assessment = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(18, 1))) || isReadonly);
                    }
                    else
                    {
                        AssessmentVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(18, 1)));
                    }
                    try
                    {
                        if ((double.Parse(LAccessCode.Substring(19, 1)) < 2))
                        {
                            FaceSheet = (Convert.ToBoolean(double.Parse(LAccessCode.Substring(19, 1))) || isReadonly);
                        }
                        else
                        {
                            FaceSheetVisible = !Convert.ToBoolean(double.Parse(LAccessCode.Substring(19, 1)));
                        }
                    }
                    catch { }
                }
                else
                {
                    //GetAccess = "";
                    LAccessCode = "";
                    VitalSigns = true;
                    Laborartory = true;
                    Radiology = true;
                    Medications = true;
                    Chemotheraby = true;
                    Procedures = true;
                    MedicalSheets = true;
                    Operations = true;
                    DoctorNotes = true;
                    NurseNotes = true;
                    DoctorInstructions = true;
                    Consultations = true;
                    PatientStatus = true;
                    Consumables = true;
                    BloodBank = true;
                    CarePlan = true;
                    PatientEducation = true;
                    IV = true;
                    Assessment = true;
                    FaceSheet = true;
                }
            }
            else
            {
                // GetAccess = "";
                LAccessCode = "";
                VitalSigns = isReadonly;
                Laborartory = isReadonly;
                Radiology = isReadonly;
                Medications = isReadonly;
                Chemotheraby = isReadonly;
                Procedures = isReadonly;
                MedicalSheets = isReadonly;
                Operations = isReadonly;
                DoctorNotes = isReadonly;
                NurseNotes = isReadonly;
                DoctorInstructions = isReadonly;
                Consultations = isReadonly;
                PatientStatus = isReadonly;
                Consumables = isReadonly;
                BloodBank = isReadonly;
                CarePlan = isReadonly;
                PatientEducation = isReadonly;
                IVVisible = true;
                AssessmentVisible = true;
                FaceSheetVisible = true;
            }
            // TODO: On Error Resume Next Warning!!!: The statement is not translatable 

        }


        public string SetOrderSheet(string Keys, string PID, string Eps_Key, string User_Id)
        {
            string res = "";
            var SelectString = "insert into MSHEETORDER(Episode_Key,Patient_Id,UserID,Sheet_Key,Order_date,Order_time,Status) " +
                " values (" + Eps_Key + ",'" + PID + "'," + User_Id + "," + Keys + ",'" + Utilities.FormatDateClr(DateTime.Now) + "','" + DateTime.Now.ToShortTimeString() + "',0)";
            dbcon.ExecNonQuery(SelectString);
            SelectString = "select max(MSHEETORDER.sys_key) as sys_key  from MSHEETORDER  WITH (nolock)  order by sys_key desc";
            res = dbcon.ExecScalarQuery(SelectString).ToString();
            return res;
        }

        public string SetOrderTemplate(string Keys, string PID, string Eps_Key, string User_Id)
        {
            string res = "";
            var SelectString = "insert into TemplatesOrders(Episode_Key,Patient_Id,UserID,def_key,Order_date,Status) " +
                " values (" + Eps_Key + ",'" + PID + "'," + User_Id + "," + Keys + ",'" + Utilities.FormatDateClr(DateTime.Now) + " " + DateTime.Now.ToShortTimeString() + "',0)";
            dbcon.ExecNonQuery(SelectString);
            SelectString = "select max(TemplatesOrders.sys_key) as sys_key  from TemplatesOrders  WITH (nolock)  order by sys_key desc";
            res = dbcon.ExecScalarQuery(SelectString).ToString();
            SelectString = "update TemplatesOrders set orderkey = " + res + " where sys_key = " + res;
            this.dbcon.ExecNonQuery(SelectString);

            return res;
        }




        //public List<EpsItem> GetEpsInfo(string EpsKey)
        //{
        //    GeneralDL gen = new GeneralDL();

        //    List<EpsItem> res = new List<EpsItem>();
        //    DataTable DsDt = gen.GetEpisodeForInPatient(EpsKey);
        //    gen.FillDatatableByEps(EpsKey);
        //    //EpsItem tt2 = new EpsItem();
        //    //tt2.Eps_key = "WXWX";
        //    //#region "OutPatient"
        //    //foreach (DataRow Dr in Dsout.Rows)
        //    //{
        //    //    EpsItem tt = new EpsItem();
        //    //    tt.Eps_key = Dr["episode_key"].ToString();
        //    //    tt.PID = Dr["PATIENT_ID"].ToString();
        //    //    string cxccc = "";
        //    //    if (Dr["status"].ToString() == "2")
        //    //    {
        //    //        cxccc = "<span style=\"color:red;\">not payed </span>";

        //    //    }
        //    //    else if (Dr["status"].ToString() == "3")
        //    //    {
        //    //        cxccc = "<span style=\"color:red;\">payed </span>";

        //    //    }
        //    //    else if (Dr["status"].ToString() == "4")
        //    //    {
        //    //        cxccc = "<span style=\"color:red;\">Ended </span>";

        //    //    }
        //    //    else if (Dr["status"].ToString() == "5")
        //    //    {
        //    //        cxccc = "<span style=\"color:green;\">Started </span>";
        //    //    }
        //    //    if (Dr["episode_type"].ToString() == "1")
        //    //    {
        //    //        cxccc += "<span style=\"color:red;\">(Closed)</span>";
        //    //    }
        //    //    else if (Dr["episode_type"].ToString() == "0")
        //    //    { cxccc += "<span style=\"color:green;\">(Open)</span>"; }
        //    //    else


        //    //    { cxccc += "<span style=\"color:red;\">(Not Started)</span>"; }

        //    //    //tt.FromDate = "" + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["start_date"].ToString()));//Dr["start_date"].ToString();
        //    //    //if (Dr["end_date"].ToString() != "")
        //    //    //    tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["end_date"].ToString())); //Dr["end_date"].ToString();
        //    //    //else
        //    //    //    tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(DateTime.Now.ToString())); //Dr["end_date"].ToString();

        //    //    string date_ss = "";
        //    //    string date_ee = "";
        //    //    //if (Dr["fromtime"].ToString() == Dr["totime"].ToString())
        //    //    //{ }
        //    //    //else
        //    //    //{
        //    //    tt.FromDate = "" + Dr["fromtime"].ToString();//Dr["start_date"].ToString();
        //    //    if (Dr["end_date"].ToString() != "")
        //    //        tt.ToDate = " " + Dr["totime"].ToString(); //Dr["end_date"].ToString();
        //    //    else
        //    //        tt.ToDate = " " + Dr["totime"].ToString(); //Dr["end_date"].ToString();

        //    //    date_ss = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(Convert.ToDateTime(Dr["regtime"].ToString()).ToShortDateString() + " " + Dr["fromtime"].ToString()));
        //    //    try
        //    //    {
        //    //        date_ee = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(Convert.ToDateTime(Dr["regtime"].ToString()).ToShortDateString() + " " + Dr["totime"].ToString()));
        //    //    }
        //    //    catch
        //    //    {
        //    //        date_ee = Convert.ToDateTime(date_ss).AddMinutes(15).ToString("o");
        //    //    }
        //    //    double xx = (Convert.ToDateTime(date_ee) - Convert.ToDateTime(date_ss)).TotalMinutes;
        //    //    //}
        //    //    tt.start = Convert.ToDateTime(date_ss).ToString("o");//Convert.ToDateTime(Dr["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
        //    //    // tt.end = null;
        //    //    if (xx < 15)
        //    //    {
        //    //        tt.end = Convert.ToDateTime(date_ss).AddMinutes(15).ToString("o");//Convert.ToDateTime(Dr["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
        //    //    }
        //    //    else
        //    //    {
        //    //        tt.end = Convert.ToDateTime(date_ee).ToString("o");//Convert.ToDateTime(Dr["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
        //    //    }

        //    //    string info = "";
        //    //    string Html_Diagnosis = "";
        //    //    if (tt.Eps_key == "")
        //    //    {
        //    //        // info = "<strong>Status: </strong> Not Started";
        //    //        // Html_Diagnosis = " <br>  <strong> Diagnosis : </strong> no Data ";
        //    //        gen.Oreg_Key = Dr["oreg_Key"].ToString();
        //    //        info = gen.GetInPatLocation("0");
        //    //    }
        //    //    else
        //    //    {
        //    //        gen.Eps_type = 2;
        //    //        gen.Oreg_Key = Dr["oreg_Key"].ToString();
        //    //        info = gen.GetInPatLocation(tt.Eps_key);
        //    //        Html_Diagnosis = " <br> ";
        //    //        //DataTable dt = gen.GetDiagnosis(tt.Eps_key, tt.PID);
        //    //        DataRow[] drsss = gen.tbl_Diagnosis.Select("episod_key = " + tt.Eps_key);
        //    //        foreach (DataRow dr in drsss)
        //    //        {
        //    //            if (dr["isPrimary"].ToString() == "1")
        //    //            {
        //    //                Html_Diagnosis += "  <strong> Primary Diagnosis</strong>  <br> ";
        //    //                string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
        //    //                Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + " <strong>  (" + cxc + ") </strong> <br> ";
        //    //            }
        //    //            else if (dr["isPrimary"].ToString() == "0")
        //    //            {
        //    //                if (Html_Diagnosis.Contains("Secondary Diagnosis") == false)
        //    //                { Html_Diagnosis += " <strong> Secondary Diagnosis </strong>  <br>  "; }

        //    //                string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
        //    //                Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + "  <strong>  (" + cxc + ") </strong>  <br> ";
        //    //            }
        //    //        }


        //    //    }
        //    //    if (gen.InPatMRPKey == User_ID)
        //    //    {
        //    //        tt.className = "orange";
        //    //    }
        //    //    tt.content = "<div  data-toggle='tooltip' style='display:inblock;text-align:left;'  data-container='body'  data-placement='bottom'   data-animation='fade'  data-trigger='hover' " +
        //    //            " title='<img src=\"Images/Gen/clinic.png\" width=\"15\"  />  <strong>" + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["regtime"].ToString())) + " (From " + tt.FromDate + " To " + tt.ToDate + ")</strong> " + cxccc +
        //    //            " <br>  " + gen.Financial_type + " <br>  " + gen.InPatSpec + " - " + gen.InPatMRP + "  <br> " + gen.InPatNote + " " + info + "" + Html_Diagnosis + "' data-html='true'><img src='Images/Gen/clinic.png'  width='15'  /> <span >Outpatient(From " + tt.FromDate + " To " + tt.ToDate + ")</span></div>";
        //    //    tt.group = "<div style='cursor: POINTER;' id='DivTimeLineVisits'><img src='Images/Gen/clinic.png' width='15'  /> <span>Visits</span></div>";
        //    //    res.Add(tt);
        //    //}
        //    //#endregion
        //    #region "InPatient"

        //    foreach (DataRow Dr in DsDt.Rows)
        //    {
        //        EpsItem tt = new EpsItem();

        //        tt.Eps_key = Dr["episod_key"].ToString();
        //        string cxccc = Dr["episode_type"].ToString() == "1" ? "<span style=\"color:red;\">Closed</span>" : "<span style=\"color:green;\">Open</span>";
        //        tt.FromDate = "" + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["start_date"].ToString()));//Dr["start_date"].ToString();
        //        if (Dr["end_date"].ToString() != "")
        //            tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["end_date"].ToString())); //Dr["end_date"].ToString();
        //        else
        //            tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(DateTime.Now.ToString())); //Dr["end_date"].ToString();




        //        if (Dr["systime"].ToString() != "")
        //            tt.start = Convert.ToDateTime(Convert.ToDateTime(Dr["start_date"].ToString()).ToShortDateString() + " " + Convert.ToDateTime(Dr["systime"].ToString()).ToShortTimeString()).ToString("o");//Convert.ToDateTime(Dr["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
        //        if (Dr["end_date"].ToString() != "")
        //            tt.end = Convert.ToDateTime(Dr["end_date"].ToString()).ToString("o");//.ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
        //        else
        //        {
        //            if (Dr["pat_episode_typ"].ToString() == "2")
        //            {
        //                tt.end = Convert.ToDateTime(Dr["start_date"].ToString()).AddHours(1).ToString("o");//.ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
        //            }
        //            else
        //            {
        //                tt.end = Convert.ToDateTime(DateTime.Now.ToString()).ToString("o");//.ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
        //            }
        //        }
        //        //if (tt.Eps_key == Eps_Key)
        //        //{
        //        //    tt.BgColorCE = "Yellow";
        //        //}
        //        //if (Dr["episode_type"].ToString() == "0")
        //        //{
        //        //    tt.BgColor = "Green";
        //        //    tt.Status = "Open";
        //        //}
        //        //else
        //        //{
        //        //    tt.BgColor = "Red";
        //        //    tt.Status = "Close";
        //        //}
        //        if (Dr["pat_episode_typ"].ToString() == "1")
        //        {
        //            //GeneralDL gen = new GeneralDL();
        //            gen.Eps_type = 1;

        //            string info = gen.GetInPatLocation(tt.Eps_key);


        //            // DataTable dt = gen.GetDiagnosis(tt.Eps_key, tt.PID);
        //            DataRow[] drsss = gen.tbl_Diagnosis.Select("episod_key = " + tt.Eps_key);
        //            string Html_Diagnosis = " <br> ";
        //            foreach (DataRow dr in drsss)
        //            {
        //                if (dr["isPrimary"].ToString() == "1")
        //                {
        //                    Html_Diagnosis += "  <strong> Primary Diagnosis</strong>  <br> ";
        //                    string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
        //                    Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + " <strong>  (" + cxc + ") </strong> <br> ";
        //                }
        //                else if (dr["isPrimary"].ToString() == "0")
        //                {
        //                    if (Html_Diagnosis.Contains("Secondary Diagnosis") == false)
        //                    { Html_Diagnosis += " <strong> Secondary Diagnosis </strong>  <br>  "; }

        //                    string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
        //                    Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + "  <strong>  (" + cxc + ") </strong>  <br> ";
        //                }
        //            }
        //            if (gen.InPatMRPKey == )
        //            {
        //                tt.className = "orange";
        //            }
        //            tt.content = "   <img src='Images/Gen/adm.png' width='15'  /> <span >Inpatient(From " + tt.FromDate + " To " + tt.ToDate + ")</span>  " + cxccc +
        //                "  <br>  " + gen.Financial_type + " <br>  " + gen.InPatSpec + " - " + gen.InPatMRP + "  <br> " + gen.InPatNote + " " + info + "" + Html_Diagnosis + "'  ";
        //            // tt.group = "<div style='cursor: POINTER;' id='DivTimeLineAdmissions'><img src='Images/Gen/adm.png' width='15'  /> <span>Admissions</span></div>";
        //        }
        //        else if (Dr["pat_episode_typ"].ToString() == "2")
        //        {
        //            DataRow Drvv = gen.GetEpisodeForOutPatient(EpsKey).Rows[0];

        //            if (Drvv["status"].ToString() == "2")
        //            {
        //                cxccc = "<span style=\"color:red;\">not payed </span>";

        //            }
        //            else if (Drvv["status"].ToString() == "3")
        //            {
        //                cxccc = "<span style=\"color:red;\">payed </span>";

        //            }
        //            else if (Drvv["status"].ToString() == "4")
        //            {
        //                cxccc = "<span style=\"color:red;\">Ended </span>";

        //            }
        //            else if (Drvv["status"].ToString() == "5")
        //            {
        //                cxccc = "<span style=\"color:green;\">Started </span>";
        //            }
        //            if (Drvv["episode_type"].ToString() == "1")
        //            {
        //                cxccc += "<span style=\"color:red;\">(Closed)</span>";
        //            }
        //            else if (Drvv["episode_type"].ToString() == "0")
        //            { cxccc += "<span style=\"color:green;\">(Open)</span>"; }
        //            else


        //            { cxccc += "<span style=\"color:red;\">(Not Started)</span>"; }

        //            //tt.FromDate = "" + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Drvv["start_date"].ToString()));//Drvv["start_date"].ToString();
        //            //if (Drvv["end_date"].ToString() != "")
        //            //    tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Drvv["end_date"].ToString())); //Drvv["end_date"].ToString();
        //            //else
        //            //    tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(DateTime.Now.ToString())); //Drvv["end_date"].ToString();

        //            string date_ss = "";
        //            string date_ee = "";
        //            //if (Drvv["fromtime"].ToString() == Drvv["totime"].ToString())
        //            //{ }
        //            //else
        //            //{
        //            tt.FromDate = "" + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["start_date"].ToString()));//Dr["start_date"].ToString();
        //            if (Dr["end_date"].ToString() != "")
        //                tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Dr["end_date"].ToString())); //Dr["end_date"].ToString();
        //            else
        //                tt.ToDate = " " + String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(DateTime.Now.ToString())); //Dr["end_date"].ToString();
        //            string info = "";
        //            string Html_Diagnosis = "";
        //            if (Drvv["regtime"].ToString() != "")
        //            {
        //                date_ss = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(Convert.ToDateTime(Drvv["regtime"].ToString()).ToShortDateString() + " " + Drvv["fromtime"].ToString()));
        //                try
        //                {
        //                    date_ee = String.Format("{0:yyyy-MM-dd HH:mm}", Convert.ToDateTime(Convert.ToDateTime(Drvv["regtime"].ToString()).ToShortDateString() + " " + Drvv["totime"].ToString()));
        //                }
        //                catch
        //                {
        //                    date_ee = Convert.ToDateTime(date_ss).AddMinutes(15).ToString("o");
        //                }
        //                double xx = (Convert.ToDateTime(date_ee) - Convert.ToDateTime(date_ss)).TotalMinutes;
        //                //}
        //                tt.start = Convert.ToDateTime(date_ss).ToString("o");//Convert.ToDateTime(Drvv["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
        //                                                                     // tt.end = null;
        //                if (xx < 15)
        //                {
        //                    tt.end = Convert.ToDateTime(date_ss).AddMinutes(15).ToString("o");//Convert.ToDateTime(Drvv["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
        //                }
        //                else
        //                {
        //                    tt.end = Convert.ToDateTime(date_ee).ToString("o");//Convert.ToDateTime(Drvv["start_date"].ToString()).ToString("ddd MMM dd yyyy HH':'mm':'ss ") + " GMT+0200  (Egypt Standard Time)";
        //                }


        //                if (tt.Eps_key == "")
        //                {
        //                    // info = "<strong>Status: </strong> Not Started";
        //                    // Html_Diagnosis = " <br>  <strong> Diagnosis : </strong> no Data ";
        //                    gen.Oreg_Key = Drvv["oreg_Key"].ToString();
        //                    info = gen.GetInPatLocation("0");
        //                }
        //                else
        //                {
        //                    gen.Eps_type = 2;
        //                    gen.Oreg_Key = Drvv["oreg_Key"].ToString();
        //                    info = gen.GetInPatLocation(tt.Eps_key);
        //                    Html_Diagnosis = " <br> ";
        //                    //DataTable dt = gen.GetDiagnosis(tt.Eps_key, tt.PID);
        //                    DataRow[] drsss = gen.tbl_Diagnosis.Select("episod_key = " + tt.Eps_key);
        //                    foreach (DataRow dr in drsss)
        //                    {
        //                        if (dr["isPrimary"].ToString() == "1")
        //                        {
        //                            Html_Diagnosis += "  <strong> Primary Diagnosis</strong>  <br> ";
        //                            string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
        //                            Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + " <strong>  (" + cxc + ") </strong> <br> ";
        //                        }
        //                        else if (dr["isPrimary"].ToString() == "0")
        //                        {
        //                            if (Html_Diagnosis.Contains("Secondary Diagnosis") == false)
        //                            { Html_Diagnosis += " <strong> Secondary Diagnosis </strong>  <br>  "; }

        //                            string cxc = dr["diagnosis_type"].ToString() == "1" ? "Provisional" : "Final";
        //                            Html_Diagnosis += "- " + dr["code"].ToString() + ":" + dr["description"].ToString().Replace("'", "") + "  <strong>  (" + cxc + ") </strong>  <br> ";
        //                        }
        //                    }


        //                }
        //                if (gen.InPatMRPKey == User_ID)
        //                {
        //                    tt.className = "orange";
        //                }
        //            }
        //            string vvvdata = Drvv["regtime"].ToString() != "" ? String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(Drvv["regtime"].ToString())) : "";
        //            tt.content = "   <img src='Images/Gen/clinic.png'  width='15'  /> <span >Outpatient(From " + tt.FromDate + " To " + tt.ToDate + ") " + cxccc + "</span>      " +
        //                    " <br>  " + gen.Financial_type + " <br>  " + gen.InPatSpec + " - " + gen.InPatMRP + "  <br> " + gen.InPatNote + " " + info + "" + Html_Diagnosis + "' ";
        //            tt.group = "<div style='cursor: POINTER;' id='DivTimeLineVisits'><img src='Images/Gen/clinic.png' width='15'  /> <span>Visits</span></div>";
        //        }
        //        else if (Dr["pat_episode_typ"].ToString() == "9")
        //        {
        //            // tt.PatType = "External Service: ";
        //        }



        //        tt.PID = Dr["PATIENT_ID"].ToString();
        //        res.Add(tt);
        //    }
        //    #endregion
        //    //res.Add(tt2);

        //    return res;
        //}


        //2 error
        public System.Data.DataTable GetCliniclInfo(string Patt_ID, string P_HospitalID, string Eps_key)
        {
            // 924,935 
            string User_key = dbcon.UserKey;
            var SelectString = "exec GetClinicalInfo '" + Patt_ID + "','" + P_HospitalID + "','" + Eps_key + "'";
            return dbcon.GetData(SelectString);


            SelectString = "select DISTINCT 1 as ServType ,'Allergies' as  title, 'No Known Allergies' AS Description ,  PATALLERGIES.allegrieskey as Code , Staff.Staff_Key , 1 as SortType  " +
                            " FROM  PATALLERGIES  WITH (nolock)   LEFT OUTER JOIN Staff  WITH (nolock)  ON dbo.PATALLERGIES.Allergy_UserKey = dbo.Staff.Staff_Key " +
                            " WHERE   PATALLERGIES.allegrieskey = -555  and (PATALLERGIES.patient_id = @Patt_ID) " +
                            " and PATALLERGIES.Allergy_Status = 1 ";

            SelectString += " union select DISTINCT 1 as ServType ,'Allergies' as  title, 'Unable to Assess' AS Description ,  PATALLERGIES.allegrieskey as Code  , Staff.Staff_Key , 1 as SortType " +
                            " FROM  PATALLERGIES  WITH (nolock)  LEFT OUTER JOIN Staff  WITH (nolock)  ON dbo.PATALLERGIES.Allergy_UserKey = dbo.Staff.Staff_Key " +
                            " WHERE   PATALLERGIES.allegrieskey = -666  and (PATALLERGIES.patient_id = @Patt_ID ) " +
                            " and PATALLERGIES.Allergy_Status = 1 ";

            SelectString += " union select DISTINCT 1 as ServType ,'Allergies' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key , 1 as SortType " +

                          " WHERE   ((select count(*) from PATALLERGIES where  (PATALLERGIES.patient_id = @Patt_ID) " +
                          " and PATALLERGIES.Allergy_Status = 1 )  " +
                          " + (select count(*) from PatOtherAllergies where  (PatOtherAllergies.patient_id = @Patt_ID) " +
                          " and PatOtherAllergies.Status = 1) ) = 0 ";

            SelectString += " union select DISTINCT 1 as ServType  ,'Allergies' as  title, ISNULL(PATALLERGIES.CUSTOMDESC,REPLACE(ALLEGIES.LATIN_DESC,'HYPERSENSITIVITY','')) AS Description " +
                                " ,  PATALLERGIES.allegrieskey as Code  , Staff.Staff_Key  , 1 as SortType " +
                            " FROM  dbo.PATALLERGIES  WITH (nolock)    left outer JOIN  " +
                            " dbo.Allegies WITH (NOLOCK) ON dbo.PATALLERGIES.allegrieskey = dbo.Allegies.SYS_KEY LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (nolock)  ON dbo.PATALLERGIES.Allergy_UserKey = dbo.Staff.Staff_Key left outer join " +
                            " PatAllergyReactions on PATALLERGIES.Sys_Key = PatAllergyReactions.PatAllergyKey left outer join " +
                            " GENERAL_COD on PatAllergyReactions.Reaction_Key = GENERAL_COD.sub_cod and GENERAL_COD.main_cod = 305 " +
                            " WHERE    (PATALLERGIES.patient_id = @Patt_ID) " +
                            " and PATALLERGIES.Allergy_Status = 1 and PATALLERGIES.AllergyType = 0   ";

            SelectString += " union select DISTINCT 1 as ServType  ,'Allergies' as  title, " +
                        " ISNULL(PATALLERGIES.CUSTOMDESC,REPLACE(ALLEGIES.LATIN_DESC,'HYPERSENSITIVITY','')) AS Description , " +
                        "  PATALLERGIES.allegrieskey as Code  , Staff.Staff_Key , 1 as SortType " +
                          " FROM  dbo.PATALLERGIES  WITH (nolock) left outer JOIN DBO.ALLEGIES WITH (NOLOCK) ON DBO.PATALLERGIES.ALLEGRIESKEY = DBO.ALLEGIES.SYS_KEY  " +
                            "  LEFT OUTER JOIN " +
                          " dbo.Staff  WITH (nolock)  ON dbo.PATALLERGIES.Allergy_UserKey = dbo.Staff.Staff_Key left outer join " +
                          " PatAllergyReactions  WITH (nolock)  on PATALLERGIES.Sys_Key = PatAllergyReactions.PatAllergyKey left outer join " +
                          " GENERAL_COD  WITH (nolock)  on PatAllergyReactions.Reaction_Key = GENERAL_COD.sub_cod and GENERAL_COD.main_cod = 305 " +
                          " WHERE    (PATALLERGIES.patient_id = @Patt_ID) " +
                          " and PATALLERGIES.Allergy_Status = 1 and PATALLERGIES.AllergyType > 0   ";

            SelectString += " union select DISTINCT 1 as ServType  ,'Allergies' as  title , PatOtherAllergies.OtherAllergyName AS Description ,  -1 as Code   , Staff.Staff_Key , 1 as SortType " +
                            " FROM   dbo.PatOtherAllergies  WITH (nolock) 	LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (nolock)  ON dbo.PatOtherAllergies.UserKey = dbo.Staff.Staff_Key left outer join " +
                            " PatOtherAllergyReactions  WITH (nolock)  on PatOtherAllergies.Sys_Key = PatOtherAllergyReactions.PatOtherAllergyKey left outer join " +
                            " GENERAL_COD  WITH (nolock)  on PatOtherAllergyReactions.Reaction_Key = GENERAL_COD.sub_cod and GENERAL_COD.main_cod = 305 " +
                            " WHERE   (PatOtherAllergies.patient_id = @Patt_ID) " +
                            " and PatOtherAllergies.Status = 1 ";


            SelectString += " union select DISTINCT 2 as ServType ,'Food/ND Allergies' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key , 2 as SortType  " +

               " WHERE   ((select count(*) from PatFoodAllergies where  (PatFoodAllergies.patient_id = @Patt_ID) " +
               " and PatFoodAllergies.Status = 1) + (select count(*) from PatOtherFoodAllergies where  (PatOtherFoodAllergies.patient_id = @Patt_ID) " +
               " and PatOtherFoodAllergies.Status = 1) ) = 0 ";

            SelectString += " union select DISTINCT 2 as ServType ,'Food/ND Allergies' as title, 'No Known Food Allergies' AS Description ,  PatFoodAllergies.Ingredient_Key as Code  , Staff.Staff_Key  , 2 as SortType  " +
                            " FROM  PatFoodAllergies  WITH (nolock)  LEFT OUTER JOIN Staff  WITH (nolock)  ON dbo.PatFoodAllergies.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE   PatFoodAllergies.Ingredient_Key = -555  and (PatFoodAllergies.PATIENT_ID = @Patt_ID) " +
                            " and PatFoodAllergies.Status = 1 ";

            SelectString += " union select DISTINCT 2 as ServType  ,'Food/ND Allergies' as title , 'Unable to Assess' AS Description ,  PatFoodAllergies.Ingredient_Key as Code  , Staff.Staff_Key  , 2 as SortType  " +
                            " FROM  PatFoodAllergies  WITH (nolock)  LEFT OUTER JOIN Staff  WITH (nolock)  ON dbo.PatFoodAllergies.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE PatFoodAllergies.Ingredient_Key = -666  and (PatFoodAllergies.PATIENT_ID = @Patt_ID) " +
                            " and PatFoodAllergies.Status = 1 ";

            SelectString += " union select DISTINCT 2 as ServType  ,'Food/ND Allergies' as title , ISNULL(PATFOODALLERGIES.CUSTOMDESC,FoodAllergiesView.ITEM_NAME_LATIN) AS Description ,  PatFoodAllergies.Ingredient_Key  as Code  , Staff.Staff_Key  , 2 as SortType  " +
                            " FROM dbo.PatFoodAllergies  WITH (nolock)  INNER JOIN " +
                            " dbo.FoodAllergiesView  WITH (nolock)   ON dbo.PatFoodAllergies.Ingredient_Key = dbo.FoodAllergiesView.Item_Code LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (nolock)  ON dbo.PatFoodAllergies.UserKey = dbo.Staff.Staff_Key left outer join  " +
                            " PatFoodAllergyReactions  WITH (nolock)  on PatFoodAllergies.Sys_Key = PatFoodAllergyReactions.PatFoodAllergyKey left outer join  " +
                            " GENERAL_COD  WITH (nolock)  on PatFoodAllergyReactions.Reaction_Key = GENERAL_COD.sub_cod and GENERAL_COD.main_cod = 305 " +
                            " WHERE   (PatFoodAllergies.patient_id = @Patt_ID) " +
                            " and PatFoodAllergies.Status = 1 ";


            SelectString += " union select DISTINCT 2 as ServType  ,'Food/ND Allergies' as title , PatOtherFoodAllergies.OtherFoodAllergyName AS Description ,  -1  as Code  , Staff.Staff_Key  , 2 as SortType   " +
                            " FROM PatOtherFoodAllergies  WITH (nolock)  LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (nolock)  ON dbo.PatOtherFoodAllergies.UserKey = dbo.Staff.Staff_Key left outer join " +
                            " PatOtherFoodAllergyReactions  WITH (nolock)  on PatOtherFoodAllergies.Sys_Key = PatOtherFoodAllergyReactions.PatOtherFoodAllergyKey left outer join " +
                            " GENERAL_COD  WITH (nolock)  on PatOtherFoodAllergyReactions.Reaction_Key = GENERAL_COD.sub_cod and GENERAL_COD.main_cod = 305 " +
                            " WHERE   (PatOtherFoodAllergies.patient_id = @Patt_ID) " +
                            " and PatOtherFoodAllergies.Status = 1 ";


            SelectString += " union select DISTINCT 3 as ServType ,'Risk Factors' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key  , 5 as SortType   " +

              " WHERE   ((select count(*) from Clinical_RiskFactor where  (Clinical_RiskFactor.patient_id = @Patt_ID) " +
              " and Clinical_RiskFactor.Status = 1  and ProcessID IN (57, 59, 62, 63, 64, 113)) + " +
              " (select count(*) from PatOtherRiskFactor where  (PatOtherRiskFactor.patient_id = @Patt_ID) " +
              " and PatOtherRiskFactor.Status = 1  and ProcessID IN (57, 59, 62, 63, 64, 113)) ) = 0 ";


            SelectString += " union select DISTINCT 3 as ServType , 'Risk Factors' as title, 'No Known Risk Factors' AS Description ,  Clinical_RiskFactor.AttribID as Code  , Staff.Staff_Key  , 5 as SortType  " +
                            " FROM Clinical_RiskFactor  WITH (nolock)    LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (nolock)    ON dbo.Clinical_RiskFactor.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE   Clinical_RiskFactor.AttribID = -555  and (Clinical_RiskFactor.PATIENT_ID = @Patt_ID) " +
                            " and Clinical_RiskFactor.Status = 1 and ProcessID IN (57, 59, 62, 63, 64, 113) ";

            SelectString += " union select DISTINCT 3 as ServType , 'Risk Factors' as title , ISNULL(CLINICAL_RISKFACTOR.CUSTOMDESC,CLINICAL_ATTRIBUTES.TERM) AS Description ,   Clinical_Attributes.AttribID as Code  , Staff.Staff_Key   , 5 as SortType  " +
                            " FROM dbo.Clinical_Attributes  WITH (NOLOCK) INNER JOIN " +
                            " dbo.Clinical_RiskFactor  WITH (NOLOCK) ON dbo.Clinical_Attributes.AttribID = dbo.Clinical_RiskFactor.AttribID LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (NOLOCK) ON dbo.Clinical_RiskFactor.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE    (Clinical_RiskFactor.PATIENT_ID = @Patt_ID) " +
                            " and Clinical_RiskFactor.Status = 1 and Clinical_RiskFactor.ProcessID IN (57, 59, 62, 63, 64, 113)";


            SelectString += " union select DISTINCT 3 as ServType , 'Risk Factors' as title , OtherRiskFactorName AS Description ,   -1  as Code  , Staff.Staff_Key  , 5 as SortType  " +
                            " FROM  PatOtherRiskFactor  WITH (NOLOCK)  LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (NOLOCK) ON dbo.PatOtherRiskFactor.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE    (PatOtherRiskFactor.PATIENT_ID = @Patt_ID) " +
                            " and PatOtherRiskFactor.Status = 1 and ProcessID IN (57, 59, 62, 63, 64, 113)";

            SelectString += " union select DISTINCT 66 as ServType ,'Family History' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key  , 4 as SortType  " +

            " WHERE   ((select count(*) from Clinical_RiskFactor where  (Clinical_RiskFactor.patient_id = @Patt_ID) " +
            " and Clinical_RiskFactor.Status = 1  and ProcessID IN (58)) + (select count(*) from PatOtherRiskFactor where  (PatOtherRiskFactor.patient_id = @Patt_ID) " +
            " and PatOtherRiskFactor.Status = 1  and ProcessID IN (58)) ) = 0 ";


            SelectString += " union select DISTINCT 66 as ServType , 'Family History' as title, 'No Known Family History' AS Description ,  Clinical_RiskFactor.AttribID as Code  , Staff.Staff_Key  , 4 as SortType  " +
                          " FROM Clinical_RiskFactor  WITH (NOLOCK) LEFT OUTER JOIN " +
                          " dbo.Staff  WITH (NOLOCK) ON dbo.Clinical_RiskFactor.UserKey = dbo.Staff.Staff_Key " +
                          " WHERE   Clinical_RiskFactor.AttribID = -555  and (Clinical_RiskFactor.PATIENT_ID = @Patt_ID) " +
                          " and Clinical_RiskFactor.Status = 1 and ProcessID IN (58) ";

            SelectString += " union select DISTINCT 66 as ServType , 'Family History' as title ,ISNULL(CLINICAL_RISKFACTOR.CUSTOMDESC,CLINICAL_ATTRIBUTES.TERM) AS Description ,   Clinical_Attributes.AttribID as Code  , Staff.Staff_Key  , 4 as SortType  " +
                            " FROM dbo.Clinical_Attributes  WITH (NOLOCK) INNER JOIN " +
                            " dbo.Clinical_RiskFactor  WITH (NOLOCK) ON dbo.Clinical_Attributes.AttribID = dbo.Clinical_RiskFactor.AttribID LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (NOLOCK) ON dbo.Clinical_RiskFactor.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE    (Clinical_RiskFactor.PATIENT_ID = @Patt_ID) " +
                            " and Clinical_RiskFactor.Status = 1 and Clinical_Attributes.ProcessID IN (58)";


            SelectString += " union select DISTINCT 66 as ServType , 'Family History' as title , OtherRiskFactorName AS Description ,   -1  as Code  , Staff.Staff_Key  , 4 as SortType  " +
                            " FROM  PatOtherRiskFactor  WITH (NOLOCK)  LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (NOLOCK) ON dbo.PatOtherRiskFactor.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE    (PatOtherRiskFactor.PATIENT_ID = @Patt_ID) " +
                            " and PatOtherRiskFactor.Status = 1 and PatOtherRiskFactor.ProcessID IN (58)";
            //80-Resolved Diagnosis
            SelectString += " union SELECT     DISTINCT 123 as ServType ,'Past History' as title ,  VDIAGNOSIS.DIAGNOSIS AS Description , -1  as Code  , PATDIAGNOSIS.STAFFKEY as Staff_Key  , 66 as SortType  " +
" FROM         DBO.EPISODE WITH (NOLOCK) INNER JOIN " +
"                      DBO.PATDIAGNOSIS WITH (NOLOCK) ON DBO.EPISODE.EPISOD_KEY = DBO.PATDIAGNOSIS.EPISODE_KEY INNER JOIN " +
"                      DBO.VDIAGNOSIS(@P_HospitalID) as VDIAGNOSIS ON DBO.PATDIAGNOSIS.SYS_KEY = VDIAGNOSIS.SYS_KEY  " +
" WHERE     (DBO.PATDIAGNOSIS.DIAGNOSIS_STATUS <> 5 ) AND (PATDIAGNOSIS.NOTACTIVE =0 OR PATDIAGNOSIS.NOTACTIVE IS NULL)  and (PATDIAGNOSIS.PATIENT_ID= @Patt_ID) " +
" AND  PATDIAGNOSIS.DIAGNOSIS_ST IN (394775005) AND VDIAGNOSIS.DIAGNOSIS IS NOT NULL   " +
" UNION " +
" SELECT     DISTINCT 123 as ServType ,'Past History' as title ,  PATDIAGNOSIS.FREETXT  AS Description, -1  as Code  , PATDIAGNOSIS.STAFFKEY as Staff_Key , 66 as SortType  " +
" FROM         DBO.EPISODE WITH (NOLOCK) INNER JOIN " +
"                      DBO.PATDIAGNOSIS WITH (NOLOCK) ON DBO.EPISODE.EPISOD_KEY = DBO.PATDIAGNOSIS.EPISODE_KEY  " +
" WHERE     (DBO.PATDIAGNOSIS.DIAGNOSIS_STATUS <> 5 ) AND (PATDIAGNOSIS.NOTACTIVE =0 OR PATDIAGNOSIS.NOTACTIVE IS NULL)   " +
" AND  DIAGNOSIS_ST IN (394775005) AND PATDIAGNOSIS.FREETXT IS NOT NULL AND PATDIAGNOSIS.ONLYFREETXT = 1  and (PATDIAGNOSIS.PATIENT_ID = @Patt_ID)  ";



            SelectString += " union select DISTINCT 123 as ServType ,'Past History' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key , 5 as SortType  " +

            " WHERE   ((select count(*) from Clinical_RiskFactor where  (Clinical_RiskFactor.patient_id = @Patt_ID) " +
            " and Clinical_RiskFactor.Status = 1  and ProcessID IN (61)) + (select count(*) from PatOtherRiskFactor where  (PatOtherRiskFactor.patient_id = @Patt_ID) " +
            " and PatOtherRiskFactor.Status = 1  and ProcessID IN (61)) ) = 0 ";

            SelectString += " union select DISTINCT 123 as ServType , 'Past History' as title, 'No Known Past History' AS Description ,  Clinical_RiskFactor.AttribID as Code  , Staff.Staff_Key  , 5 as SortType " +
                           " FROM Clinical_RiskFactor  WITH (NOLOCK) LEFT OUTER JOIN " +
                           " dbo.Staff  WITH (NOLOCK) ON dbo.Clinical_RiskFactor.UserKey = dbo.Staff.Staff_Key " +
                           " WHERE   Clinical_RiskFactor.AttribID = -555  and (Clinical_RiskFactor.PATIENT_ID = @Patt_ID) " +
                           " and Clinical_RiskFactor.Status = 1 and ProcessID IN (61) ";

            SelectString += " union select DISTINCT 123 as ServType , 'Past History' as title , ISNULL(CLINICAL_RISKFACTOR.CUSTOMDESC,CLINICAL_ATTRIBUTES.TERM) AS Description ,   Clinical_Attributes.AttribID as Code  , Staff.Staff_Key  , 5 as SortType  " +
                            " FROM dbo.Clinical_Attributes  WITH (NOLOCK) INNER JOIN " +
                            " dbo.Clinical_RiskFactor  WITH (NOLOCK) ON dbo.Clinical_Attributes.AttribID = dbo.Clinical_RiskFactor.AttribID LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (NOLOCK) ON dbo.Clinical_RiskFactor.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE    (Clinical_RiskFactor.PATIENT_ID = @Patt_ID) " +
                            " and Clinical_RiskFactor.Status = 1 and Clinical_Attributes.ProcessID IN (61)";


            SelectString += " union select DISTINCT 123 as ServType , 'Past History' as title , OtherRiskFactorName AS Description ,   -1  as Code  , Staff.Staff_Key  , 5 as SortType  " +
                            " FROM  PatOtherRiskFactor  WITH (NOLOCK)  LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (NOLOCK) ON dbo.PatOtherRiskFactor.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE    (PatOtherRiskFactor.PATIENT_ID = @Patt_ID) " +
                            " and PatOtherRiskFactor.Status = 1 and PatOtherRiskFactor.ProcessID IN (61)";

            SelectString += " union select DISTINCT 234 as ServType ,'Surgical History' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key  , 7 as SortType  " +

           " WHERE   ((select count(*) from Clinical_RiskFactor where  (Clinical_RiskFactor.patient_id = @Patt_ID) " +
           " and Clinical_RiskFactor.Status = 1  and ProcessID IN (205)) + (select count(*) from PatOtherRiskFactor where  (PatOtherRiskFactor.patient_id = @Patt_ID) " +
           " and PatOtherRiskFactor.Status = 1  and ProcessID IN (205)) ) = 0 ";

            SelectString += " union select DISTINCT 234 as ServType , 'Surgical History' as title, 'No Known Surgical History' AS Description ,  Clinical_RiskFactor.AttribID as Code  , Staff.Staff_Key , 7 as SortType  " +
                          " FROM Clinical_RiskFactor  WITH (NOLOCK) LEFT OUTER JOIN " +
                          " dbo.Staff  WITH (NOLOCK) ON dbo.Clinical_RiskFactor.UserKey = dbo.Staff.Staff_Key " +
                          " WHERE   Clinical_RiskFactor.AttribID = -555  and (Clinical_RiskFactor.PATIENT_ID = @Patt_ID) " +
                          " and Clinical_RiskFactor.Status = 1 and ProcessID IN (205) ";

            SelectString += " union select DISTINCT 234 as ServType , 'Surgical History' as title ,  " +
                "replace(replace(replace(replace(replace(replace(replace(SurgicalHistoryView.Term,'Exposure to ',''),'Race: ',''),'Residence/travel: ',''),'Past H. of ',''),'Occupation: ',''),'Activity: ',''),'Family H. of ','')  AS Description ,   SurgicalHistoryView.AttribID as Code  , Staff.Staff_Key , 7 as SortType  " +
                            " FROM dbo.SurgicalHistoryView  WITH (NOLOCK) INNER JOIN " +
                            " dbo.Clinical_RiskFactor  WITH (NOLOCK) ON dbo.SurgicalHistoryView.AttribID = dbo.Clinical_RiskFactor.AttribID LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (NOLOCK) ON dbo.Clinical_RiskFactor.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE    (Clinical_RiskFactor.PATIENT_ID = @Patt_ID) " +
                            " and Clinical_RiskFactor.Status = 1 and Clinical_RiskFactor.ProcessID IN (205)";


            SelectString += " union select DISTINCT 234 as ServType , 'Surgical History' as title , OtherRiskFactorName AS Description ,   -1  as Code  , Staff.Staff_Key , 7 as SortType  " +
                            " FROM  PatOtherRiskFactor  WITH (NOLOCK)  LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (NOLOCK) ON dbo.PatOtherRiskFactor.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE    (PatOtherRiskFactor.PATIENT_ID = @Patt_ID) " +
                            " and PatOtherRiskFactor.Status = 1 and ProcessID IN (205)";



            SelectString += " union select DISTINCT 234 as ServType , 'Surgical History' as title , OperationsView.Description AS Description ,   -1  as Code  " +
                             "  , Staff.Staff_Key , 7 as SortType " +
                            " FROM OperationsView  WITH(NOLOCK)  LEFT OUTER JOIN " +
                             " dbo.Staff WITH(NOLOCK) ON dbo.OperationsView.RequestedBy = dbo.Staff.Staff_Key " +
                             " WHERE(OperationsView.PATIENT_ID = @Patt_ID) and(OperationsView.episode_key = @Eps_key) " +
                             "  ";



            SelectString += " union select  456 as ServType , 'Risk Scores' as title , Risk_Scores.Score_Name +': '+ Risk_Scores_Data.Score_Value AS Description ,   -1  as Code  , Staff.Staff_Key , 5 as SortType   " +
                         " from Risk_Scores_Data  WITH (nolock)  inner join Risk_Scores  WITH (nolock)  on Risk_Scores_Data.Score_Key = Risk_Scores.Sys_key " +
                         "   left outer join staff  WITH (nolock)  on staff.Staff_Key = Risk_Scores_Data.User_Key " +
                          "  where Risk_Scores_Data.Patient_ID = @Patt_ID " +
                          "  and Risk_Scores.Active = 1 and Risk_Scores_Data.Active = 1 " +
                          "  and   Risk_Scores_Data.Sys_Key  = (select top 1 (Risk_Scores_Data.Sys_Key) as keey from Risk_Scores_Data inner join Risk_Scores on Risk_Scores_Data.Score_Key = Risk_Scores.Sys_key " +
                         "   left outer join staff on staff.Staff_Key = Risk_Scores_Data.User_Key " +
                          "  where Risk_Scores_Data.Patient_ID = @Patt_ID " +
                          "  and Risk_Scores.Active = 1 and Risk_Scores_Data.Active = 1  order by Risk_Scores.sort_order ,  Risk_Scores.Score_Name , Risk_Scores_Data.Sys_Key desc) ";



            SelectString += " union select DISTINCT 4 as ServType ,'Considerations' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key  , 8 as SortType  " +

           " WHERE   ((select count(*) from PatConsiderations where  (PatConsiderations.PatCons_PATIENT_ID_FK = @Patt_ID )  and PatConsiderations.PatCons_episode_key_FK = @Eps_key  " +
           " and PatConsiderations.PatCons_Status = 1   ) + (select count(*) from PatConsiderations where  (PatConsiderations.PatCons_PATIENT_ID_FK = @Patt_ID )  and PatConsiderations.LifeTime = 1 " +
           " and PatConsiderations.PatCons_Status = 1   ) + (select count(*) from PatOtherConsiderations where  (PatOtherConsiderations.patient_id = @Patt_ID) and PatOtherConsiderations.Episode_key =  @Eps_key and PatOtherConsiderations.Status = 1 ) ) = 0 ";


            SelectString += " union select DISTINCT 4 as ServType ,'Considerations' as title, 'No Known Considerations' AS Description ,    PatConsiderations.PatCons_Cons_SysKey_FK as Code  , Staff.Staff_Key  , 8 as SortType  " +
                            " FROM patConsiderations WITH (NOLOCK) LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (nolock)  ON dbo.PatConsiderations.PatCons_UserKey = dbo.Staff.Staff_Key " +
                            " WHERE  PatCons_Cons_SysKey_FK = -555 and PatConsiderations.PatCons_ShowInToolTip = 1 and  (PatConsiderations.PatCons_PATIENT_ID_FK= @Patt_ID) and PatConsiderations.PatCons_episode_key_FK =  @Eps_key and PatConsiderations.PatCons_Status = 1 ";


            SelectString += " union select DISTINCT 4 as ServType ,'Considerations' as title, CONSIDERATIONS.Cons_LatinName AS Description ,   PatConsiderations.PatCons_Cons_SysKey_FK as Code  , Staff.Staff_Key , 8 as SortType   " +
                            " FROM dbo.PatConsiderations WITH (NOLOCK)  INNER JOIN " +
                            " dbo.CONSIDERATIONS WITH (NOLOCK) ON " +
                            " dbo.PatConsiderations.PatCons_Cons_SysKey_FK = dbo.CONSIDERATIONS.Cons_SysKey_PK LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (nolock)  ON dbo.PatConsiderations.PatCons_UserKey = dbo.Staff.Staff_Key " +
                            " WHERE  (PatConsiderations.PatCons_PATIENT_ID_FK = @Patt_ID) and PatConsiderations.PatCons_episode_key_FK = @Eps_key and PatConsiderations.PatCons_ShowInToolTip = 1 " +
                            " and  PatConsiderations.PatCons_Status = 1 ";


            SelectString += " union select DISTINCT 4 as ServType ,'Considerations' as title , CONSIDERATIONS.Cons_LatinName AS Description ,   PatConsiderations.PatCons_Cons_SysKey_FK as Code  , Staff.Staff_Key  , 8 as SortType  " +
                            " FROM dbo.PatConsiderations WITH (NOLOCK)  INNER JOIN " +
                            " dbo.CONSIDERATIONS WITH (NOLOCK) ON " +
                            " dbo.PatConsiderations.PatCons_Cons_SysKey_FK = dbo.CONSIDERATIONS.Cons_SysKey_PK LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (nolock)  ON dbo.PatConsiderations.PatCons_UserKey = dbo.Staff.Staff_Key " +
                            " WHERE  (PatConsiderations.PatCons_PATIENT_ID_FK = @Patt_ID) and PatConsiderations.LifeTime = 1 and PatConsiderations.PatCons_ShowInToolTip = 1 " +
                            " and  PatConsiderations.PatCons_Status = 1 ";


            SelectString += " union select DISTINCT 4 as ServType ,'Considerations' as title ,  PatOtherConsiderations.OtherConsiderationName AS Description ,   -1 as Code  , Staff.Staff_Key  , 8 as SortType  " +
                            " FROM dbo.PatOtherConsiderations WITH (NOLOCK) LEFT OUTER JOIN " +
                            " dbo.Staff  WITH (nolock)  ON dbo.PatOtherConsiderations.UserKey = dbo.Staff.Staff_Key " +
                            " WHERE  (PatOtherConsiderations.Patient_ID = @Patt_ID) and PatOtherConsiderations.Episode_key = @Eps_key " +
                            " and  PatOtherConsiderations.Status = 1 ";

            SelectString += " union select DISTINCT 5 as ServType ,'Immunisations' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key  , 88 as SortType   " +

     " WHERE   ((select count(*) FROM Immu_Adminstiration  WITH (nolock)  LEFT OUTER JOIN GenericName ON Immu_Adminstiration.Vaccine_Id = GenericName.GenericName_ID " +
                            " LEFT OUTER JOIN Immunizations_Schedule  WITH (nolock)  ON Immu_Adminstiration.Vaccine_Id = Immunizations_Schedule.GenericName_ID " +
                            " LEFT OUTER JOIN Staff  WITH (nolock)  ON dbo.Immu_Adminstiration.User_Id = Staff.Staff_Key	 " +
                            " WHERE (Immu_Adminstiration.Status =2 or Immu_Adminstiration.Immu_Type= 2) " +
                            " and Immu_Adminstiration.Patient_Id =  @Patt_ID )  ) = 0  and (select top 1 PB_ShowNewImmunization from sysparameters) = 1 ";


            SelectString += " union select DISTINCT 5 as ServType  , 'Immunisations' as title, GenericName.GenericName AS Description ,   GenericName.GenericName_ID as Code  , Staff.Staff_Key  , 88 as SortType  " +
                            " FROM Immu_Adminstiration  WITH (nolock)  LEFT OUTER JOIN GenericName ON Immu_Adminstiration.Vaccine_Id = GenericName.GenericName_ID " +
                            " LEFT OUTER JOIN Immunizations_Schedule  WITH (nolock)  ON Immu_Adminstiration.Vaccine_Id = Immunizations_Schedule.GenericName_ID " +
                            " LEFT OUTER JOIN Staff  WITH (nolock)  ON dbo.Immu_Adminstiration.User_Id = Staff.Staff_Key	 " +
                            " WHERE (Immu_Adminstiration.Status =2 or Immu_Adminstiration.Immu_Type= 2) " +
                            " and Immu_Adminstiration.Patient_Id =  @Patt_ID and (select top 1 PB_ShowNewImmunization from sysparameters) = 1 ";

            SelectString += " union select DISTINCT 5 as ServType  , 'Immunisations' as title, IMMUNIZATION.LATIN_NAME AS Description , " +
                "   PATIMMUNIZATION.SYS_KEY as Code  , Staff.Staff_Key  , 88 as SortType  " +
                         " FROM  DBO.PATIMMUNIZATION WITH (NOLOCK)  INNER JOIN " +
                  " DBO.IMMUNIZATION WITH (NOLOCK) ON DBO.PATIMMUNIZATION.IMMU_SYSKEY = DBO.IMMUNIZATION.SYS_KEY LEFT OUTER JOIN " +
                   " DBO.STAFF ON DBO.PATIMMUNIZATION.IMMU_USERKEY = DBO.STAFF.STAFF_KEY	 " +
                         " WHERE  " +
                         "   PATIMMUNIZATION.Patient_Id =  @Patt_ID and PatImmunization.Immu_Status = 1 and (select top 1 PB_ShowNewImmunization from sysparameters) = 0 ";




            SelectString += " union select DISTINCT 5 as ServType  , 'Immunisations' as title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key  , 88 as SortType   " +
                         " where  ((select count(*)  FROM  DBO.PATIMMUNIZATION WITH (NOLOCK)  INNER JOIN " +
                  " DBO.IMMUNIZATION WITH (NOLOCK) ON DBO.PATIMMUNIZATION.IMMU_SYSKEY = DBO.IMMUNIZATION.SYS_KEY LEFT OUTER JOIN " +
                   " DBO.STAFF ON DBO.PATIMMUNIZATION.IMMU_USERKEY = DBO.STAFF.STAFF_KEY	 " +
                         " WHERE  " +
                         "   PATIMMUNIZATION.Patient_Id =  @Patt_ID  and PatImmunization.Immu_Status = 1 )  ) = 0    and (select top 1 PB_ShowNewImmunization from sysparameters) = 0 ";


            SelectString += " union select DISTINCT 5654435 as ServType ,'Medication History' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key  , 9 as SortType  " +

     " WHERE   (( SELECT  count(*) from( " +
                          " SELECT SUBSTRING(ITEM_KEY, PATINDEX('%[0-9]%', ITEM_KEY), LEN(ITEM_KEY)) ITEM_KEY,LATIN_DESC  " +
                          " from IntelliPatHistory_view(@P_HospitalID)  " +
                          " where episodekey  in (-222,@Eps_key )   and patientid=@Patt_ID  and SHEETDEFKEY in (-222) and SHEETKEY in (-222)  " +
                          " and  userkey in (-222, " + User_key + " ) and type = 3 )x)  + (select  count(*) " +
                "from PatMedicationsHistory where PatMedicationsHistory.PATIENT_ID = @Patt_ID and PatMedicationsHistory.episode_key = @Eps_key " +
" and PatMedicationsHistory.Status = 1 and PatMedicationsHistory.Drug_Code = -555)) = 0 ";


            SelectString += " union  SELECT distinct 5654435 as ServType , 'Medication History' as title, LATIN_DESC AS Description ,LEFT(ITEM_KEY,PATINDEX('%[^0-9]%', ITEM_KEY+'a')-1) as Code , 0 as STAFF_KEY  , 9 as SortType  from( " +
                          " SELECT SUBSTRING(ITEM_KEY, PATINDEX('%[0-9]%', ITEM_KEY), LEN(ITEM_KEY)) ITEM_KEY,LATIN_DESC  " +
                          " from IntelliPatHistory_view(@P_HospitalID)  " +
                          " where episodekey  in (-222,@Eps_key )   and patientid=@Patt_ID  and SHEETDEFKEY in (-222) and SHEETKEY in (-222)  " +
                          " and  userkey in (-222, " + User_key + " ) and type = 3 )x  " +
                           " ";

            SelectString += " union  select distinct 5654435 as ServType , 'Medication History'   as title, 'Not Taking Medications at Home' AS Description ,  0 as Code  , 0 as Staff_Key  , 9 as SortType  " +
                "from PatMedicationsHistory where PatMedicationsHistory.PATIENT_ID = @Patt_ID and PatMedicationsHistory.episode_key = @Eps_key " +
" and PatMedicationsHistory.Status = 1 and PatMedicationsHistory.Drug_Code = -555";



            SelectString += " union select DISTINCT 5666 as ServType ,'Measurements' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key  , 99 as SortType  " +

" WHERE   ((select count(*)FROM         PATMEASUREMENTS WITH (NOLOCK) LEFT OUTER JOIN STAFF WITH (NOLOCK) ON PATMEASUREMENTS.ADDEDBY = STAFF.STAFF_KEY  " +
" where Patient_ID = @Patt_ID and PATMEASUREMENTS.status   != -1 and (PATMEASUREMENTS.status = 0 or PATMEASUREMENTS.status is null ) and PATMEASUREMENTS.Sys_key = (select top 1 sys_key from   PATMEASUREMENTS WITH (NOLOCK) LEFT OUTER JOIN STAFF WITH (NOLOCK) ON PATMEASUREMENTS.ADDEDBY = STAFF.STAFF_KEY  " +
" where Patient_ID = @Patt_ID and PATMEASUREMENTS.status   != -1 and (PATMEASUREMENTS.status = 0 or PATMEASUREMENTS.status is null )  order by Sys_key desc))  ) = 0 ";



            SelectString += " union select DISTINCT 5666 as ServType  ,  'Measurements' AS title, " +
 " 'Weight = ' + CAST(WEIGHT AS VARCHAR(10))+ ', Height = ' +CAST(HEIGHT AS VARCHAR(10)) + ', BMI = ' +CAST(ROUND(PATMEASUREMENTS.BMI, 2) AS VARCHAR(10))+ ', BSA = ' " +
 " +CAST(ROUND(PATMEASUREMENTS.BSA, 2) AS VARCHAR(10)) + ' ON ' + " +
"	REPLACE(CONVERT(VARCHAR(11),AddedDate,113),' ','-')  + ' ' + CONVERT(VARCHAR(11),AddedDate,108) as Description ,   -1 as Code  , Staff.Staff_Key   , 99 as SortType  " +
" FROM         PATMEASUREMENTS WITH (NOLOCK) LEFT OUTER JOIN STAFF WITH (NOLOCK) ON PATMEASUREMENTS.ADDEDBY = STAFF.STAFF_KEY  " +
" where Patient_ID = @Patt_ID and PATMEASUREMENTS.status   != -1 and (PATMEASUREMENTS.status = 0 or PATMEASUREMENTS.status is null )  and PATMEASUREMENTS.Sys_key = (select top 1 sys_key from   PATMEASUREMENTS WITH (NOLOCK) LEFT OUTER JOIN STAFF WITH (NOLOCK) ON PATMEASUREMENTS.ADDEDBY = STAFF.STAFF_KEY  " +
" where Patient_ID = @Patt_ID and PATMEASUREMENTS.status   != -1 and (PATMEASUREMENTS.status = 0 or PATMEASUREMENTS.status is null )  order by Sys_key desc)";



            SelectString += " union select DISTINCT 6 as ServType , 'Acuity Level' as title , ACUITYLEVEL.Description AS Description ,   EPISODE.AcuityLevel as Code  , 0 as Staff_Key  , 100 as SortType   " +
                           " from ACUITYLEVEL WITH (NOLOCK) , EPISODE where  EPISODE.AcuityLevel = ACUITYLEVEL.AcuityLevel " +
                            " and PATIENT_ID =   @Patt_ID ";


            SelectString += " union select DISTINCT 6 as ServType , 'Acuity Level' as title , 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key  , 100 as SortType   " +
                         " from  EPISODE where  (EPISODE.AcuityLevel = 0 or EPISODE.AcuityLevel is null) " +
                          " and PATIENT_ID =   @Patt_ID and Episod_key= @Eps_key";


            //SelectString += " union select DISTINCT 5555553 as ServType , 'Social History' as title , Clinical_Attributes.Term  AS Description ,   Clinical_Attributes.AttribID as Code  , Staff.Staff_Key  " +
            //               " FROM dbo.Clinical_Attributes  WITH (NOLOCK) INNER JOIN " +
            //               " dbo.Clinical_RiskFactor  WITH (NOLOCK) ON dbo.Clinical_Attributes.AttribID = dbo.Clinical_RiskFactor.AttribID LEFT OUTER JOIN " +
            //               " dbo.Staff  WITH (NOLOCK) ON dbo.Clinical_RiskFactor.UserKey = dbo.Staff.Staff_Key " +
            //               " WHERE    (Clinical_RiskFactor.PATIENT_ID = @Patt_ID) " +
            //               " and Clinical_RiskFactor.Status = 1 and Clinical_RiskFactor.ProcessID IN (450)";

            SelectString += " union select DISTINCT 5555553 as ServType , 'Social History' as title , OtherRiskFactorName AS Description ,   -1  as Code  , Staff.Staff_Key  , 101 as SortType  " +
                                        " FROM  PatOtherRiskFactor  WITH (NOLOCK)  LEFT OUTER JOIN " +
                                        " dbo.Staff  WITH (NOLOCK) ON dbo.PatOtherRiskFactor.UserKey = dbo.Staff.Staff_Key " +
                                        " WHERE    (PatOtherRiskFactor.PATIENT_ID = @Patt_ID) " +
                                        " and PatOtherRiskFactor.Status = 1 and ProcessID IN (450)";


            // SelectString += " union SELECT 124 as ServType , 'Comorbidities' as title ,  case when ODISEASEKEY = -555 then 'NO KNOWN Comorbidities' when ODISEASEKEY = -666 " +
            //    " then 'UNABLE TO ASSESS' else ISNULL(PATODISEASE.CUSTOMDESC,OTHERDISEASE.LATIN_DESC) end as Description " +
            //    " ,   0 as Code , 0 as Staff_Key  , 3 as SortType  " +
            //" FROM PATODISEASE WITH (NOLOCK) Left outer JOIN DBO.OTHERDISEASE WITH (NOLOCK) ON DBO.PATODISEASE.ODISEASEKEY = DBO.OTHERDISEASE.SYS_KEY " +
            //" LEFT OUTER JOIN DBO.STAFF WITH (NOLOCK) ON DBO.PATODISEASE.ODISEASE_USERKEY = DBO.STAFF.STAFF_KEY " +
            //" LEFT OUTER JOIN STAFF STAFF_CANCEL WITH (NOLOCK) ON PATODISEASE.CANCELEDBY = STAFF_CANCEL.STAFF_KEY " +
            //" WHERE     (PATODISEASE.PATIENT_ID = @Patt_ID  and PATODISEASE.ODisease_Status = 1  ) " +
            //" union  SELECT 124 as ServType , 'Comorbidities' as title ,  'Not Assessed' as Description " +
            //    " ,   0 as Code , 0 as Staff_Key  , 3 as SortType  " +
            //"    " +
            //" WHERE   ((select count(*) from PATODISEASE where  (PATODISEASE.patient_id = @Patt_ID) " +
            //   " and PATODISEASE.ODisease_Status = 1) + (select count(*) from PATOtherODISEASE where  (PATOtherODISEASE.patient_id = @Patt_ID) " +
            //   " and PATOtherODISEASE.Status = 1) ) = 0 " +
            //" UNION select 124 as ServType , 'Comorbidities' as title ,   PATOTHERODISEASE.OTHERCHRONICNAME as Description" +
            //    " ,   0 as Code , 0 as Staff_Key  , 3 as SortType  " +
            //" FROM        PATOTHERODISEASE WITH (NOLOCK)  left outer JOIN DBO.STAFF WITH (NOLOCK) ON DBO.PATOTHERODISEASE.USERKEY = STAFF.STAFF_KEY " +
            //" LEFT OUTER JOIN STAFF STAFF_CANCEL WITH (NOLOCK) ON PATOTHERODISEASE.CANCELEDBY = STAFF_CANCEL.STAFF_KEY  " +
            //" WHERE     (PATOTHERODISEASE.PATIENT_ID = @Patt_ID and Status = 1 ) ";
            SelectString += " order by SortType ";
            return dbcon.GetData(SelectString);
        }

        public System.Data.DataTable GetDietInfo(string Patt_ID, string Eps_key)
        {
            var SelectString = "   select     7777 as ServType , 'Diet' as title , Latin_Desc AS Description ,   0 as Code , 0 as Staff_Key , primary_diet " +
                          " from Nut_Diet_Types  WITH (nolock) , Nut_Pat_Diet  WITH (nolock)  where  Nut_Diet_Types.Diet_ID = Nut_Pat_Diet.Diet_ID " +
                           " and Nut_Pat_Diet.Episode_Key =   '" + Eps_key + "'  /*and primary_diet=1*/ ";


            SelectString += " union select DISTINCT 7777 as ServType ,'Diet' as  title, 'Not Assessed' AS Description ,  0 as Code  , 0 as Staff_Key  , 1 as primary_diet " +

        " WHERE   ((select count(*) from Nut_Diet_Types  WITH (nolock) , Nut_Pat_Diet  WITH (nolock)  where  Nut_Diet_Types.Diet_ID = Nut_Pat_Diet.Diet_ID " +
                           " and Nut_Pat_Diet.Episode_Key =   '" + Eps_key + "'  /*and primary_diet=1 */) ) = 0  order by primary_diet desc ";
            return dbcon.GetData(SelectString);
        }

        public DataTable GetActiveProblems(string Pat_Id, string Eps_key, string P_HospitalID, string Type)
        {
            // Eps_key = "0";
            //dbcon = new MedicaDAL.DBInteraction(true);
            //if (Eps_key == "0")
            //{

            var SelectString = " exec PATIENTACTIVEPROBLEMS_SP  " + Pat_Id + "," + P_HospitalID + "," + Eps_key + "," + Type;
            return dbcon.GetData(SelectString);
            //                SelectString = " select  PatientActiveProblemsForFaceSheet.SYS_KEY , PatientActiveProblemsForFaceSheet.Latin_Description , PatientActiveProblemsForFaceSheet.Status_LatinName , " +
            //                           " PatientActiveProblemsForFaceSheet.Problem_Date , cast(DocPNote.Note_Text as varchar(4000)) as Note_Text , DocPNote.note_id " +
            //                           " , ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach  , DocPNote.Note_Date,  DocPNote.Note_Time , staff.Staff_name , " +
            //                           "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey ,PatientActiveProblemsForFaceSheet.staffKey , 'D' as viewtype, pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary , PatientActiveProblemsForFaceSheet.EPISODE_KEY , PatientActiveProblemsForFaceSheet.DIAGNOSIS_ST " +
            //                           " from DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet left outer join PATDIAGNOSIS on PATDIAGNOSIS.Sys_Key = PatientActiveProblemsForFaceSheet.SYS_KEY  left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.sys_key = AssociateToNote.Assocaite_Key  " +
            //                           " and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 1  " +
            //                           " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            //                           " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' and PatientActiveProblemsForFaceSheet.headerNumber <> 2 " +
            //                           "    and PatientActiveProblemsForFaceSheet.ProblemKey <> 0  " +
            //                           " union select  PatientActiveProblemsForFaceSheet.SYS_KEY , PatientActiveProblemsForFaceSheet.Latin_Description , PatientActiveProblemsForFaceSheet.Status_LatinName , " +
            //                          "   PatientActiveProblemsForFaceSheet.Problem_Date , cast(DocPNote.Note_Text as varchar(4000)) as Note_Text , DocPNote.note_id , ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach   , DocPNote.Note_Date,  DocPNote.Note_Time , staff.Staff_name  ,  " +
            //                           "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey , PatientActiveProblemsForFaceSheet.staffKey , 'F' as viewtype  , pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end  , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary, PatientActiveProblemsForFaceSheet.EPISODE_KEY ,PatientActiveProblemsForFaceSheet.DIAGNOSIS_ST " +
            //                           " from DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet  left outer join PATDIAGNOSIS on PATDIAGNOSIS.Sys_Key = PatientActiveProblemsForFaceSheet.SYS_KEY  left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.sys_key = AssociateToNote.Assocaite_Key and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 7  " +
            //                           " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            //                           " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' and PatientActiveProblemsForFaceSheet.headerNumber <> 2    and PatientActiveProblemsForFaceSheet.ProblemKey = 0  " +
            //                          "  union select  PatientActiveProblemsForFaceSheet.SYS_KEY ,  case when (PatientActiveProblemsForFaceSheet.CustomDesc) is null  or PatientActiveProblemsForFaceSheet.CustomDesc = '' then " +
            // " PatientActiveProblemsForFaceSheet.Latin_Description else " +
            //" PatientActiveProblemsForFaceSheet.CustomDesc " +
            // " end as Latin_Description  , PatientActiveProblemsForFaceSheet.Status_LatinName ,  " +
            //                          "  PatientActiveProblemsForFaceSheet.Problem_Date , cast(DocPNote.Note_Text as varchar(4000)) as Note_Text , DocPNote.note_id, ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach  , DocPNote.Note_Date, DocPNote.Note_Time , staff.Staff_name  ,  " +
            //                          "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey ,PatientActiveProblemsForFaceSheet.staffKey , 'C' as viewtype , pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end  , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary , PatientActiveProblemsForFaceSheet.EPISODE_KEY , PatientActiveProblemsForFaceSheet.DIAGNOSIS_ST " +
            //                          "  from  DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet left outer join PATDIAGNOSIS on PATDIAGNOSIS.Sys_Key = PatientActiveProblemsForFaceSheet.SYS_KEY  left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.sys_key = AssociateToNote.Assocaite_Key and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 2  " +
            //                           " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            //                           " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' and PatientActiveProblemsForFaceSheet.DIAGNOSIS_KEY <> -555  and PatientActiveProblemsForFaceSheet.headerNumber <> 1  " +

            //                              "  union select  PatientActiveProblemsForFaceSheet.SYS_KEY , PatientActiveProblemsForFaceSheet.Latin_Description , PatientActiveProblemsForFaceSheet.Status_LatinName ,  " +
            //                        "  PatientActiveProblemsForFaceSheet.Problem_Date , cast(DocPNote.Note_Text as varchar(4000)) as Note_Text , DocPNote.note_id  , ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach  , DocPNote.Note_Date, DocPNote.Note_Time , staff.Staff_name  ,  " +
            //                        "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey ,PatientActiveProblemsForFaceSheet.staffKey , 'C2' as viewtype , pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end  , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary , PatientActiveProblemsForFaceSheet.EPISODE_KEY , PatientActiveProblemsForFaceSheet.DIAGNOSIS_ST " +
            //                        "  from  DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet left outer join PATDIAGNOSIS on PATDIAGNOSIS.Sys_Key = PatientActiveProblemsForFaceSheet.SYS_KEY  left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.SYS_KEY = AssociateToNote.Assocaite_Key and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 99  " +
            //                         " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            //                         " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' " +
            //                         " and PatientActiveProblemsForFaceSheet.DIAGNOSIS_KEY = -555 and PatientActiveProblemsForFaceSheet.headerNumber <> 1  " +



            //                           " order by isPrimary desc , PatientActiveProblemsForFaceSheet.problem_date desc , " +
            //                             " DocPNote.Note_Date desc , DocPNote.Note_Time desc  ";
            //            }
            //            else
            //            {
            ////                SelectString = " select  PatientActiveProblemsForFaceSheet.SYS_KEY , PatientActiveProblemsForFaceSheet.Latin_Description , PatientActiveProblemsForFaceSheet.Status_LatinName , " +
            ////                         " PatientActiveProblemsForFaceSheet.Problem_Date " +
            ////                         " , ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach  ,cast(DocPNote.Note_Text as nvarchar(4000)) as Note_Text " +
            ////                         " , DocPNote.Note_Date,  DocPNote.Note_Time , staff.Staff_name , PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey ,staffKey , 'D' as viewtype , pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end " +
            ////                         "  , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary " +
            ////                         " from  DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.sys_key = AssociateToNote.Assocaite_Key  " +
            ////                         " and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 1  " +
            ////                         " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            ////                         " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' and PatientActiveProblemsForFaceSheet.headerNumber <> 2 and PatientActiveProblemsForFaceSheet.episode_key =  " + Eps_key + " " +
            ////                         "    and PatientActiveProblemsForFaceSheet.ProblemKey <> 0  " +
            ////                         " union select  PatientActiveProblemsForFaceSheet.SYS_KEY , PatientActiveProblemsForFaceSheet.Latin_Description , PatientActiveProblemsForFaceSheet.Status_LatinName , " +
            ////                        "   PatientActiveProblemsForFaceSheet.Problem_Date " +
            ////                        " , ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach  , cast(DocPNote.Note_Text as nvarchar(4000)) as Note_Text , DocPNote.Note_Date,  DocPNote.Note_Time , staff.Staff_name  ,  " +
            ////                         "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey ,staffKey , 'F' as viewtype   , pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end  , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary " +
            ////                         " from  DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.SYS_KEY = AssociateToNote.Assocaite_Key and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 7  " +
            ////                         " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            ////                         " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' and PatientActiveProblemsForFaceSheet.headerNumber <> 2 and PatientActiveProblemsForFaceSheet.episode_key =  " + Eps_key + "  and PatientActiveProblemsForFaceSheet.ProblemKey = 0  " +
            ////                        "  union select  PatientActiveProblemsForFaceSheet.SYS_KEY ,  case when (PatientActiveProblemsForFaceSheet.CustomDesc) is null  or PatientActiveProblemsForFaceSheet.CustomDesc = '' then " +
            //// " PatientActiveProblemsForFaceSheet.Latin_Description else " +
            ////" PatientActiveProblemsForFaceSheet.CustomDesc " +
            //// " end as Latin_Description  , PatientActiveProblemsForFaceSheet.Status_LatinName ,  " +
            ////                        "  PatientActiveProblemsForFaceSheet.Problem_Date  " +
            ////                        " , ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach  ,  cast(DocPNote.Note_Text as nvarchar(4000)) as Note_Text , DocPNote.Note_Date, DocPNote.Note_Time , staff.Staff_name  ,  " +
            ////                        "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey ,staffKey , 'C' as viewtype , pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary  " +
            ////                        "  from  DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.sys_key = AssociateToNote.Assocaite_Key and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 2  " +
            ////                         " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            ////                         " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' and PatientActiveProblemsForFaceSheet.DIAGNOSIS_KEY <> -555 and PatientActiveProblemsForFaceSheet.headerNumber <> 1  " +

            ////                         "  union select  PatientActiveProblemsForFaceSheet.SYS_KEY , PatientActiveProblemsForFaceSheet.Latin_Description , PatientActiveProblemsForFaceSheet.Status_LatinName ,  " +
            ////                        "  PatientActiveProblemsForFaceSheet.Problem_Date " +
            ////                        " , ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach  , cast(DocPNote.Note_Text as nvarchar(4000)) as Note_Text , DocPNote.Note_Date, DocPNote.Note_Time , staff.Staff_name  ,  " +
            ////                        "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey ,staffKey , 'C2' as viewtype , pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary  " +
            ////                        "  from  DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.SYS_KEY = AssociateToNote.Assocaite_Key and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 99  " +
            ////                         " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            ////                         " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' and PatientActiveProblemsForFaceSheet.DIAGNOSIS_KEY = -555 and PatientActiveProblemsForFaceSheet.headerNumber <> 1  " +

            ////                         " order by PatientActiveProblemsForFaceSheet.problem_date desc , " +
            ////                           " DocPNote.Note_Date desc , DocPNote.Note_Time desc  ";


            //                SelectString = " select  PatientActiveProblemsForFaceSheet.SYS_KEY , PatientActiveProblemsForFaceSheet.Latin_Description , PatientActiveProblemsForFaceSheet.Status_LatinName , " +
            //                          " PatientActiveProblemsForFaceSheet.Problem_Date , cast(DocPNote.Note_Text as varchar(4000)) as Note_Text , DocPNote.note_id " +
            //                          " , ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach  , DocPNote.Note_Date,  DocPNote.Note_Time , staff.Staff_name , " +
            //                          "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey ,PatientActiveProblemsForFaceSheet.staffKey , 'D' as viewtype, pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary , PatientActiveProblemsForFaceSheet.EPISODE_KEY , PatientActiveProblemsForFaceSheet.DIAGNOSIS_ST " +
            //                          " from DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet left outer join PATDIAGNOSIS on PATDIAGNOSIS.Sys_Key = PatientActiveProblemsForFaceSheet.SYS_KEY  left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.sys_key = AssociateToNote.Assocaite_Key  " +
            //                          " and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 1  " +
            //                          " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            //                          " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' and PatientActiveProblemsForFaceSheet.headerNumber <> 2 and PatientActiveProblemsForFaceSheet.episode_key =  " + Eps_key + " " +
            //                          "    and PatientActiveProblemsForFaceSheet.ProblemKey <> 0  " +
            //                          " union select  PatientActiveProblemsForFaceSheet.SYS_KEY , PatientActiveProblemsForFaceSheet.Latin_Description , PatientActiveProblemsForFaceSheet.Status_LatinName , " +
            //                         "   PatientActiveProblemsForFaceSheet.Problem_Date , cast(DocPNote.Note_Text as varchar(4000)) as Note_Text , DocPNote.note_id , ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach   , DocPNote.Note_Date,  DocPNote.Note_Time , staff.Staff_name  ,  " +
            //                          "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey , PatientActiveProblemsForFaceSheet.staffKey , 'F' as viewtype  , pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end  , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary, PatientActiveProblemsForFaceSheet.EPISODE_KEY ,PatientActiveProblemsForFaceSheet.DIAGNOSIS_ST " +
            //                          " from DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet  left outer join PATDIAGNOSIS on PATDIAGNOSIS.Sys_Key = PatientActiveProblemsForFaceSheet.SYS_KEY  left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.sys_key = AssociateToNote.Assocaite_Key and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 7  " +
            //                          " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            //                          " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' and PatientActiveProblemsForFaceSheet.headerNumber <> 2   and PatientActiveProblemsForFaceSheet.episode_key =  " + Eps_key + " and PatientActiveProblemsForFaceSheet.ProblemKey = 0  " +
            //                         "  union select  PatientActiveProblemsForFaceSheet.SYS_KEY ,  case when (PatientActiveProblemsForFaceSheet.CustomDesc) is null  or PatientActiveProblemsForFaceSheet.CustomDesc = '' then " +
            //" PatientActiveProblemsForFaceSheet.Latin_Description else " +
            //" PatientActiveProblemsForFaceSheet.CustomDesc " +
            //" end as Latin_Description  , PatientActiveProblemsForFaceSheet.Status_LatinName ,  " +
            //                         "  PatientActiveProblemsForFaceSheet.Problem_Date , cast(DocPNote.Note_Text as varchar(4000)) as Note_Text , DocPNote.note_id, ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach  , DocPNote.Note_Date, DocPNote.Note_Time , staff.Staff_name  ,  " +
            //                         "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey ,PatientActiveProblemsForFaceSheet.staffKey , 'C' as viewtype , pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end  , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary , PatientActiveProblemsForFaceSheet.EPISODE_KEY , PatientActiveProblemsForFaceSheet.DIAGNOSIS_ST " +
            //                         "  from  DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet left outer join PATDIAGNOSIS on PATDIAGNOSIS.Sys_Key = PatientActiveProblemsForFaceSheet.SYS_KEY  left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.sys_key = AssociateToNote.Assocaite_Key and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 2  " +
            //                          " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            //                          " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' and PatientActiveProblemsForFaceSheet.DIAGNOSIS_KEY <> -555  and PatientActiveProblemsForFaceSheet.headerNumber <> 1  " +

            //                             "  union select  PatientActiveProblemsForFaceSheet.SYS_KEY , PatientActiveProblemsForFaceSheet.Latin_Description , PatientActiveProblemsForFaceSheet.Status_LatinName ,  " +
            //                       "  PatientActiveProblemsForFaceSheet.Problem_Date , cast(DocPNote.Note_Text as varchar(4000)) as Note_Text , DocPNote.note_id  , ((select count(*) from AttachNote where    AttachNote.noteid = DocPNote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach  , DocPNote.Note_Date, DocPNote.Note_Time , staff.Staff_name  ,  " +
            //                       "  PatientActiveProblemsForFaceSheet.diagnosis_Condition , PatientActiveProblemsForFaceSheet.ProblemKey ,PatientActiveProblemsForFaceSheet.staffKey , 'C2' as viewtype , pat_type = case when pat_episode_typ = 1 then '(Inpatient)' when pat_episode_typ = 2 then '(Outpatient)' end  , PATDIAGNOSIS.diagnosis_type,PATDIAGNOSIS.isPrimary , PatientActiveProblemsForFaceSheet.EPISODE_KEY , PatientActiveProblemsForFaceSheet.DIAGNOSIS_ST " +
            //                       "  from  DBO.PATIENTACTIVEPROBLEMSFORACESHEETWeb(" + P_HospitalID + ") as PatientActiveProblemsForFaceSheet left outer join PATDIAGNOSIS on PATDIAGNOSIS.Sys_Key = PatientActiveProblemsForFaceSheet.SYS_KEY  left outer join AssociateToNote on PatientActiveProblemsForFaceSheet.SYS_KEY = AssociateToNote.Assocaite_Key and AssociateToNote.Pat_Id =  '" + Pat_Id + "'  and AssociateToNote.Ntype = 99  " +
            //                        " left outer join DocPNote on AssociateToNote.Note_Id = DocPNote.Note_id  left outer join staff on DocPNote.Note_Signature = staff.Staff_Key  " +
            //                        " where PatientActiveProblemsForFaceSheet.PATIENT_ID = '" + Pat_Id + "' " +
            //                        " and PatientActiveProblemsForFaceSheet.DIAGNOSIS_KEY = -555 and PatientActiveProblemsForFaceSheet.headerNumber <> 1  " +



            //                          " order by PatientActiveProblemsForFaceSheet.problem_date desc , " +
            //                            " DocPNote.Note_Date desc , DocPNote.Note_Time desc  ";
            //            }
        }

        public DataTable GetEpisodeForInPatient(string Eps_key)
        {
            DataTable dt = null;
            var SelectString = "select episod_key,start_date,isnull((SELECT top 1 Actual_Dis_Date FROM dbo.PATDISCHARGE WHERE episode_key=episode.episod_key),end_date) as  end_date,episode_type,pat_episode_typ,PATIENT_ID,episode_type,systime " +
                " from EPISODE  WITH (nolock)  where EPISOD_Key ='" + Eps_key + "'   order by  episod_key desc";
            dt = dbcon.GetData(SelectString);
            return dt;
        }

        public void FillDatatableByEps(string Eps_key)
        {
            //DataTable dt = null;

            var SelectString = " SELECT  DISTINCT  -2 as ServType ,  'Financial type' as title , latin_desc AS Description , 0 " +
                                    ", episod_key FROM episode  WITH (nolock)  ,general_cod  WITH (nolock)  where sub_cod = pattype and   main_cod = 450 and episod_key = " + Eps_key;
            DataTable tbl_Financial_type = dbcon.GetData(SelectString);


            //SelectString = "SELECT  Latin_desc,regtime,Staff_name,(SELECT SPECIALTY.latin_name FROM SPECIALTY WHERE SPECIALTY.Specialty_Key = Staff_Spec  ) "
            //      + " AS Staff_Spec , fromtime,totime , OUTPATREGS.sys_key  FROM         OUTPATREGS  WITH (nolock)  INNER JOIN   Staff  WITH (nolock)  ON OUTPATREGS.staff_key = Staff.Staff_Key INNER JOIN " +
            //  " SPECIALTY  WITH (nolock)  ON Staff.Staff_Spec = SPECIALTY.Specialty_Key INNER JOIN " +
            //  " HOSPSTRUCT  WITH (nolock)  ON OUTPATREGS.clinic_key = HOSPSTRUCT.SYS_KEY " +
            //  " where    OUTPATREGS.episode_key = '" + Eps_key + "' " +
            //  " Order by regtime desc  ";
            //tbl_InPatSpec_InPatInfo_out = dbcon.GetData(SelectString);

            SelectString = "SELECT      SPECIALTY.latin_name AS SPECIALTY_Desc, INPATIENTDOCS.parent_key " +
                                                           " FROM            SPECIALTY  WITH (nolock)  INNER JOIN " +
                 " Staff  WITH (nolock)  INNER JOIN " +
                 " INPATIENTDOCS  WITH (nolock)  ON Staff.Staff_Key = INPATIENTDOCS.treatingdoc ON SPECIALTY.Specialty_Key = Staff.Staff_Spec INNER JOIN " +
                 " EPISODE  WITH (nolock)  ON INPATIENTDOCS.parent_key = EPISODE.episod_key " +
                                       " Where INPATIENTDOCS.status in (0,3)   and (InpatientDocs.Status <> 2) And EPISODE.episod_key = '" + Eps_key + "' " +
                                       " GROUP BY SPECIALTY.latin_name, INPATIENTDOCS.parent_key ";
            DataTable tbl_InPatSpec_InPatInfo_in = dbcon.GetData(SelectString);

            SelectString = "select HOSPSTRUCT_WARD.LATIN_DESC AS WARDLATINNAME , HOSPSTRUCT_BED.LATIN_DESC AS BEDLATINNAME , EPISODE.episod_key " +
                       " from EPISODE  WITH (nolock)  LEFT OUTER JOIN " +
                       " HOSPSTRUCT  HOSPSTRUCT_BED  WITH (nolock)  ON EPISODE.BED_KEY = HOSPSTRUCT_BED.SYS_KEY          " +
                       " LEFT OUTER JOIN HOSPSTRUCT HOSPSTRUCT_ROOM  WITH (nolock)  on HOSPSTRUCT_BED.PARENT_KEY = HOSPSTRUCT_ROOM.SYS_KEY  " +
                       " LEFT OUTER JOIN HOSPSTRUCT HOSPSTRUCT_WARD  WITH (nolock)  ON HOSPSTRUCT_WARD.SYS_KEY = HOSPSTRUCT_ROOM.PARENT_KEY where EPISODE.episod_key = '" + Eps_key + "'";
            DataTable tbl_Location = dbcon.GetData(SelectString);

            SelectString = "select   staff.Staff_name ,staff.Staff_key, 'MRP' as Type , inpatientdocs.status , inpatientdocs.parent_key as Eps_key " +
                                    " from inpatientdocs WITH (nolock)  inner join staff WITH (nolock)  on inpatientdocs.treatingdoc = staff.staff_key INNER JOIN " +
                         " EPISODE WITH (nolock)  ON INPATIENTDOCS.parent_key = EPISODE.episod_key " +
                                    " where EPISODE.episod_key = '" + Eps_key + "'  " +
                                    " and inpatientdocs.status in (0,3) " +
                                    " and (inpatientdocs.InActive = 0 or inpatientdocs.InActive is null) " +
                                    " union " +
                                    " select   staff.Staff_name ,staff.Staff_key, 'MRP' as Type , 0 as status , OUTPATREGS.episode_key  " +
                                    " from OUTPATREGS WITH (nolock)  inner join staff WITH (nolock)  on OUTPATREGS.staff_key  = staff.staff_key  " +
                                    " where OUTPATREGS.episode_key  = '" + Eps_key + "'  " +
                                    " order by status desc";
            DataTable tbl_InPatMRP = dbcon.GetData(SelectString);

            SelectString = "select OUTPATREGS.MAINEPISODEKEY , OUTPATREGS.episode_key from OUTPATREGS WITH (nolock)  inner join episode WITH (nolock)  on OUTPATREGS.MAINEPISODEKEY = episode.episod_key where episode.pat_episode_typ = 1 and OUTPATREGS.episode_key ='" + Eps_key + "'";
            DataTable tbl_v_MAINEPISODEKEY = dbcon.GetData(SelectString);


            //SelectString = "select 'Chif Complrnf' as doc_desc,Staff_name,Note_Date,Note_Time,Note_Text , episod_key " +
            //      " from docpnote WITH (nolock) ,staff WITH (nolock)  where Note_Signature = Staff_Key and modified= 0 and AdminProgNotes = 1 and Episod_key = '" + Eps_key + "'  ";
            //tbl_InPatNote = dbcon.GetData(SelectString);

            SelectString = "select start_date,end_date , EPISODE.episod_key " +
                      " from EPISODE  WITH (nolock)  where EPISODE.episod_key = '" + Eps_key + "'";
            DataTable tbl_InPatInfo_2 = dbcon.GetData(SelectString);

            SelectString = " select Diagnosis.description  , Diagnosis.Local_description  , " +
                   "PATDIAGNOSIS.diagnosis_type  ,  Diagnosis.code , " +
                   "  EPISODE.episod_key ,isPrimary " +
                   " FROM         EPISODE WITH (NOLOCK) INNER JOIN " +
                   " PATDIAGNOSIS WITH (NOLOCK) ON EPISODE.episod_key = PATDIAGNOSIS.episode_key INNER JOIN " +
                   " Diagnosis WITH (NOLOCK) ON PATDIAGNOSIS.diagnosis_key = Diagnosis.Sys_key " +
                   " WHERE      NotActive <>  1 and  EPISODE.episod_key = '" + Eps_key + "' order by isPrimary desc";
            DataTable tbl_Diagnosis = dbcon.GetData(SelectString);

        }


        public DataTable getDiagnosis(string Eps_key)
        {
            var SelectString = " select Diagnosis.description  , Diagnosis.Local_description  , " +
                   "PATDIAGNOSIS.diagnosis_type  ,  Diagnosis.code , " +
                   "  EPISODE.episod_key ,isPrimary " +
                   " FROM         EPISODE WITH (NOLOCK) INNER JOIN " +
                   " PATDIAGNOSIS WITH (NOLOCK) ON EPISODE.episod_key = PATDIAGNOSIS.episode_key INNER JOIN " +
                   " Diagnosis WITH (NOLOCK) ON PATDIAGNOSIS.diagnosis_key = Diagnosis.Sys_key " +
                   " WHERE      NotActive <>  1 and  EPISODE.episod_key = '" + Eps_key + "' order by isPrimary desc";
            DataTable tbl_Diagnosis = dbcon.GetData(SelectString);
            return tbl_Diagnosis;
        }

        public string getInPatMRPKey(string Eps_key)
        {
            var SelectString = "select   staff.Staff_name ,staff.Staff_key, 'MRP' as Type , inpatientdocs.status , inpatientdocs.parent_key as Eps_key " +
                                    " from inpatientdocs WITH (nolock)  inner join staff WITH (nolock)  on inpatientdocs.treatingdoc = staff.staff_key INNER JOIN " +
                         " EPISODE WITH (nolock)  ON INPATIENTDOCS.parent_key = EPISODE.episod_key " +
                                    " where EPISODE.episod_key = '" + Eps_key + "'  " +
                                    " and inpatientdocs.status in (0,3) " +
                                    " and (inpatientdocs.InActive = 0 or inpatientdocs.InActive is null) " +
                                    " union " +
                                    " select   staff.Staff_name ,staff.Staff_key, 'MRP' as Type , 0 as status , OUTPATREGS.episode_key  " +
                                    " from OUTPATREGS WITH (nolock)  inner join staff WITH (nolock)  on OUTPATREGS.staff_key  = staff.staff_key  " +
                                    " where OUTPATREGS.episode_key  = '" + Eps_key + "'  " +
                                    " order by status desc";
            DataTable tbl_InPatMRP = dbcon.GetData(SelectString);
            if (tbl_InPatMRP.Rows.Count > 0)
            {
                return tbl_InPatMRP.Rows[0][1].ToString();
            }
            else
            {
                return "0";
            }
        }

        public string GetInPatLocation(string Eps_key)
        {
            var SelectString = "";
            string InPatSpec = "";
            string InPatInfo = "";
            string InPatMRP = "";
            string InPatNote = "";
            DataTable dt = null;
            string res = "";

            SelectString = "select HOSPSTRUCT_WARD.LATIN_DESC AS WARDLATINNAME , HOSPSTRUCT_BED.LATIN_DESC AS BEDLATINNAME , EPISODE.episod_key " +
                       " from EPISODE  WITH (nolock)  LEFT OUTER JOIN " +
                       " HOSPSTRUCT  HOSPSTRUCT_BED  WITH (nolock)  ON EPISODE.BED_KEY = HOSPSTRUCT_BED.SYS_KEY          " +
                       " LEFT OUTER JOIN HOSPSTRUCT HOSPSTRUCT_ROOM  WITH (nolock)  on HOSPSTRUCT_BED.PARENT_KEY = HOSPSTRUCT_ROOM.SYS_KEY  " +
                       " LEFT OUTER JOIN HOSPSTRUCT HOSPSTRUCT_WARD  WITH (nolock)  ON HOSPSTRUCT_WARD.SYS_KEY = HOSPSTRUCT_ROOM.PARENT_KEY where EPISODE.episod_key = '" + Eps_key + "'";
            DataTable tbl_Location = dbcon.GetData(SelectString);

            //dt = dbcon.GetData(SelectString);
            //DataRow[] drs = tbl_Location.Select(" episod_key = " + Episode_key);
            if (tbl_Location.Rows.Count > 0)
            {
                res = " <strong>Location: </strong> " + tbl_Location.Rows[0][0].ToString() + "(" + tbl_Location.Rows[0][1].ToString() + ")";
            }





            return res;
        }

        public string getFinancial_type(string Pat_ID)
        {
            var SelectString = " SELECT  DISTINCT  -2 as ServType ,  'Financial type' as title , latin_desc AS Description , 0 " +
                                    ", episod_key FROM episode  WITH (nolock)  ,general_cod  WITH (nolock)  where sub_cod = pattype and   main_cod = 450 and patient_id = " + Pat_ID;
            DataTable tbl_Financial_type = dbcon.GetData(SelectString);

            if (tbl_Financial_type.Rows.Count > 0)
            {
                return " <strong>Financial type: </strong> " + tbl_Financial_type.Rows[0]["Description"].ToString();
            }
            else
            {
                return "0";
            }
        }

        public string getInPatSpec(string Pat_ID)
        {
            var SelectString = "SELECT  Latin_desc,regtime,Staff_name,(SELECT SPECIALTY.latin_name FROM SPECIALTY WHERE SPECIALTY.Specialty_Key = Staff_Spec  ) "
                  + " AS Staff_Spec , fromtime,totime , OUTPATREGS.sys_key  FROM         OUTPATREGS  WITH (nolock)  INNER JOIN   Staff  WITH (nolock)  ON OUTPATREGS.staff_key = Staff.Staff_Key INNER JOIN " +
              " SPECIALTY  WITH (nolock)  ON Staff.Staff_Spec = SPECIALTY.Specialty_Key INNER JOIN " +
              " HOSPSTRUCT  WITH (nolock)  ON OUTPATREGS.clinic_key = HOSPSTRUCT.SYS_KEY " +
              " where    OUTPATREGS.patient_id = '" + Pat_ID + "' " +
              " Order by regtime desc  ";
            DataTable tbl_InPatSpec_InPatInfo_out = dbcon.GetData(SelectString);
            if (tbl_InPatSpec_InPatInfo_out.Rows.Count > 0)
            {
                return " <strong>Financial type: </strong> " + tbl_InPatSpec_InPatInfo_out.Rows[0]["Description"].ToString();
            }
            else
            {
                return "0";
            }
        }

        public string getInPatNote()
        {
            return "";
        }

        public DataTable GetEpisodeForOutPatient(string Eps_key)
        {
            DataTable dt = null;
            var SelectString = " select top 1 OUTPATREGS.sys_key as oreg_Key ,OUTPATREGS.episode_key, GENERAL_COD.latin_desc as VisitTypeDesc, * FROM " +
              "  EPISODE WITH(nolock) LEFT OUTER JOIN " +
                      " OUTPATREGS  WITH(nolock)  ON OUTPATREGS.episode_key = EPISODE.episod_key " +
                      "  LEFT OUTER JOIN " +
                      "  Staff WITH(nolock)  ON OUTPATREGS.staff_key = Staff.Staff_Key " +
                      "  LEFT OUTER JOIN " +
                       "  SPECIALTY WITH(nolock)  ON Staff.Staff_Spec = SPECIALTY.Specialty_Key " +
                       "  LEFT OUTER JOIN " +
                       "  HOSPSTRUCT WITH(nolock)  ON OUTPATREGS.clinic_key = HOSPSTRUCT.SYS_KEY " +
                       " LEFT OUTER JOIN " +
                       " GENERAL_COD  WITH(nolock) ON OUTPATREGS.visittype = GENERAL_COD.sub_cod and " +
                       "    GENERAL_COD.MAIN_COD = 2000 " +
                      " where   episod_key = '" + Eps_key + "' order by OUTPATREGS.sys_key desc";
            dt = dbcon.GetData(SelectString);
            return dt;
        }



        //new project

        public DataTable GetIsOrderEpisode(string Eps_Key)
        {
            DataTable data = dbcon.GetData("Select * from episode where Pat_Episode_Typ = 1 and episod_key =   " + Eps_Key);
            return data;
        }



        public string GetEnableOrderSets(string HID)
        {
            var SelectString = "Select EnableOrderSets from sysParameters  WITH (nolock) where HospitalID =  " + HID;
            return dbcon.GetData(SelectString).Rows[0][0].ToString() == "" ? "" : dbcon.GetData(SelectString).Rows[0][0].ToString();
        }


        public DataTable GetUserDefScreen(string User_Id)
        {
            dbcon = new DBInteraction(true);
            var SelectString = "Select ScreenDefName from UserDefWebScreen WITH (nolock)  where (pat_id is null or pat_id = '') and  staff_key = " + User_Id;
            DataTable data = dbcon.GetData(SelectString);
            return data;
        }



        public string Eps_Status(string Eps_Key)
        {
            dbcon = new DBInteraction(true);

            var SelectString = "Select Episode_type from Episode  WITH (nolock)  where  Episod_key = " + Eps_Key;
            DataTable dt = dbcon.GetData(SelectString);
            return dt.Rows.Count == 0 ? "" : dt.Rows[0][0].ToString();
        }

        public string GetGender(string PID)
        {

            dbcon = new DBInteraction(true);
            DataTable dt = dbcon.GetData("select patient_sex from patient where patient_id = '" + PID + "'");
            return dt.Rows.Count == 0 ? "" : dt.Rows[0][0].ToString();

        }


        private string getDateStringFilter(string from, string to) => "((Note_Date <= '" + to + "' AND Note_Date >= '" + from + "' ) )";


        public DataTable GetAssessmentsData(
      string Patient_ID,
      DateTime FromDate,
      DateTime ToDate)
        {
            var SelectString = "select distinct SheetKey,SheetDefKey,TemplateKey,IntelliReports.Status,IntelliReports.ReportKey, 0 as EpisodeKey ,  sheetemplates.Description, Staff.Staff_name,   IntelliReports.DateTimeStamp ,  SheetKey as PATIENT_ID , Staff.Staff_Key   , (select count(*) from AttachNote where  EntryDataType = 2 and  AttachNote.noteid = IntelliReports.ReportKey ) as Attach   FROM            sheetemplates  WITH (nolock)  INNER JOIN           IntelliReports  WITH (nolock)  ON sheetemplates.sys_key = IntelliReports.TemplateKey INNER JOIN          Staff  WITH (nolock)  ON IntelliReports.UserKey = Staff.Staff_Key    where    SheetKey = " + Patient_ID + "    and ReportKey = (select top 1 ierp.ReportKey from  IntelliReports as ierp where ierp.TemplateKey = IntelliReports.TemplateKey   and   SheetKey = " + Patient_ID + " order by DateTimeStamp desc)   and " + this.getDateStringFilter(Utilities.FormatDateClr(FromDate), Utilities.FormatDateClr(ToDate)) + " order by DateTimeStamp desc";
            return this.dbcon.GetData(SelectString);
        }
        public static DataTable GetLastVisit(string PID, string Eps_key)
        {
            DBInteraction dbInteraction = new DBInteraction(true);
            DataTable data2 = new DataTable();
            string str1 = "select start_date,pat_episode_typ  from Episode where patient_id = '" + PID + "' and episod_key = " + Eps_key;
            DataTable data1 = dbInteraction.GetData(str1);
            if (data1.Rows.Count > 0 && data1.Rows[0]["pat_episode_typ"].ToString() == "2")
            {
                string str2 = "select top 2 start_date,pat_episode_typ  from Episode where patient_id = '" + PID + "' and pat_episode_typ = 2 order by  episod_key desc";
                data2 = dbInteraction.GetData(str2);
            }
            return data2;
        }


    }
}
