using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;

namespace MvcTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            Listele();

            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            var secilenUrun = c.Uruns.FirstOrDefault(u => u.Urunid == s.Urunid);
            if (secilenUrun != null)
            {
                if (secilenUrun.Stok < s.Adet)
                {
                    ModelState.AddModelError("", "Yeterli stok bulunmamaktadır.");
                    Listele();
                    return View(s);
                }
                else
                {
                    secilenUrun.Stok = (short)(secilenUrun.Stok - s.Adet);
                }
            }

            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            var deger = c.SatisHarekets.Find(id);
            Listele();
            return View("SatisGetir", deger);
        }

        public ActionResult SatisGuncelle(SatisHareket p)
        {
            var deger = c.SatisHarekets.Find(p.Satisid);
            deger.Cariid = p.Cariid;
            deger.Adet = p.Adet;
            deger.Fiyat = p.Fiyat;
            deger.Personelid = p.Personelid;
            deger.Tarih = p.Tarih;
            deger.ToplamTutar = p.ToplamTutar;
            deger.Urunid = p.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Satisid == id).ToList();
            return View(degerler);
        }

        private void Listele()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.Urunid.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.Cariid.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.Personelid.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
        }



        //[HttpPost]
        //public ActionResult YeniSatis(SatisHareket s)
        //{
        //    var secilenUrun = c.Uruns.FirstOrDefault(u => u.Urunid == s.Urunid);
        //    if (secilenUrun != null)
        //    {
        //        if (secilenUrun.Stok < s.Adet)
        //        {
        //            ModelState.AddModelError("", "Yeterli stok bulunmamaktadır.");
        //            Listele(); // ViewBag.dgr1, ViewBag.dgr2 ve ViewBag.dgr3 değerlerini tekrar ayarlar
        //            return View(s);
        //        }
        //        else
        //        {
        //            secilenUrun.Stok = (short)(secilenUrun.Stok - s.Adet);
        //        }
        //    }

        //    s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
        //    c.SatisHarekets.Add(s);
        //    c.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //private void Listele()
        //{
        //    List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.UrunAd,
        //                                       Value = x.Urunid.ToString()
        //                                   }).ToList();

        //    List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.CariAd + " " + x.CariSoyad,
        //                                       Value = x.Cariid.ToString()
        //                                   }).ToList();

        //    List<SelectListItem> deger3 = (from x in c.Personels.ToList()
        //                                   select new SelectListItem
        //                                   {
        //                                       Text = x.PersonelAd + " " + x.PersonelSoyad,
        //                                       Value = x.Personelid.ToString()
        //                                   }).ToList();

        //    ViewBag.dgr1 = deger1;
        //    ViewBag.dgr2 = deger2;
        //    ViewBag.dgr3 = deger3;
        //}



    }
}