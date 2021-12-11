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
            ViewBag.AllTeamsWithCity = _context.Teams
            .Where(twc => twc.Location.Contains("City"))
            .ToList();


            //------------All Teams Whose Names Begin With "T"----------------
            ViewBag.TeamsStartingWith_T = _context.Teams
            .Where(tsw_T => tsw_T.TeamName.Contains("T"))
            .ToList();


            //------------All Teams, Ordered Alphabetically by Location----------------
            ViewBag.TeamsByLocationAlphaOrder = _context.Teams
            .OrderBy(tbyl_AO => tbyl_AO.Location)
            .ToList();


            //------All Teams, Ordered by Team Name in Reverse Alphabetical Order------
            ViewBag.TeamsByNameReverseAlphaOrder = _context.Teams
            .OrderByDescending(tbyn_RA => tbyn_RA.TeamName)
            .ToList();


            //---------------Every Player With Last Name "Cooper"---------------
            ViewBag.PlayersWithLastNameCooper = _context.Players
            .Where(pwc => pwc.LastName.Contains("Cooper"))
            .ToList();


            //---------------Every Player With Last Name "Cooper"-----------------
            ViewBag.PlayersWithFirstNameJoshua = _context.Players
            .Where(pwj => pwj.FirstName.Contains("Joshua"))
            .ToList();


            //--------Every Player with Last Name "Cooper" EXCEPT those with "Joshua" as the First Name-------
            ViewBag.PlayersLnCooper_NotFnJoshua = _context.Players
            .Where(pwc_woj => pwc_woj.FirstName !="Joshua")
            .Where(pwc_woj => pwc_woj.LastName.Contains("Cooper"))
            .ToList();


            //-------All Players with First Name "Alexander" OR First Name "Wyatt"-----
            ViewBag.PlayersFirstNameAlexanderOrWhyatt = _context.Players
            .Where(paow => paow.FirstName == "Alexander" || paow.FirstName == "Wyatt")
            .OrderBy(paow => paow.FirstName)
            .ToList();


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