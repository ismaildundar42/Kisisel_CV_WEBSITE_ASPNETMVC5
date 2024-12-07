using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVCCVsitesi.Models.Entitiy;
using UdemyMVCCVsitesi.Repostroies;
namespace UdemyMVCCVsitesi.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<tbl_sosyalmedya> repo = new GenericRepository<tbl_sosyalmedya> ();
        DbCVSitesiEntities db = new DbCVSitesiEntities ();
        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tbl_sosyalmedya s)
        {
            repo.TAdd (s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalMedyaDuzenle(int id)
        {
            var sosyalmedya = repo.Find(x => x.ID == id);
            return View(sosyalmedya);
        }
        [HttpPost]
        public ActionResult SosyalMedyaDuzenle(tbl_sosyalmedya s)
        {
            var sosyalmedya = repo.Find(x => x.ID == s.ID);
            sosyalmedya.Ad = s.Ad;
            sosyalmedya.Link = s.Link;
            sosyalmedya.Ikon = s.Ikon;
            sosyalmedya.Durum = true;
            repo.TUpdate (sosyalmedya);
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hesap = repo.Find (x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}