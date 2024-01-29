using MVCStok.Models;
using PagedList;
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
        public ActionResult Index(int? sayfa,string p)
        {
            
            //var values = db.tblMusteriler.ToList();
            var values = from d in db.tblMusteriler select d;
            if(!string.IsNullOrEmpty(p))
            {
                values = values.Where(x => x.MusteriAd.Contains(p));
            }
            return View(values.ToList().ToPagedList(sayfa??1,4));
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tblMusteriler p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tblMusteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(int id)
        {
            var musteriler = db.tblMusteriler.Find(id);
            db.tblMusteriler.Remove(musteriler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.tblMusteriler.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult MusteriGuncelle(tblMusteriler p1)
        {
            var musteri = db.tblMusteriler.Find(p1.MusteriID);
            musteri.MusteriAd = p1.MusteriAd;
            musteri.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}