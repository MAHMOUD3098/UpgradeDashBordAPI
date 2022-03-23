using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_BL
{
    public class EMRLogic<T> where T : class
    {
        private PatDoc_BL Docment;
        
        private PatPro_BL problm;
        public EMRLogic(int type)
        {
            if (type == 1)
            {
                this.Docment = new PatDoc_BL();
            }
            else if (type == 2)
            {
                this.problm = new PatPro_BL();
            }
        }
        public virtual PatDoc_BL GetPatDoc_BL()
        {
            return this.Docment;
        }
        public virtual PatPro_BL GetPatPro_BLL()
        {
            return this.problm;
        }

    }
}
