using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVCCVsitesi.Models.Entitiy;
using UdemyMVCCVsitesi.Repostroies;
namespace UdemyMVCCVsitesi.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        DbCVSitesiEntities db = new DbCVSitesiEntities();
        GenericRepository<tbl_egitim> repo = new GenericRepository<tbl_egitim>();
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(tbl_egitim e)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(e);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TRemove(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(tbl_egitim e)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }

            var egitim = repo.Find(x => x.ID == e.ID);
            egitim.Baslik = e.Baslik;
            egitim.AltBaslik1 = e.AltBaslik1;
            egitim.AltBaslik2 = e.AltBaslik2;
            egitim.GANO = e.GANO;
            egitim.Tarih = e.Tarih;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}