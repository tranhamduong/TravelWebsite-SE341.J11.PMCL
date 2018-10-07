using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public abstract class BaseDAO
    {
        public static TravelDatabase db = null;
        public BaseDAO() { }

        public virtual bool Delete(string key) { return false; }
    }
}
