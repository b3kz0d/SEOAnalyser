using SEOAnalyser.Models;
using SEOAnalyser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEOAnalyser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new AnalyserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Analyser(AnalyserModel model)
        {
            try
            {
                var analyserService = new AnalyserService(model);
                var models = analyserService.Analysis();
                return Json(models);
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(404);
            }
        }
    }
}