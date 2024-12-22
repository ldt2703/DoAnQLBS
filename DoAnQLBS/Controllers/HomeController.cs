using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnQLBS.Models;
using PagedList;
using PagedList.Mvc;

namespace DoAnQLBS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QLBSEntities db = new QLBSEntities();
        public ActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(db.SACHes.ToList().OrderBy(n=>n.GIABAN).ToPagedList(pageNumber,pageSize));
        }
            
    }
}