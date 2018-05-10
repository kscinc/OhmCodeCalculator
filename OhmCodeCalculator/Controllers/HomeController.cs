using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OhmCodeCalculator.Models;
using ColorCodeCalculator;

namespace OhmCodeCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BandColors selectOnLoad = new BandColors();
            return View(selectOnLoad);
        }

        [HttpPost]
        public ActionResult getResistanceValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            try
            {


                ColorCodeCalculator.IOhmValueCalculator objResistance = new ResistanceCalculator();                
                ColorCodeResult resultObject = objResistance.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);               
                return Json(new { min = resultObject.MinimumResistance, max = resultObject.MaximumResistance });
            }
            catch (Exception ex)
            {
                 return Json(new { error = "Exception ocurred while calculating resistance value: " + ex.Message });
            }
        }

    }
}