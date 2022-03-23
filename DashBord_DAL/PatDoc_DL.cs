using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    public class PatDoc_DL
    {
        //  public MedicaDAL.DBInteraction dbcon;
       private IRepository dbcon;
        public PatDoc_DL(IRepository _dbcon)
        {
            dbcon = _dbcon;
             
        }
        
        public DataTable GetDocsForPat(string PID)
        {
            DataTable dt = null;

            var SelectString = "select distinct staff.staff_key , staff.Staff_name from INPATIENTDOCS  WITH (nolock)  inner join episode on INPATIENTDOCS.parent_key = episode.episod_key  " +
                               " inner join staff  WITH (nolock)  on INPATIENTDOCS.treatingdoc = staff.staff_key " +
                               " where episode.PATIENT_ID = '" + PID + "'   " +
                               " union " +
                               " select distinct staff_key,Staff_name from staff WITH (nolock)  where staff_key in(select    userid from pats_alldata WITH (nolock)  where patient_id = '" + PID + "'  )  " +
                               " order by Staff_name asc";
            dt = dbcon.GetData(SelectString);
            return dt;
        }

        public DataTable EMRFavorites(string UserKey)
        {
            if (UserKey.Trim() == "")
            {
                UserKey = "0";
            }
            DataTable dt = null;
            var SelectString = "select Service_Code,Service_Type from EMRFavorites  WITH (nolock)  where   User_Key =  " + UserKey + "";
            dt = dbcon.GetData(SelectString);
            return dt;
        }

        public bool IsEMRFavorites(string Serv_Code, string Serv_type, string UserKey, DataTable dtf)
        {
            try
            {
                DataRow[] drs = dtf.Select("Service_Type = '" + Serv_type + "' and Service_Code = '" + Serv_Code + "'");
                int dt = drs.Length;
                bool res = false;
                if (dt > 0)
                {
                    res = true;
                }
                return res;
            }
            catch
            {
                return false;
            }
        }

        public bool IsEMRSignOff(string Serv_Key, string Serv_type, string UserKey, string PatientID, DataTable dtf)
        {
            try
            {
                DataRow[] drs = dtf.Select(" Service_Key = '" + Serv_Key + "'  " +
                    " and Service_Type = '" + Serv_type + "' and PatientID = '" + PatientID + "' and User_Key =  " + UserKey + "");
                int dt = drs.Length;
                bool res = false;
                if (dt > 0)
                {
                    res = true;
                }
                return res;
            }
            catch
            {
                return false;
            }
        }

        public DataTable EMRSignOff(string Serv_type, string UserKey, string PatientID)
        {
            DataTable dt = null;
            var SelectString = "select * from SignOffServices WITH (nolock),staff  WITH (nolock)   where  User_Key= staff_key and " +
                " Service_Type = '" + Serv_type + "' and PatientID = '" + PatientID + "' and  service_key is not null and  service_key !=  'null' ";
            dt = dbcon.GetData(SelectString);
            return dt;
        }

        public string getUserId()
        {
            return dbcon.UserKey();
        }

        public DataTable GetSheetsProcData(string Patient_ID, DateTime FromDate, DateTime ToDate)
        {

            var SelectString = " SELECT   * " +
                            "FROM            PROCEDURESVIEW WITH (nolock) INNER JOIN " +
                       "   sheets ON PROCEDURESVIEW.SHEET_KEY = sheets.sys_key    LEFT OUTER JOIN " +
                        " Pats_AllData WITH (nolock) ON PROCEDURESVIEW.SYS_KEY = Pats_AllData.OKEY AND Pats_AllData.PATIENT_ID = '" + Patient_ID + "' AND Pats_AllData.TYP IN ('p') " +
                        " where  PROCEDURESVIEW.SHEET_KEY > 0 AND Pats_AllData.PATIENT_ID = '" + Patient_ID + "' AND Pats_AllData.TYP IN ('p') AND SERVICETYPE = 1 and PROCEDURESVIEW.patient_ID = '" + Patient_ID + "' and " +
                             getDateProcStringFilter(Utilities.FormatDateFrom(FromDate), Utilities.FormatDate(ToDate)) + " order by  " +
     "  sheettype,PROCEDURESVIEW.sys_key desc--,( CASE " +
     "  WHEN (PROCEDURESVIEW.status = -1) THEN 2 " +
      "   ELSE PROCEDURESVIEW.status " +
     " END " +
     " ) asc  ";
            return dbcon.GetData(SelectString);

        }

        public DataTable GetSheetsOPTData(string Patient_ID, DateTime FromDate, DateTime ToDate)
        {

            var SelectString = "SELECT        OPTSHEETS.sheet_key as OPT_sheetdefkey,  OPTSheets.sys_key as OPT_sheet_key,  sheets.Description as OPT_sheet_desc   , * " +
" FROM            OperationsView WITH (nolock) INNER JOIN " +
    "                     OPTSHEETS ON OperationsView.sys_key_Parent = OPTSHEETS.orderkey INNER JOIN " +
   "                      sheets ON OPTSHEETS.sheet_key = sheets.sys_key LEFT OUTER JOIN " +
  "                       Pats_AllData WITH (nolock) ON OperationsView.sys_key_Parent = Pats_AllData.OKEY AND Pats_AllData.PATIENT_ID = '" + Patient_ID + "' AND Pats_AllData.TYP IN ('o') " +
" WHERE         (Pats_AllData.PATIENT_ID = '" + Patient_ID + "') AND (Pats_AllData.TYP IN ('o')) and OPTSHEETS.sheet_key > 0  and OperationsView.satus != -1  and " +
                             getDateOPTStringFilter(Utilities.FormatDateFrom(FromDate), Utilities.FormatDate(ToDate)) + " order by OperationsView.sys_key_Parent desc";
            return dbcon.GetData(SelectString);
        }

        public DataTable GetSheetsData(string Patient_ID, DateTime FromDate, DateTime ToDate)
        {
            var SelectString = " SELECT * " +
                        " FROM SHEETSVIEW  WITH (nolock)  left outer join " +
                        " Pats_AllData ON SHEETSVIEW.R_KEY = Pats_AllData.OKEY and  (Pats_AllData.TYP = 'b') " +
                        " WHERE " +
                        " SHEETSVIEW.patient_ID = '" + Patient_ID + "' " +
                        " and " + getDateStringFilter(Utilities.FormatDate(FromDate), Utilities.FormatDate(ToDate))
                        + " order by sheettype, order_date desc,Order_Time desc ";
            return dbcon.GetData(SelectString);
        }

        public DataTable GetTemplatesData(string Patient_ID, DateTime FromDate, DateTime ToDate)
        {
            var SelectString = "SELECT * " +
                        " FROM TemplatesOrders  WITH (nolock)  left outer join " +
                        "                      SheetShortHands ON TemplatesOrders.def_key = SheetShortHands.SysKey   " +
                        " WHERE     " +
                        "    TemplatesOrders.patient_ID = '" + Patient_ID + "'    " +
                        "   and " + getDateStringFilterTemp(Utilities.FormatDate(FromDate), Utilities.FormatDate(ToDate)) + " order by  Order_date desc ";
            return dbcon.GetData(SelectString);
        }

        public DataTable GetSheetsDataEps(string Eps_Key, string PID, string HID)
        {
            string SelectString = "select SYSPARAMETERS.episodesheets from SYSPARAMETERS where HospitalID =  " + HID;

            string dtt = dbcon.ExecScalarQuery(SelectString).ToString();
            if (dtt.Trim() == "")
            {
                dtt = "0";
            }
            SelectString = " SELECT * " +
                        " FROM SHEETSVIEW  WITH (nolock)  left outer join " +
                        " Pats_AllData ON SHEETSVIEW.R_KEY = Pats_AllData.OKEY and  (Pats_AllData.TYP = 'b') " +
                        " WHERE " +
                        " SHEETSVIEW.episode_key = '" + Eps_Key + "' and SHEETSVIEW.patient_ID = '" + PID + "'    and sheet_Key in (" + dtt + ")   " +
                        " order by  sheettype, odate desc,Order_Time desc ";

            return dbcon.GetData(SelectString);
        }

        private string getDateOPTStringFilter(string from, string to)
        {
            return "((orderdate <= '" + to + "' AND orderdate >= '" + from + "' ) or (orderdate > getdate())  )";
        }

        private string getDateStringFilter(string from, string to)
        {
            return "( " +
                "(order_date <= '" + to + "' AND order_date >= '" + from + "' )   " +
                ")";
        }
        private string getDateStringFilterNotedate(string from, string to)
        {
            return "( " +
                "(Note_Date  <= '" + to + "' AND Note_Date  >= '" + from + "' )   " +
                ")";
        }

        private string getDateStringFilterTemp(string from, string to)
        {
            return "( " +
                "(Order_date <= '" + to + "' AND Order_date >= '" + from + "' ) or (Order_date > getdate())  " +
                ")";
        }

        private string getDateProcStringFilter(string from, string to)
        {
            return "( " +
                "(orderdate <= '" + to + "' AND orderdate >= '" + from + "' ) or (odate > getdate())  " +
                ")";
        }

        public string GetUserGroup(string U_Id)
        {
            string res = "";
            var SelectString = "select STAFF_FK from STAFF where staff_key = " + U_Id;
            DataTable dt = dbcon.GetData(SelectString);
            res = dt.Rows[0][0].ToString();
            return res;
        }

        //--- GetAllPNotes DAL
        public DataTable GetPNotes(string Pat_Id, string U_id, DateTime FromDate, DateTime ToDate)
        {
            string Wherecond_note = "";

            var SelectString = " select top 1 GETCLINICALNOTESBYUSERGROUP  from SYSPARAMETERS  WITH (nolock) ";
            DataTable dt = dbcon.GetData(SelectString);
            string GETCLINICALNOTESBYUSERGROUP = dt.Rows[0][0].ToString();
            if (GETCLINICALNOTESBYUSERGROUP == "1")
            {
                string group_key = GetUserGroup(U_id);

                SelectString = "   select   cast(Note_Text as nvarchar(max))  as Note_Text /*+  case when fromsheets = 1 then  char(13) + isnull(DESCRIPTION,'')   else '' end as Note_Text*/,   cast(note_date as date) as note_date, Staff_name  " +
                    " ,month(Note_Date) as months,year(Note_Date) as years,day(Note_Date) as days ,mods ,DOCPNOTE.Patient_id ,0 as  fromsheets,reportkey,0 as sheetkey,note_id,docpnote.EPISOD_KEY,note_time,'' as description,0 as status, Modified ,JOBDESCRIPTION.jd_key,note_signature , sigFlag ,   cast( PLAN_ACTION_NOTE  as nvarchar(4000))   as PLAN_ACTION_NOTE " +
                    "  ,isnull((select top 1 min(PPPP.note_id)  from docpnote as PPPP where PPPP.Note_parent_id =  docpnote.note_id  ),note_id) as P_Note_ID " +
                    " , ((select count(*) from AttachNote where  EntryDataType = 1 and  AttachNote.noteid = docpnote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach "
                    + "from  DBO.DOCPNOTE INNER JOIN " +
                        " DBO.STAFF ON DBO.DOCPNOTE.NOTE_SIGNATURE = DBO.STAFF.STAFF_KEY INNER JOIN  " +
                        " DBO.JOBDESCRIPTION ON DBO.STAFF.STAFF_FK = DBO.JOBDESCRIPTION.JD_KEY INNER JOIN  " +
                        " DBO.SPECIALTY ON DBO.STAFF.STAFF_SPEC = DBO.SPECIALTY.SPECIALTY_KEY LEFT OUTER JOIN " +
                        " DBO.DIGNOSISV ON DBO.DOCPNOTE.DIAGNOSIS_KEY = DBO.DIGNOSISV.SYS_KEY " +
                    "   where  DOCPNOTE.Patient_id  = '" + Pat_Id + "'   and DBO.JOBDESCRIPTION.JD_KEY = " + group_key + " and  MODIFIED = 0   and "
                    + getDateStringFilter(Utilities.FormatDate(FromDate), Utilities.FormatDate(ToDate)) + "  " + Wherecond_note
                    + "   order by isnull((select top 1 min(PPPP.note_id)  from docpnote as PPPP where PPPP.Note_parent_id =  docpnote.note_id ),note_id)  desc "
                    ;
            }
            else
            {
                SelectString = "   select   cast(Note_Text as nvarchar(max))  as Note_Text /*+  case when fromsheets = 1 then  char(13) + isnull(DESCRIPTION,'')   else '' end as Note_Text*/,  cast(note_date as date) as note_date, Staff_name  " +
                    " ,month(Note_Date) as months,year(Note_Date) as years,day(Note_Date) as days ,mods ,DOCPNOTE.Patient_id ,0 as fromsheets,reportkey,0 as sheetkey,note_id,docpnote.EPISOD_KEY ,note_time ,'' as description,0 as status , Modified , JOBDESCRIPTION.jd_key,note_signature ,sigFlag ,   cast( PLAN_ACTION_NOTE  as nvarchar(4000))    as PLAN_ACTION_NOTE  " +
                    " ,isnull((select top 1 min(PPPP.note_id)  from docpnote as PPPP where PPPP.Note_parent_id =  docpnote.note_id   ),note_id)as P_Note_ID " +
                    " , ((select count(*) from AttachNote where  EntryDataType = 1 and  AttachNote.noteid = docpnote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach " +
                    " from  DBO.DOCPNOTE INNER JOIN " +
                        " DBO.STAFF ON DBO.DOCPNOTE.NOTE_SIGNATURE = DBO.STAFF.STAFF_KEY INNER JOIN  " +
                        " DBO.JOBDESCRIPTION ON DBO.STAFF.STAFF_FK = DBO.JOBDESCRIPTION.JD_KEY INNER JOIN  " +
                        " DBO.SPECIALTY ON DBO.STAFF.STAFF_SPEC = DBO.SPECIALTY.SPECIALTY_KEY LEFT OUTER JOIN " +
                        " DBO.DIGNOSISV ON DBO.DOCPNOTE.DIAGNOSIS_KEY = DBO.DIGNOSISV.SYS_KEY  " +
                    " where    DOCPNOTE.Patient_id  = '" + Pat_Id + "' and  MODIFIED = 0  " + Wherecond_note + "  and "
                    + getDateStringFilter(Utilities.FormatDate(FromDate), Utilities.FormatDate(ToDate)) + "  order by isnull((select top 1 min(PPPP.note_id) from docpnote as PPPP where PPPP.Note_parent_id =  docpnote.note_id  ),note_id)  desc "
                    ;

                SelectString = "   select   cast(Note_Text as nvarchar(max))  as Note_Text /*+  case when fromsheets = 1 then  char(13) + isnull(DESCRIPTION,'')   else '' end as Note_Text*/,  cast(note_date as date) as note_date, Staff_name  " +
                   " ,month(Note_Date) as months,year(Note_Date) as years,day(Note_Date) as days ,mods ,DOCPNOTE.Patient_id ,0 as fromsheets,reportkey,0 as sheetkey,note_id,docpnote.EPISOD_KEY ,note_time ,'' as description,0 as status , Modified , JOBDESCRIPTION.jd_key,note_signature ,sigFlag ,   cast( PLAN_ACTION_NOTE  as nvarchar(4000))    as PLAN_ACTION_NOTE  " +
                   " , note_id as P_Note_ID " +
                   " , ((select count(*) from AttachNote where  EntryDataType = 1 and  AttachNote.noteid = docpnote.note_id) + (select count(*) from DocpNoteImages where    DocpNoteImages.Note_ID = docpnote.note_id) ) as Attach " +
                   " from  DBO.DOCPNOTE INNER JOIN " +
                       " DBO.STAFF ON DBO.DOCPNOTE.NOTE_SIGNATURE = DBO.STAFF.STAFF_KEY INNER JOIN  " +
                       " DBO.JOBDESCRIPTION ON DBO.STAFF.STAFF_FK = DBO.JOBDESCRIPTION.JD_KEY INNER JOIN  " +
                       " DBO.SPECIALTY ON DBO.STAFF.STAFF_SPEC = DBO.SPECIALTY.SPECIALTY_KEY LEFT OUTER JOIN " +
                       " DBO.DIGNOSISV ON DBO.DOCPNOTE.DIAGNOSIS_KEY = DBO.DIGNOSISV.SYS_KEY  " +
                   " where    DOCPNOTE.Patient_id  = '" + Pat_Id + "'   and  MODIFIED = 0  " + Wherecond_note + "  and "
                   + getDateStringFilter(Utilities.FormatDateFrom(FromDate), Utilities.FormatDate(ToDate)) + "  order by  note_id  desc "
                   ;
            }
            dt = dbcon.GetData(SelectString);
            return dt;
        }

        //--GetDocNGrp DAL
        public DataTable GetDocNoteGroup(string pat_ID)
        {
            DataTable dt = null;
            var SelectString = "select distinct jd_key,jd_ldesc from docpnote_sheetv where patient_id = '" + pat_ID + "' " +
                            " order by jd_ldesc ";
            dt = dbcon.GetData(SelectString);
            return dt;
        }

        public DataTable SheetisPriavate(string HID)
        {
            string str = "select  SheetisPriavate from GetSystemParameters(" + HID + ")";
            return dbcon.GetData(str);
        }

        // has no implementation
        public void GetWebServerIP()
        {
        }

        public string getNoteCount(string Patient_ID, DateTime FromDate, DateTime ToDate, string U_id)
        {
            string str = " select top 1 GETCLINICALNOTESBYUSERGROUP  from SYSPARAMETERS  WITH (nolock) ";
            DataTable data;
            if (dbcon.GetData(str).Rows[0][0].ToString() == "1")
            {
                string userGroup = this.GetUserGroup(U_id);
                data = dbcon.GetData("select Count(*) as cco from   DBO.DOCPNOTE INNER JOIN  DBO.STAFF ON DBO.DOCPNOTE.NOTE_SIGNATURE = DBO.STAFF.STAFF_KEY INNER JOIN   " +
                    "DBO.JOBDESCRIPTION ON DBO.STAFF.STAFF_FK = DBO.JOBDESCRIPTION.JD_KEY INNER JOIN   DBO.SPECIALTY ON DBO.STAFF.STAFF_SPEC = DBO.SPECIALTY.SPECIALTY_KEY LEFT OUTER JOIN " +
                    " DBO.DIGNOSISV ON DBO.DOCPNOTE.DIAGNOSIS_KEY = DBO.DIGNOSISV.SYS_KEY   where (cast(Note_Text as nvarchar(max))  <> '' or cast(PLAN_ACTION_NOTE as nvarchar(max))  <> '' )" +
                    "  and   DOCPNOTE.Patient_id  = '" + Patient_ID + "' and DBO.JOBDESCRIPTION.JD_KEY = " + userGroup + "  and  MODIFIED = 0 and " + this.getDateStringFilterNotedate(Utilities.FormatDateFrom(FromDate), Utilities.FormatDate(ToDate)) ?? "");
            }
            else
                data = dbcon.GetData("select Count(*) as cco from   DBO.DOCPNOTE INNER JOIN  DBO.STAFF ON DBO.DOCPNOTE.NOTE_SIGNATURE = DBO.STAFF.STAFF_KEY INNER JOIN   DBO.JOBDESCRIPTION ON DBO.STAFF.STAFF_FK = DBO.JOBDESCRIPTION.JD_KEY INNER JOIN   DBO.SPECIALTY ON DBO.STAFF.STAFF_SPEC = DBO.SPECIALTY.SPECIALTY_KEY LEFT OUTER JOIN  DBO.DIGNOSISV ON DBO.DOCPNOTE.DIAGNOSIS_KEY = DBO.DIGNOSISV.SYS_KEY    where (cast(Note_Text as nvarchar(max))  <> '' or cast(PLAN_ACTION_NOTE as nvarchar(max))  <> '' )  and   DOCPNOTE.Patient_id  = '" + Patient_ID + "'  and  MODIFIED = 0 and " + this.getDateStringFilterNotedate(Utilities.FormatDateFrom(FromDate), Utilities.FormatDate(ToDate)) ?? "");
            return data.Rows[0][0].ToString();
        }

        public string getSheetReportsDef(string HId) => HId.Trim() == "" ? "" : dbcon.GetData("select  ClinicalSheetTemplateKeys  from GetSystemParameters (" + HId + ")").Rows[0][0].ToString();

        // public string getSheetReports(string HId) => dbcon.GetData("select  ClinicalSheetTemplateKeys  from GetSystemParameters (" + HId + ")").Rows[0][0].ToString();
      public  string getSheetReports(string HId)
        {
            string reslt = "";
            DataTable dt = dbcon.GetData("select  ClinicalSheetTemplateKeys  from GetSystemParameters (" + dbcon.HospitalId() + ")");
            if (dt.Rows.Count > 0)
            {
                reslt = dt.Rows[0][0].ToString();
            }
            return reslt;
        }
        public DataTable getSheetReportsBySysKey(string sysKey) => dbcon.GetData("select sys_key,Description from sheetemplates where sys_key in (" + sysKey + ")");

        public DataTable GetSheetsDataByOrderKey(string Patient_ID, string OrderKey)
        {
            var SelectString = "SELECT   *  FROM         SHEETSVIEW  WITH (nolock)  left outer join                       GetPatSheetData ON SHEETSVIEW.R_KEY = GetPatSheetData.OKEY and (GetPatSheetData.TYP = 'b')   WHERE         SHEETSVIEW.patient_ID = '" + Patient_ID + "'       and  SHEETSVIEW.R_KEY in(" + OrderKey + ")";
            return dbcon.GetData(SelectString);
        }

        public DataTable GetTemplatesDataByOrderKey(string Patient_ID, string OrderKey)
        {
            var SelectString = "SELECT * ,InvordStatus =   case  when dbo.TemplatesOrders.status = -1 then  ' Cancelled by (' + (Select Staff_name from staff with(nolock) where staff.staff_key = TemplatesOrders.cancelby)   + ') On ' + convert(nvarchar(11), CancelDate, 106) + ' at ' + convert(nvarchar(10), datepart(hh, Canceltime)) + ':' + convert(nvarchar(10), datepart(mi, Canceltime)) + '<br> Cancel reason : ' + Cancelreason +   ' <br> for Order by (' + (Select Staff_name from staff with(nolock) where staff.staff_key = TemplatesOrders.Userid)   + ') On ' + convert(nvarchar(11), order_date, 106) + ' at ' + case when len(datepart(hh, Order_date)) = 1 then '0' +      convert(nvarchar(100), datepart(hh, Order_date)) else      convert(nvarchar(100), datepart(hh, Order_date))  end      + ':' + \tcase when len(datepart(mi, Order_date)) = 1 then '0' +     convert(nvarchar(100), datepart(mi, Order_date)) else     convert(nvarchar(100), datepart(mi, Order_date))  end   when dbo.TemplatesOrders.status = 0 then          'Recorded Not Sign by (' + (Select Staff_name from staff with(nolock) where staff.staff_key = TemplatesOrders.Userid)            + ') On ' + convert(nvarchar(11), order_date, 106) + ' at ' + \tcase when len(datepart(hh, Order_date)) = 1 then '0' +            convert(nvarchar(100), datepart(hh, Order_date)) else           convert(nvarchar(100), datepart(hh, Order_date))  end            + ':' + \t\tcase when len(datepart(mi, Order_date)) = 1 then '0' +          convert(nvarchar(100), datepart(mi, Order_date)) else         convert(nvarchar(100), datepart(mi, Order_date))  end   when dbo.TemplatesOrders.status = 1 then  ' Signed by (' + (Select Staff_name from staff with(nolock) where staff.staff_key = TemplatesOrders.Signedby) +') On ' +  convert(nvarchar(11), SignedDatetime, 106) + ' at ' + \tcase when len(datepart(hh, SignedDatetime)) = 1 then '0' +      convert(nvarchar(100), datepart(hh, SignedDatetime)) else     convert(nvarchar(100), datepart(hh, SignedDatetime))  end       + ':' +  case when len(datepart(mi, SignedDatetime)) = 1 then '0' +   convert(nvarchar(100), datepart(mi, SignedDatetime)) else   convert(nvarchar(100), datepart(mi, SignedDatetime))  end +   ' <br> for Order by (' + (Select Staff_name from staff with(nolock) where staff.staff_key = TemplatesOrders.Userid) +') On ' +  convert(nvarchar(11), order_date, 106) + ' at ' + \tcase when len(datepart(hh, Order_date)) = 1 then '0' +     convert(nvarchar(100), datepart(hh, Order_date)) else   convert(nvarchar(100), datepart(hh, Order_date))  end     + ':' +  case when len(datepart(mi, Order_date)) = 1 then '0' +     convert(nvarchar(100), datepart(mi, Order_date)) else   convert(nvarchar(100), datepart(mi, Order_date))  end        end  FROM TemplatesOrders  WITH (nolock)  inner join                       SheetShortHands ON TemplatesOrders.def_key = CAST(SheetShortHands.SysKey as varchar(20))    WHERE         TemplatesOrders.patient_ID = '" + Patient_ID + "'       and  TemplatesOrders.orderkey in(" + OrderKey + ")";
            SelectString = SelectString + " union SELECT *  ,InvordStatus =   case  when dbo.TemplatesOrders.status = -1 then  ' Cancelled by (' + (Select Staff_name from staff with(nolock) where staff.staff_key = TemplatesOrders.cancelby)   + ') On ' + convert(nvarchar(11), CancelDate, 106) + ' at ' + convert(nvarchar(10), datepart(hh, Canceltime)) + ':' + convert(nvarchar(10), datepart(mi, Canceltime)) + '<br> Cancel reason : ' + Cancelreason +   ' <br> for Order by (' + (Select Staff_name from staff with(nolock) where staff.staff_key = TemplatesOrders.Userid)   + ') On ' + convert(nvarchar(11), order_date, 106) + ' at ' + case when len(datepart(hh, Order_date)) = 1 then '0' +      convert(nvarchar(100), datepart(hh, Order_date)) else      convert(nvarchar(100), datepart(hh, Order_date))  end      + ':' + \tcase when len(datepart(mi, Order_date)) = 1 then '0' +     convert(nvarchar(100), datepart(mi, Order_date)) else     convert(nvarchar(100), datepart(mi, Order_date))  end   when dbo.TemplatesOrders.status = 0 then          'Recorded Not Sign by (' + (Select Staff_name from staff with(nolock) where staff.staff_key = TemplatesOrders.Userid)            + ') On ' + convert(nvarchar(11), order_date, 106) + ' at ' + \tcase when len(datepart(hh, Order_date)) = 1 then '0' +            convert(nvarchar(100), datepart(hh, Order_date)) else           convert(nvarchar(100), datepart(hh, Order_date))  end            + ':' + \t\tcase when len(datepart(mi, Order_date)) = 1 then '0' +          convert(nvarchar(100), datepart(mi, Order_date)) else         convert(nvarchar(100), datepart(mi, Order_date))  end   when dbo.TemplatesOrders.status = 1 then  ' Signed by (' + (Select Staff_name from staff with(nolock) where staff.staff_key = TemplatesOrders.Signedby) +') On ' +  convert(nvarchar(11), SignedDatetime, 106) + ' at ' + \tcase when len(datepart(hh, SignedDatetime)) = 1 then '0' +      convert(nvarchar(100), datepart(hh, SignedDatetime)) else     convert(nvarchar(100), datepart(hh, SignedDatetime))  end       + ':' +  case when len(datepart(mi, SignedDatetime)) = 1 then '0' +   convert(nvarchar(100), datepart(mi, SignedDatetime)) else   convert(nvarchar(100), datepart(mi, SignedDatetime))  end +   ' <br> for Order by (' + (Select Staff_name from staff with(nolock) where staff.staff_key = TemplatesOrders.Userid) +') On ' +  convert(nvarchar(11), order_date, 106) + ' at ' + \tcase when len(datepart(hh, Order_date)) = 1 then '0' +     convert(nvarchar(100), datepart(hh, Order_date)) else   convert(nvarchar(100), datepart(hh, Order_date))  end     + ':' +  case when len(datepart(mi, Order_date)) = 1 then '0' +     convert(nvarchar(100), datepart(mi, Order_date)) else   convert(nvarchar(100), datepart(mi, Order_date))  end        end FROM TemplatesOrders  WITH (nolock)  inner join                       SheetShortHands ON TemplatesOrders.def_key = CAST(SheetShortHands.Temp_Def_Key as varchar(20))    WHERE         TemplatesOrders.patient_ID = '" + Patient_ID + "'       and  TemplatesOrders.orderkey in(" + OrderKey + ")";
            return dbcon.GetData(SelectString);
        }

        public string executeQuery(string query)
        {
            DataTable dt = dbcon.GetData(query);
            if (dt.Rows[0][0].ToString() == "")
                return "";

            return dt.Rows[0][0].ToString();
        }
      

    }
}
