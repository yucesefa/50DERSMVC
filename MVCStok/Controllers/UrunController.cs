using MVCStok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStok.Controllers
{
    public class UrunController : Controller
    {
        DbMVCProjeEntities1 db = new DbMVCProjeEntities1();
        public ActionResult Index()
        {
            var values = db.tblUrunler.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> values = (from i in db.tblKategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KategoriAd,
                                               Value = i.KategoriID.ToString()
                                           }).ToList();
            ViewBag.vl=values;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(tblUrunler p1)
        {
            var ktg = db.tblKategoriler.
                Where(x => x.KategoriID == p1.tblKategoriler.KategoriID)
                .FirstOrDefault();
            p1.tblKategoriler= ktg;
            db.tblUrunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}