using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class ManagmentTicketModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();
        public IEnumerable<VEMAYBAY> Listvemaybay()
        {
            return db.VEMAYBAYs.ToList();
        }

        public VEMAYBAY layOnevemaybay(string id)
        {
            return db.VEMAYBAYs.First(m => m.idVe == id);
        }
    }
}