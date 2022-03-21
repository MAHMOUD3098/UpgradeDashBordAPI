using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_BL
{
    //--UserSignOff class
    public class UserSignOff
    {
        string vUser_Name = "";
        public string User_Key { set; get; }
        public string User_Name
        {
            set { vUser_Name = value; }
            get { return vUser_Name + "    -- "; }
        }
        public string User_view_Date { set; get; }
    }
}
