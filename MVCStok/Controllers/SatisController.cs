using MVCStok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStok.Controllers
{
    public class SatisController : Controller
    {
        DbMVCProjeEntities1 db = new DbMVCProjeEntities1 ();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tblSatislar p)
        {
            db.tblSatislar.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}