using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    //--SheetFactory class
    public class SheetFactory
    {
        public virtual Sheet createSheet()
        {
            return new Sheet();
        }
    }
}
