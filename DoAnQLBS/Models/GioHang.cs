using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnQLBS.Models
{
    public class GioHang
    {
        QLBSEntities db = new QLBSEntities();
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string HinhAnh {get; set; }
        public double DonGia { get; set; }
        public int SoLuong {get; set; }
        public double ThanhTien { get { return SoLuong * DonGia; } }
        public GioHang(int masp)
        {
            MaSP = masp;
            SACH sach = db.SACHes.Single(n => n.MASACH == MaSP);
            TenSP = sach.TENSACH;
            HinhAnh = sach.ANHBIA;
            DonGia = (double)sach.GIABAN;
            SoLuong = 1;
        }
    }
}