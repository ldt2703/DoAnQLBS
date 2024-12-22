using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnQLBS.Models;

namespace DoAnQLBS.Controllers
{
    public class NXBController : Controller
    {
        // GET: NXB
        QLBSEntities db = new QLBSEntities();
        public PartialViewResult NXBPartial()
        {
            return PartialView(db.NXBs.Take(5).OrderBy(n => n.TENNXB).ToList());
        }
        public ViewResult sachtheonxb(int manxb=0)
        {
            NXB nxb = db.NXBs.SingleOrDefault(b => b.MANXB == manxb);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<SACH> sach = db.SACHes.Where(n => n.MANXB == manxb).OrderBy(b => b.GIABAN).ToList();
            if (sach.Count == 0)
            {
                ViewBag.sach = "Sách vẫn chưa nhập về mong quý khách thông cảm";
            }
            return View(sach);
        }
        public ViewResult DanhMucNXB()
        {
            return View(db.NXBs.ToList());
        }
    }
}