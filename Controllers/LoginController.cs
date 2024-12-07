﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UdemyMVCCVsitesi.Models.Entitiy;

namespace UdemyMVCCVsitesi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_login p)
        {
            DbCVSitesiEntities db = new DbCVSitesiEntities();
            var bilgi = db.tbl_login.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAdi,false);
                Session["KullaniciAdi"] = bilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index","Hakkimda");
            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcı adı veya şifreniz hatalı.";
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}