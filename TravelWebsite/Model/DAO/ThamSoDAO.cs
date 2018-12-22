using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ThamSoDAO : BaseDAO
    {
        public static string getInternalPR() {
            db = new TravelDatabase();
            return db.ThamSoes.FirstOrDefault().InternalTourPR;
        }

        public static string getExternalPR()
        {
            db = new TravelDatabase();
            return db.ThamSoes.FirstOrDefault().ExternalTourPR;
        }

        public static string getVISACharge()
        {
            db = new TravelDatabase();
            return db.ThamSoes.FirstOrDefault().VISAcharge;
        }

        public static void setInternalPR(string id)
        {
            db = new TravelDatabase();
            var ts = db.ThamSoes.FirstOrDefault();
            ts.InternalTourPR = id.Trim();

            db.SaveChanges();
        }

        public static void getExternalPR(string id)
        {

        }

        public static void setExternalPR(string id)
        {
            db = new TravelDatabase();
            var ts = db.ThamSoes.FirstOrDefault();
            ts.ExternalTourPR = id.Trim();

            db.SaveChanges();
        }
    }
}
