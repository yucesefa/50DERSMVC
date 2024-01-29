using MVCStok.Models;
using PagedList;
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
        public ActionResult UrunSil(int id)
        {
            var urunler = db.tblUrunler.Find(id);
            db.tblUrunler.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.tblUrunler.Find(id);
            List<SelectListItem> values = (from i in db.tblKategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KategoriAd,
                                               Value = i.KategoriID.ToString()
                                           }).ToList();
            ViewBag.vl = values;
            return View("UrunGetir",urun);
        }
        public ActionResult Guncelle(tblUrunler p)
        {
            var urn = db.tblUrunler.Find(p.UrunID);
            urn.UrunAd = p.UrunAd;
            urn.Marka = p.Marka;
            urn.Stok = p.Stok;
            urn.Fiyat = p.Fiyat;
            //urn.UrunKategori = p.UrunKategori;
            var ktg = db.tblKategoriler.
                Where(x => x.KategoriID == p.tblKategoriler.KategoriID)
                .FirstOrDefault();
            urn.UrunKategori = ktg.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}