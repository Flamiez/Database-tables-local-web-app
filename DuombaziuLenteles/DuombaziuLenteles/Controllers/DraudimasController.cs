using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuombaziuLenteles.Repos;
using DuombaziuLenteles.ViewModels;

namespace AutoNuoma.Controllers
{
    public class DraudimasController : Controller
    {
        //apibreziamos saugyklos kurios naudojamos siame valdiklyje
        DraudimasRepository draudimuRepository = new DraudimasRepository();
        zidinysRepository zidinysRepository = new zidinysRepository();
        // GET: Modelis
        public ActionResult Index()
        {
            return View(draudimuRepository.getDraudimai());
        }

        // GET: Modelis/Create
        public ActionResult Create()
        {
            DraudimasEditViewModel draudimas = new DraudimasEditViewModel();
            PopulateSelections(draudimas);
            return View(draudimas);
        }

        // POST: Modelis/Create
        [HttpPost]
        public ActionResult Create(DraudimasEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    draudimuRepository.addDraudimas(collection);
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
            DraudimasEditViewModel modelis = draudimuRepository.getDraudimas(id);
            PopulateSelections(modelis);
            return View(modelis);
        }

        // POST: Modelis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DraudimasEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    draudimuRepository.updateDraudimas(collection);
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
            DraudimasEditViewModel modelis = draudimuRepository.getDraudimas(id);
            return View(modelis);
        }

        // POST: Modelis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                draudimuRepository.deleteDraudimas(id);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(DraudimasEditViewModel modelis)
        {
            var zidiniai = zidinysRepository.getZidiniai();
            List<SelectListItem> selectListzidiniai = new List<SelectListItem>();

            foreach (var item in zidiniai)
            {
                selectListzidiniai.Add(new SelectListItem() { Value = Convert.ToString(item.id), Text = item.vardas });
            }

            modelis.ZidiniaiList = selectListzidiniai;
        }
    }
}
