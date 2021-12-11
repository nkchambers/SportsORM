using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            //---------------------All Womens' Leagues---------------------
            ViewBag.WomensLeagues = _context.Leagues
            .Where(wl => wl.Name.Contains("Womens'"))
            .ToList();


            //----------All Leagues Where Sport is Any Type of Hockey-----------
            ViewBag.HockeyLeagues = _context.Leagues
            .Where(hl => hl.Sport.Contains("Hockey"))
            .ToList();


            //-------All Leagues Where Sport is Something OTHER THAN Football------
            ViewBag.NonFootballLeagues = _context.Leagues
            .Where(nonfl => nonfl.Sport!="Football")
            .ToList();


            //---------All Leagues That Call Themselves "Conferences"-----------
            ViewBag.ConferenceLeagues = _context.Leagues
            .Where(cl => cl.Name.Contains("Conference"))
            .ToList();


            //---------------All Leagues in the Atlantic Region----------------
            ViewBag.AtlanticRegionLeagues = _context.Leagues
            .Where(arl => arl.Name.Contains("Atlantic"))
            .ToList();
            

            //-----------------All Teams Based in Dallas---------------------
            ViewBag.TeamsInDallas = _context.Teams
            .Where(dt => dt.Location == "Dallas")
            .ToList();


            //-----------------All Teams Named the Raptors---------------------
            ViewBag.TeamsNamedRaptors = _context.Teams
            .Where(rt => rt.TeamName.Contains("Raptors"))
            .ToList();


            //------------All Teams Whose Location Includes "City"----------------
            //ViewBag.AllTeamsWithCity = _context.Teams
            //.Where(twc => twc.TeamName.Length > 1)
            //.Select(twc => twc.TeamName)
            //.ToList();

            return View("Level1");
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}