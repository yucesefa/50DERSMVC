using MVCStok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStok.Controllers
{
    public class MusteriController : Controller
    {
        DbMVCProjeEntities1 db = new DbMVCProjeEntities1();
        public ActionResult Index()
        {
            var values = db.tblMusteriler.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tblMusteriler p1)
        {
            db.tblMusteriler.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}