using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVCCVsitesi.Models.Entitiy;
using UdemyMVCCVsitesi.Repostroies;
namespace UdemyMVCCVsitesi.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<tbl_oduller> repo = new GenericRepository<tbl_oduller>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGuncelle(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGuncelle(tbl_oduller s)
        {
            var sertifika = repo.Find(x => x.ID == s.ID);
            sertifika.Tarih = s.Tarih;
            sertifika.Aciklama = s.Aciklama;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(tbl_oduller s)
        {
            repo.TAdd(s);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.TRemove(sertifika);
            return RedirectToAction("Index");
        }
    }
}