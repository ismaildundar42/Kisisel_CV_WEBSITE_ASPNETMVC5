using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVCCVsitesi.Models.Entitiy;
using UdemyMVCCVsitesi.Repostroies;

namespace UdemyMVCCVsitesi.Controllers
{
   
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<tbl_login> repo = new GenericRepository<tbl_login>();


        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }

        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(tbl_login p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            tbl_login t = repo.Find(x => x.ID == id);
            repo.TRemove(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            tbl_login t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(tbl_login p)
        {
            tbl_login t = repo.Find(x => x.ID == p.ID);
            t.ID = p.ID;
            t.KullaniciAdi = p.KullaniciAdi;
            t.Sifre = p.Sifre;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}