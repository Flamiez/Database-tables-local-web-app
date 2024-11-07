//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using DuombaziuLenteles.Repos;
//using DuombaziuLenteles.Models;

//namespace DuombaziuLenteles.Controllers
//{
//    public class DarbuotojasControllerOLD : Controller
//    {
//        //apibreziamos saugyklos kurios naudojamos šiame valdiklyje
//        DarbuotojasRepository darbuotojasRepository = new DarbuotojasRepository();
//        // GET: Klientas
//        public ActionResult Index()
//        {
//            //grazinamas klientų sarašas
//            return View(darbuotojasRepository.getDarbuotojai());
//        }

//        // GET: Klientas/Create
//        public ActionResult Create()
//        {
//            darbuotojas darbuotojas = new darbuotojas();
//            return View(darbuotojas);
//        }

//        // POST: Klientas/Create
//        [HttpPost]
//        public ActionResult Create(darbuotojas collection)
//        {
//            try
//            {
//                darbuotojasRepository.addDarbuotojas(collection);
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View(collection);
//            }
//        }

//        // GET: Klientas/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View(darbuotojasRepository.getDarbuotojas(id));
//        }

//        // POST: Klientas/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, darbuotojas collection)
//        {
//            try
//            {
//                // Atnaujina kliento informacija
//                if (ModelState.IsValid)
//                {
//                    darbuotojasRepository.updateDarbuotojas(collection);
//                }

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View(collection);
//            }
//        }

//        // GET: Klientas/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View(darbuotojasRepository.getDarbuotojas(id));
//        }

//        // POST: Klientas/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {

//                darbuotojasRepository.deleteDarbuotojas(id);


//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//    }
//}