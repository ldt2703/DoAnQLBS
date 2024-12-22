using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using DoAnQLBS.Models;

namespace DoAnQLBS.Controllers
{
    public class ChuDeController : Controller
    {
        // GET: ChuDe
        QLBSEntities db = new QLBSEntities();
        public PartialViewResult ChuDePartial()
        {
            return PartialView(db.CHUDEs.Take(5).ToList());
        }
        public ViewResult ChuDeSach(int machude=0)
        {
            CHUDE cd = db.CHUDEs.SingleOrDefault(b => b.MACHUDE == machude);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<SACH> sach = db.SACHes.Where(n=>n.MACHUDE == machude).OrderBy(b=>b.GIABAN).ToList();
            if(sach.Count == 0)
            {
                ViewBag.sach = "Không có sách nào thuộc chủ đề này";
            }
            return View(sach);
        }
        public ViewResult DanhMucChuDe()
        {
            return View(db.CHUDEs.ToList());
        }
    }
}