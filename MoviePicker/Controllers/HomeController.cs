using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using MoviePicker.Models.IndexModels;

namespace MoviePicker.Controllers
{

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(string type, string actor, string genre, string year, string sort_by)
        {
            return RedirectToAction("Index", "Result", new IndexModel {type = type, actor = actor, genre = genre, year = year, sort_by = sort_by, page = "1"} );
        }
    }
}