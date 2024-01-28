using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models;

namespace MVCStok.Controllers
{
    public class KategoriController : Controller
    {
        DbMVCProjeEntities1 db = new DbMVCProjeEntities1 ();
        public ActionResult Index()
        {
            var values = db.tblKategoriler.ToList();
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
    }
}