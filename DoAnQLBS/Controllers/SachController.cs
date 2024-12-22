using DoAnQLBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnQLBS.Models;

namespace DoAnQLBS.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        QLBSEntities db = new QLBSEntities();
        public PartialViewResult SachPartial()
        {
            var lstsach = db.SACHes.Take(3).ToList();
            return PartialView(lstsach);
        }
        public ViewResult xemchitiet(int MaSach=0)
        {
            SACH sach = db.SACHes.SingleOrDefault(b => b.MASACH == MaSach);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
    }
}