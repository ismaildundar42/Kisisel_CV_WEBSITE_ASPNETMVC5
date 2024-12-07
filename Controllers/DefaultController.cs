using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVCCVsitesi.Models.Entitiy;

namespace UdemyMVCCVsitesi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCVSitesiEntities db = new DbCVSitesiEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_hakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.tbl_deneyim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult SosyalMedya()
        {
            var sosyal = db.tbl_sosyalmedya.Where(x => x.Durum==true).ToList();
            return PartialView(sosyal);
        }
        public PartialViewResult Egitim()
        {
            var egitimlerim = db.tbl_egitim.ToList();
            return PartialView(egitimlerim);
        }
        public PartialViewResult Yetenekler()
        {
            var yeteneklerim = db.tbl_yetenekler.ToList();
            return PartialView(yeteneklerim);
        }
        public PartialViewResult Hobiler()
        {
            var hobilerim = db.tbl_hobiler.ToList();
            return PartialView(hobilerim);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifikalarim = db.tbl_oduller.ToList();
            return PartialView(sertifikalarim);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            var iletisim = db.tbl_iletisim.ToList();
            return PartialView(iletisim);
        }
        [HttpPost]
        public PartialViewResult Iletisim(tbl_iletisim t)
        {
            t.Tarih= DateTime.Parse(DateTime.Now.ToShortTimeString());
            db.tbl_iletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}