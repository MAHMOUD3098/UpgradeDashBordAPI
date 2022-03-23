using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBord_DAL
{
    public class RepositoryDb<TEntity> where TEntity : class
    {
        MedicaDAL.DBInteraction df;
        public RepositoryDb()
        {
            df = new MedicaDAL.DBInteraction(true);
        }
        public virtual MedicaDAL.DBInteraction getdb()
        {
            return df;
        }
        public MedcaDalDB  getDal()
        {
            return new MedcaDalDB();
        }

    }
}
