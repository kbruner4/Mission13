using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {

        private iBowlersRepository _repo { get; set; }

        public HomeController(iBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var blah = _repo.Bowlers.ToList();

            return View(blah);
        }

        [HttpGet]
        public IActionResult AddBowler(int id)
        {
            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            _repo.CreateBowler(b);
            return View();
        }

        [HttpGet]
        public IActionResult EditForm(int BowlerID)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == BowlerID);
            return View("EditForm", bowler);
        }

        [HttpPost]
        public IActionResult EditForm(Bowler b)
        {
            _repo.SaveBowler(b);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteBowler(int BowlerID)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == BowlerID);

            return View("Delete", bowler);
        }

        [HttpPost]
        public IActionResult DeleteBowler(Bowler b)
        {
            var bowler = _repo.Bowlers.Single(x => x.BowlerID == b.BowlerID);

            _repo.DeleteBowler(b);

            return RedirectToAction("Index");
        }
   
    }
}
