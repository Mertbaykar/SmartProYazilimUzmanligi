using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura

        Context c = new Context();

        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var deger = c.Faturalars.Find(id);
            return View("FaturaGetir", deger);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var deger = c.Faturalars.Find(f.Faturaid);
            deger.FaturaSeriNo = f.FaturaSeriNo;
            deger.FaturaSiraNo = f.FaturaSiraNo;
            deger.Saat = f.Saat;
            deger.Tarih = f.Tarih;
            deger.TeslimEden = f.TeslimEden;
            deger.TeslimAlan = f.TeslimAlan;
            deger.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem p)
        {
            c.FaturaKalems.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}