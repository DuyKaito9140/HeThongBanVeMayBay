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
        //ACCOUNT
        public static string QuyenUser = "";        
        public static string TenDangNhap = "";
        public static string Password = "";

        //USER
        public static string idUser = ""; 
        public static string HoTen = ""; 
        public static string Ngaysinh = "";
        public static string Gioitinh = "";
        public static string cmnd = "";
        public static string email = "";
        public static string sdt = "";
        public static string Diachi = "";
        public static string Quoctich = "";
        //HÃNG
        public static string TenHang = ""; 
        public static string EmailHang = ""; 
        public static string SdtHang = "";  
        private static Random random = new Random();

        public static string idquyen = "";
        public static string codekhuyenmai= "";
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
        public static string TienByString(string tongtien)
        {
            string sum = "";            
            if (tongtien.Length == 9)
            {
                sum = tongtien[0].ToString() + tongtien[1].ToString() + tongtien[2].ToString() + "." + tongtien[3].ToString() + tongtien[4].ToString() + tongtien[5].ToString() + "." + tongtien[6].ToString() + tongtien[7].ToString() + tongtien[8].ToString();
            }
            else if (tongtien.Length == 8)
            {
                sum = tongtien[0].ToString() + tongtien[1].ToString() + "." + tongtien[2].ToString() + tongtien[3].ToString() + tongtien[4].ToString() + "." + tongtien[5].ToString() + tongtien[6].ToString() + tongtien[7].ToString();
            }
            else if (tongtien.Length == 7)
            {
                sum = tongtien[0].ToString() + "." + tongtien[1].ToString() + tongtien[2].ToString() + tongtien[3].ToString() + "." + tongtien[4].ToString() + tongtien[5].ToString() + tongtien[6].ToString();
            }
            else if (tongtien.Length == 6)
            {
                sum = tongtien[0].ToString() + tongtien[1].ToString() + tongtien[2].ToString() + "."  + tongtien[3].ToString() + tongtien[4].ToString() + tongtien[5].ToString();
            }
            else if (tongtien.Length == 5)
            {
                sum = tongtien[0].ToString() + tongtien[1].ToString() + "." + tongtien[2].ToString() + tongtien[3].ToString() + tongtien[4].ToString();
            }
            else if (tongtien.Length == 0 || tongtien.Length == 1 || tongtien == "" || tongtien =="0")
            {
                sum = "0";
            }
            return sum;
        }
    }
}