using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnQLBS.Models;

namespace DoAnQLBS.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        QLBSEntities db = new QLBSEntities();
        public List<GioHang> LayGioHang()
        {
            //session dung de luu lai cho toan bo trang web de khi can thi co the tai su dung
            List<GioHang> lgh = Session["GioHang"] as List<GioHang>;
            if(lgh == null)
            {
                lgh = new List<GioHang>();
                Session["GioHang"] = lgh;
            }
            return lgh;
        }
        public ActionResult ThemGioHang(int MaSP, string duongdan) 
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.MASACH == MaSP);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lgh = LayGioHang();
            GioHang gh = lgh.Find(n => n.MaSP == MaSP);
            if (gh == null)
            {
                gh = new GioHang(MaSP);
                lgh.Add(gh);
                return Redirect(duongdan);
            }
            else
            {
                gh.SoLuong++;
                return Redirect(duongdan);
            }
        }
        public ActionResult CapNhatGioHang(int MaSP, FormCollection f)
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.MASACH == MaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lgh = LayGioHang();
            GioHang gh = lgh.SingleOrDefault(n => n.MaSP == MaSP);
            if(gh != null)
            {
                gh.SoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang(int MaSP)
        {
            SACH sach = db.SACHes.SingleOrDefault(n => n.MASACH == MaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lgh = LayGioHang();
            GioHang gh = lgh.SingleOrDefault(n => n.MaSP == MaSP);
            if (gh != null)
            {
                lgh.RemoveAll(n=>n.MaSP == gh.MaSP);    
            }
            if (lgh.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lgh = LayGioHang();
            return View(lgh);
        }
        private int TongSL()
        {
            int TongSL = 0;
            List<GioHang> lgh = Session["GioHang"] as List<GioHang>;
            if (lgh != null)
            {
                TongSL = lgh.Sum(n => n.SoLuong);
            }
            return TongSL;
        }
        private double TongTien()
        {
            double TongTien = 0;
            List<GioHang> lgh = Session["GioHang"] as List<GioHang>;
            if (lgh != null)
            {
                TongTien = lgh.Sum(n => n.ThanhTien);
            }
            return TongTien;
        }
        public ActionResult GioHangPartial() 
        {
            if(TongSL() == 0)
            {
                return PartialView();   
            }
            ViewBag.TongSoLuong = TongSL();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lgh = LayGioHang();
            return View(lgh);
        }
        [HttpPost]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Khachhang");
            }
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            DONHANG dh = new DONHANG();
            KHACHHANG kh = (KHACHHANG)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            dh.MAKH = kh.MAKH;
            dh.NGAYDAT = DateTime.Now;
            db.DONHANGs.Add(dh);
            foreach(var item in gh)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                ctdh.MADONHANG = dh.MADONHANG;
                ctdh.MASACH = item.MaSP;
                ctdh.SOLUONG = item.SoLuong;
                ctdh.DONGIA = (int)item.DonGia;
            }
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}