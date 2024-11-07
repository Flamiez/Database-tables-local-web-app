using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuombaziuLenteles.Repos;
using DuombaziuLenteles.ViewModels;

namespace DuombaziuLenteles.Controllers
{
    
    public class AtaskaitaController : Controller
    {
        AtaskaitaRepository ataskaituRepository = new AtaskaitaRepository();

        public ActionResult Index()
        {
            AtaskaiktaViewModel2 ataskaita = new AtaskaiktaViewModel2();
            ataskaita.list = new List<AtaskaiktaViewModel>();
            ataskaita.list = ataskaituRepository.getAtaskaitaSutartciu(0, 100000000);
            ataskaita.visoviso = ataskaita.list[0].visoviso;
            return View(ataskaita);
        }
        [HttpPost]
        public ActionResult Index(AtaskaiktaViewModel2 ataskaita)
        {
            try
            {
                ataskaita.list = ataskaituRepository.getAtaskaitaSutartciu(ataskaita.nuo, ataskaita.iki);
                ataskaita.visoviso = ataskaita.list[0].visoviso;
            }
            catch
            {
                return View(ataskaita);
            }

            return View(ataskaita);
        }


    }
}