using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DoAnQLBS.Models;
using PagedList;
using PagedList.Mvc;

namespace DoAnQLBS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        QLBSEntities db = new QLBSEntities();
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(db.SACHes.ToList().OrderBy(n => n.MASACH).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MaChuDe = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.TENCHUDE), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NXBs.ToList().OrderBy(n => n.TENNXB),"MaNXB","TenNXB");
            return View();
        }
        [HttpPost]
        public ActionResult Create(SACH s, HttpPostedFileBase upanh)
        {
            ViewBag.MaChuDe = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.TENCHUDE), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NXBs.ToList().OrderBy(n => n.TENNXB), "MaNXB", "TenNXB");
            if (upanh == null)
            {
                ViewBag.ThongBao = "Yêu cầu chọn ảnh";
                return View();
            }
            else { 
                var filename = Path.GetFileName(upanh.FileName);
                var path = Path.Combine(Server.MapPath("~/Hinh anh"), filename);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Ảnh đã tồn tại";
                }
                else
                {
                    upanh.SaveAs(path);
                }
                s.ANHBIA = upanh.FileName;
            }  
            db.SACHes.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
        [HttpGet]
        public ActionResult Edit(int MaSach)
        {
            SACH s = db.SACHes.SingleOrDefault(n => n.MASACH == MaSach);
            if (s == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaChuDe = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.TENCHUDE), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NXBs.ToList().OrderBy(n => n.TENNXB), "MaNXB", "TenNXB");
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(SACH sach)
        {
            SACH s = db.SACHes.FirstOrDefault(n => n.MASACH == sach.MASACH);   
            s.TENSACH = sach.TENSACH;
            s.GIABAN = sach.GIABAN;
            s.MOTA = sach.MOTA;
            s.NGAYCAPNHAT = sach.NGAYCAPNHAT;
            s.SOLUONGTON = sach.SOLUONGTON;
            s.Moi = sach.Moi;
            s.ANHBIA = sach.ANHBIA;
            ViewBag.MaChuDe = new SelectList(db.CHUDEs.ToList().OrderBy(n => n.TENCHUDE), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NXBs.ToList().OrderBy(n => n.TENNXB), "MaNXB", "TenNXB");
            db.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
        public ActionResult Delete(int MaSach)
        {

            SACH s = db.SACHes.SingleOrDefault(n => n.MASACH == MaSach);
            if (s == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(s);
        }
        [HttpPost]
        public ActionResult Delete(int MaSach ,SACH sach)
        {
            SACH s = db.SACHes.FirstOrDefault(n => n.MASACH == MaSach);
            db.SACHes.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult Details(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(db.SACHes.ToList().OrderBy(n => n.MASACH).ToPagedList(pageNumber, pageSize));
        }
    }
}