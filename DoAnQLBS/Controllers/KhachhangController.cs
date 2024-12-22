using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DoAnQLBS.Models;

namespace DoAnQLBS.Controllers
{
    public class KhachhangController : Controller
    {
        // GET: Khachhang
        QLBSEntities db = new QLBSEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KHACHHANG mykh)
        {    
            KHACHHANG kh = db.KHACHHANGs.Where(n=>n.TAIKHOAN == mykh.TAIKHOAN).FirstOrDefault();   
            if(kh != null)
            {
                ModelState.AddModelError("TaiKhoan", "Tài khoản đã tồn tại");
                return View();
            }
            else if (ModelState.IsValid)
            {
                kh = new KHACHHANG();
                kh.TAIKHOAN = mykh.TAIKHOAN;
                kh.MATKHAU = mykh.MATKHAU;
                db.KHACHHANGs.Add(kh);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();     
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string taikhoan = f["txtTaiKhoan"].ToString();
            string matkhau = f["txtMatKhau"].ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(b => b.TAIKHOAN == taikhoan && b.MATKHAU == matkhau);
            if (kh != null && taikhoan != "sa" && matkhau != "sa")
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index","Home");
            }
            if (kh!= null && taikhoan == "sa" && matkhau == "sa")
            {
                return RedirectToAction("Index", "Admin");
            }
            else ViewBag.ThongBao = "Tài khoản hoặc mật khẩu không chính xác";
            return View();
        }
        public ActionResult DangXuat()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}