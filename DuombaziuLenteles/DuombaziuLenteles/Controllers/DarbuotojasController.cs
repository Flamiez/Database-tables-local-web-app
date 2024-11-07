using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuombaziuLenteles.Repos;
using DuombaziuLenteles.ViewModels;

namespace AutoNuoma.Controllers
{
    public class DarbuotojasController : Controller
    {
        //apibreziamos saugyklos kurios naudojamos siame valdiklyje
        DarbuotojasRepository darbuotojuRepository = new DarbuotojasRepository();
        zidinysRepository zidinysRepository = new zidinysRepository();
        // GET: Modelis
        public ActionResult Index()
        {
            return View(darbuotojuRepository.getDarbuotojai());
        }

        // GET: Modelis/Create
        public ActionResult Create()
        {
            DarbuotojasEditViewModel draudimas = new DarbuotojasEditViewModel();
            PopulateSelections(draudimas);
            return View(draudimas);
        }

        // POST: Modelis/Create
        [HttpPost]
        public ActionResult Create(DarbuotojasEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    darbuotojuRepository.addDarbuotojas(collection);
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
            DarbuotojasEditViewModel modelis = darbuotojuRepository.getDarbuotojas(id);
            PopulateSelections(modelis);
            return View(modelis);
        }

        // POST: Modelis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DarbuotojasEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    darbuotojuRepository.updateDarbuotojas(collection);
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
            DarbuotojasEditViewModel modelis = darbuotojuRepository.getDarbuotojas(id);
            return View(modelis);
        }

        // POST: Modelis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                darbuotojuRepository.deleteDarbuotojas(id);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(DarbuotojasEditViewModel modelis)
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
