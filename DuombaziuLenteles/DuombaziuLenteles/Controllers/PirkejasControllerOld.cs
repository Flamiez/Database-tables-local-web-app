using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuombaziuLenteles.Repos;
using DuombaziuLenteles.Models;

namespace DuombaziuLenteles.Controllers
{
    public class PirkejasController: Controller
    {
        //apibreziamos saugyklos kurios naudojamos šiame valdiklyje
        PirkejasRepository pirkejasRepository = new PirkejasRepository();
        // GET: Klientas
        public ActionResult Index()
        {
            //grazinamas klientų sarašas
            return View(pirkejasRepository.getPirkejai());
        }

        // GET: Klientas/Create
        public ActionResult Create()
        {
            pirkejas pirkejas = new pirkejas();
            return View(pirkejas);
        }

        // POST: Klientas/Create
        [HttpPost]
        public ActionResult Create(pirkejas collection)
        {
            try
            {
                pirkejasRepository.addPirkejas(collection);
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
            return View(pirkejasRepository.getPirkejas(id));
        }

        // POST: Klientas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, pirkejas collection)
        {
            try
            {
                // Atnaujina kliento informacija
                if (ModelState.IsValid)
                {
                    pirkejasRepository.updatePirkejas(collection);
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
            return View(pirkejasRepository.getPirkejas(id));
        }

        // POST: Klientas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                pirkejasRepository.deletePirkejas(id);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}