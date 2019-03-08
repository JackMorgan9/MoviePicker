using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviePicker.Models.API;
using MoviePicker.Models.IndexModels;

namespace MoviePicker.Controllers
{
    public class ResultController : Controller
    {
        [HttpGet]
        public ActionResult Index(IndexModel parameters)
        {
            try
            {
                List<RootObject> result = DiscoverSearch.Search(parameters);

                return View(result);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public ActionResult Index(IFormCollection form)
        {
            int currentPage;
            int nextPage;

            var model = new IndexModel
            {
                type = Request.Query["type"],
                actor = Request.Query["actor"],
                genre = Request.Query["genre"],
                year = Request.Query["year"],
                sort_by = Request.Query["sort_by"],
            };

            var pageMove = form["pageButton"];

            if (pageMove == "Previous Page")
            {
                currentPage = Convert.ToInt32(Request.Query["page"]);
                nextPage = currentPage - 1;
                model.page = Convert.ToString(nextPage);
            }
            else if (pageMove == "Next Page")
            {
                currentPage = Convert.ToInt32(Request.Query["page"]);
                nextPage = currentPage + 1;
                model.page = Convert.ToString(nextPage);
            }

            return RedirectToAction("Index", "Result", model);
        }
    }
}