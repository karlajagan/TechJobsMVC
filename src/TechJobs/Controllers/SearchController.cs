using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : TechJobsController
    {

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }
        List<Dictionary<string, string>> jobs;


        public IActionResult Results(string searchType, string searchTerm)
        {
           if (searchType == "all")
            {
                jobs = JobData.FindByValue(searchTerm);

            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.columns = ListController.columnChoices;
            ViewBag.jobs = jobs;
            ViewBag.searchType = searchType;
            ViewBag.title = "Search Results";

            return View("Index");
        }
    }   
}
