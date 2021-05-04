﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class BooknowModel
    {
        DBEntities_QLHeThongDatVeMayBay db = new DBEntities_QLHeThongDatVeMayBay();

        public IEnumerable<VEMAYBAY> ListVe()
        {
            return db.VEMAYBAYs.ToList();
        }
        public VEMAYBAY NhanOneVBM(string idVe)
        {
            return db.VEMAYBAYs.First(m => m.idVe == idVe);
        }
    }
}