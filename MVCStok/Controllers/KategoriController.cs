using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models;
using PagedList;
using PagedList.Mvc;

namespace MVCStok.Controllers
{
    public class KategoriController : Controller
    {
        DbMVCProjeEntities1 db = new DbMVCProjeEntities1 ();
        public ActionResult Index(int sayfa=1)
        {
            //var values = db.tblKategoriler.ToList();
            var values = db.tblKategoriler.ToList().ToPagedList(sayfa,4);
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(tblKategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.tblKategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.tblKategoriler.Find(id);
            db.tblKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tblKategoriler.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult KategoriGuncelle(tblKategoriler p1)
        {
            var ktg = db.tblKategoriler.Find(p1.KategoriID);
            ktg.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}