using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    //--GetSheetsResults SheetUI class
    public class SheetUI : Sheet
    {

        public string SheetStatusImg { set; get; }

        public string SheetStatusDesc { set; get; }

        public string SheetDateDisplay { set; get; }

        public string SheetTimeDisplay { set; get; }


        public void UpdateUI()
        {
            this.SheetStatusDesc = this.SheetStatus.ToString();
            this.SheetStatusDesc = this.SheetStatusDesc.Replace("Recoreded", "Recorded");
            if (this.SheetDate != null)
            {
                this.SheetDateDisplay = String.Format("{0:dd-MMM-yy}", Convert.ToDateTime(this.SheetDate.ToString()));  // this.InvDate.ToString();
            }
            else
            {
                if (SheetCode == "0")
                {
                    this.SheetStatusDesc = "";
                }
                else
                {
                    this.SheetStatusDesc = "Open";
                }
            }
            if (this.SheetTime != null)
                this.SheetTimeDisplay = String.Format("{0:HH:mm}", Convert.ToDateTime(this.SheetTime.ToString()));  // this.InvDate.ToString();

            if (this.OrderType == "2")
            {
                this.SheetStatusImg = "Images/ProcImages/book_open.ico";
            }
            else if (this.OrderType == "3")
            {
                this.SheetStatusImg = "Images/OPTImages/OrderOPT.png";
            }
            else
            {
                switch (this.SheetStatus)
                {
                    case ConstantsVariables.SheetStatus.Cancelled:
                        this.SheetStatusImg = "Images/SheetImages/cancel_sht.ico";
                        break;
                    case ConstantsVariables.SheetStatus.Recoreded:
                        this.SheetStatusImg = "Images/SheetImages/new_sht.ico";
                        break;
                    case ConstantsVariables.SheetStatus.Signed:
                        this.SheetStatusImg = "Images/SheetImages/sign_sht.ico";
                        break;
                }
            }
        }
    }
}
