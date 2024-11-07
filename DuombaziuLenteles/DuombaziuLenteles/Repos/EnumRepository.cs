using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuombaziuLenteles.Repos
{
    public class EnumRepository
    {

        string[] material = { "plienas","medis","cementas","akmuo","plytos","plytelės" };

        public List<SelectListItem> materials = new List<SelectListItem>();

        public EnumRepository()
        {
            foreach (string item in material)
                materials.Add(new SelectListItem { Value = item, Text = item });
        }

    }
}