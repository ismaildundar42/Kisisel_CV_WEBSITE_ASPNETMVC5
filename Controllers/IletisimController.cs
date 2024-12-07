using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyMVCCVsitesi.Models.Entitiy;
using UdemyMVCCVsitesi.Repostroies;
namespace UdemyMVCCVsitesi.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        GenericRepository<tbl_iletisim> repo = new GenericRepository<tbl_iletisim>();
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
        public ActionResult IletisimSil(int id)
        {
            var iletisim = repo.Find(x => x.ID == id);
            repo.TRemove(iletisim);
            return RedirectToAction("Index");
        }
    }
}