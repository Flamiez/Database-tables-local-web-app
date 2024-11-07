//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using DuombaziuLenteles.Repos;
//using DuombaziuLenteles.ViewModels;

//namespace AutoNuoma.Controllers
//{
//    public class SandelysControllerOLD : Controller
//    {
//        //apibreziamos saugyklos kurios naudojamos siame valdiklyje
//        SandelysRepository draudimuRepository = new SandelysRepository();
//        ImoneRepository zidinysRepository = new ImoneRepository();
//        // GET: Modelis
//        public ActionResult Index()
//        {
//            return View(draudimuRepository.getSandeliai());
//        }

//        // GET: Modelis/Create
//        public ActionResult Create()
//        {
//            SandelysEditViewModel draudimas = new SandelysEditViewModel();
//            PopulateSelections(draudimas);
//            return View(draudimas);
//        }

//        // POST: Modelis/Create
//        [HttpPost]
//        public ActionResult Create(SandelysEditViewModel collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here
//                if (ModelState.IsValid)
//                {
//                    draudimuRepository.addSandelys(collection);
//                }

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                PopulateSelections(collection);
//                return View(collection);
//            }
//        }

//        public ActionResult Edit(int id)
//        {
//            SandelysEditViewModel sandelys = draudimuRepository.getSandelys(id);
//            PopulateSelections(sandelys);
//            return View(sandelys);
//        }

//        // POST: Modelis/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, SandelysEditViewModel collection)
//        {
//            try
//            {
//                // TODO: Add update logic here
//                if (ModelState.IsValid)
//                {
//                    draudimuRepository.updateSandelys(collection);
//                }

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                PopulateSelections(collection);
//                return View(collection);
//            }
//        }

//        // GET: Modelis/Delete/5
//        public ActionResult Delete(int id)
//        {
//            SandelysEditViewModel modelis = draudimuRepository.getSandelys(id);
//            return View(modelis);
//        }

//        // POST: Modelis/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {

//                draudimuRepository.deleteSandelys(id);


//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View(collection);
//            }
//        }

//        public void PopulateSelections(SandelysEditViewModel modelis)
//        {
//            var zidiniai = zidinysRepository.getImones();
//            List<SelectListItem> selectListzidiniai = new List<SelectListItem>();

//            foreach (var item in zidiniai)
//            {
//                selectListzidiniai.Add(new SelectListItem() { Value = Convert.ToString(item.id), Text = item.pavadinimas});
//            }

//            modelis.ImonesList = selectListzidiniai;
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuombaziuLenteles.Repos;
using DuombaziuLenteles.ViewModels;

namespace AutoNuoma.Controllers
{
    public class SandelysController : Controller
    {
        //apibreziamos saugyklos kurios naudojamos siame valdiklyje
        SandelysRepository draudimuRepository = new SandelysRepository();
        ImoneRepository zidinysRepository = new ImoneRepository();
        // GET: Modelis
        public ActionResult Index()
        {
            return View(draudimuRepository.getSandeliai());
        }

        // GET: Modelis/Create
        public ActionResult Create()
        {
            SandelysEditViewModel draudimas = new SandelysEditViewModel();
            PopulateSelections(draudimas);
            return View(draudimas);
        }

        // POST: Modelis/Create
        [HttpPost]
        public ActionResult Create(SandelysEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    draudimuRepository.addSandelys(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        // GET: Modelis/Edit/5
        public ActionResult Edit(int id)
        {
            SandelysEditViewModel modelis = draudimuRepository.getSandelys(id);
            PopulateSelections(modelis);
            return View(modelis);
        }

        // POST: Modelis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SandelysEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    draudimuRepository.updateSandelys(collection,id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        // GET: Modelis/Delete/5
        public ActionResult Delete(int id)
        {
            SandelysEditViewModel modelis = draudimuRepository.getSandelys(id);
            return View(modelis);
        }

        // POST: Modelis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                draudimuRepository.deleteSandelys(id);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(SandelysEditViewModel modelis)
        {
            var zidiniai = zidinysRepository.getImones();
            List<SelectListItem> selectListzidiniai = new List<SelectListItem>();

            foreach (var item in zidiniai)
            {
                selectListzidiniai.Add(new SelectListItem() { Value = Convert.ToString(item.id), Text = item.pavadinimas });
            }

            modelis.ImonesList = selectListzidiniai;
        }
    }
}
