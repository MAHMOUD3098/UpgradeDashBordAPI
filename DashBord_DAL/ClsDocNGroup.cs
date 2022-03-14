using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    //--ClsDocNGroup class
    public class ClsDocNGroup
    {
        public string Grp_key { get; set; }
        public string Grp_desc { get; set; }
        public List<ClsDocNUser> Grp_Users { get; set; }
    }
}
