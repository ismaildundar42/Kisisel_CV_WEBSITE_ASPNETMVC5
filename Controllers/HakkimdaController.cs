using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVCCVsitesi.Models.Entitiy;
using UdemyMVCCVsitesi.Repostroies;
namespace UdemyMVCCVsitesi.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbCVSitesiEntities db = new DbCVSitesiEntities();
        GenericRepository<tbl_hakkimda> repo = new GenericRepository<tbl_hakkimda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(tbl_hakkimda h)
        {
            var hakkimda = repo.Find(x => x.ID == 1);
            hakkimda.Ad = h.Ad;
            hakkimda.Soyad = h.Soyad;
            hakkimda.Adres = h.Adres;
            hakkimda.Telefon = h.Telefon;
            hakkimda.Resim = h.Resim;
            hakkimda.Aciklama = h.Aciklama;
            hakkimda.Mail = h.Mail;

            repo.TUpdate(hakkimda);
            return RedirectToAction("Index");
        }
        
       
    }
}