using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using DoAnQLBS.Models;
using System.Web.UI.WebControls;

namespace DoAnQLBS.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QLBSEntities db = new QLBSEntities();
        [HttpGet]
        public ActionResult KetQua(string TuKhoa, int? page)
        {
            ViewBag.tk = TuKhoa;
            List<SACH> lkq = db.SACHes.Where(n => n.TENSACH.Contains(TuKhoa)).ToList();
            int PageNumber = (page ?? 1);
            int pageSize = 2;
            if (lkq.Count == 0)
            { 
                ViewBag.ThongBao = "Không tìm thấy sách";
            }
            return View(lkq.OrderBy(n => n.TENSACH).ToPagedList(PageNumber, pageSize));

        }
        [HttpPost]
        public ActionResult KetQua(FormCollection f, int? page)
        {
            string TuKhoa = f["timkiem"].ToString();
            ViewBag.tk = TuKhoa;
            List<SACH> lkq = db.SACHes.Where(n=>n.TENSACH.Contains(TuKhoa)).ToList();
            int PageNumber = (page ?? 1);
            int pageSize = 2;
            if (lkq.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sách";
            }
            return View(lkq.OrderBy(n => n.TENSACH).ToPagedList(PageNumber, pageSize));
            
        }
       
    }
}