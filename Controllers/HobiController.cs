using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVCCVsitesi.Models.Entitiy;
using UdemyMVCCVsitesi.Repostroies;

namespace UdemyMVCCVsitesi.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        DbCVSitesiEntities db = new DbCVSitesiEntities();
        GenericRepository<tbl_hobiler> repo = new GenericRepository<tbl_hobiler>();
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobiEkle(tbl_hobiler e)
        {
            if (!ModelState.IsValid)
            {
                return View("HobiEkle");
            }
            repo.TAdd(e);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HobiGuncelle(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            return View(hobi);
        }
        [HttpPost]
        public ActionResult HobiGuncelle(tbl_hobiler s)
        {
            var hobi = repo.Find(x => x.ID == s.ID);
            hobi.Hobi1 = s.Hobi1;
            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(tbl_hobiler h)
        {
            var hobi = repo.Find(x => x.ID == h.ID);
            repo.TRemove(hobi);
            return RedirectToAction("Index");
        }
    }
}