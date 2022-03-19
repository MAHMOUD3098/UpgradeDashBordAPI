using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_BL
{
   public class Assessments
    {
        public string AttachNote { get; set; }
        public string SheetKey { get; set; }
        public string SheetDefKey { get; set; }
        public string TemplateKey { get; set; }
        public string Status { get; set; }
        public string ReportKey { get; set; }
        public string EpisodeKey { get; set; }
        public string Description { get; set; }
        public string Staff_name { get; set; }
        public string DateTimeStamp { get; set; }
        public string PATIENT_ID { get; set; }
        public string User_Key { set; get; }

        public string Ico_Status { get; set; }
        public string Desc_Status { get; set; }
    }
}
