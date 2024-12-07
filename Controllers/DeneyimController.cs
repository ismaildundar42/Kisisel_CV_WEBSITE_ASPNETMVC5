using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVCCVsitesi.Models.Entitiy;

namespace UdemyMVCCVsitesi.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(tbl_deneyim deneyim)
        {
            repo.TAdd(deneyim);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            tbl_deneyim t = repo.Find(x => x.ID==id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            tbl_deneyim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(tbl_deneyim p)
        {
            tbl_deneyim t = repo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.Baslik=p.Baslik;
            t.AltBaslik=p.AltBaslik;
            t.Tarih =p.Tarih;
            t.Aciklama=p.Aciklama;

            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}