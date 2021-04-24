using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace HeThongQuanLyDatVeMayBay.Models
{
    public class Content
    {
        public static string QuyenUser = "";
        public static string HoTen = ""; 
        public static string TenDangNhap = "";
        public static string Password = ""; 
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }        
    }
}