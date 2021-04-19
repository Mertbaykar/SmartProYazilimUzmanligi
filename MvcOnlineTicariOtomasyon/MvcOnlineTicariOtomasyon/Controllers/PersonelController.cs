using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                select new SelectListItem
                {
                    Text = x.DepartmanAd,
                    Value = x.Departmanid.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = c.Personels.Find(id);
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                select new SelectListItem
                {
                    Text = x.DepartmanAd,
                    Value = x.Departmanid.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            var deger = c.Personels.Find(p.Personelid);
            deger.PersonelAd = p.PersonelAd;
            deger.PersonelSoyad = p.PersonelSoyad;
            deger.PersonelGorsel = p.PersonelGorsel;
            deger.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}