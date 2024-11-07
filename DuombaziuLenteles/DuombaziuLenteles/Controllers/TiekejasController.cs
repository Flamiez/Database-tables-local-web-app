using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuombaziuLenteles.Repos;
using DuombaziuLenteles.Models;

namespace DuombaziuLenteles.Controllers
{
    public class TiekejasController : Controller
    {
        //apibreziamos saugyklos kurios naudojamos šiame valdiklyje
        tiekejasRepository tiekejasRepository = new tiekejasRepository();
        // GET: Klientas
        public ActionResult Index()
        {
            //grazinamas klientų sarašas
            return View(tiekejasRepository.getTiekejai());
        }

        // GET: Klientas/Create
        public ActionResult Create()
        {
            tiekejas darbuotojas = new tiekejas();
            return View(darbuotojas);
        }

        // POST: Klientas/Create
        [HttpPost]
        public ActionResult Create(tiekejas collection)
        {
            try
            {
                tiekejasRepository.addTiekejas(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Klientas/Edit/5
        public ActionResult Edit(int id)
        {
            return View(tiekejasRepository.getTiekejas(id));
        }

        // POST: Klientas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, tiekejas collection)
        {
            try
            {
                // Atnaujina kliento informacija
                if (ModelState.IsValid)
                {
                    tiekejasRepository.updateTiekejas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Klientas/Delete/5
        public ActionResult Delete(int id)
        {
            return View(tiekejasRepository.getTiekejas(id));
        }

        // POST: Klientas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                tiekejasRepository.deleteTiekejas(id);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}