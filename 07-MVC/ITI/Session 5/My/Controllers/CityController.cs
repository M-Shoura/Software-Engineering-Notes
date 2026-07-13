using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using My.Models;

namespace My.Controllers
{
    public class CityController : Controller
    {
        CityDbContext context = new();
        // GET: CityController
        public ActionResult Index()
        {
            ViewBag.cntrs = new SelectList(context.Countries.ToList(), "CountryID" , "CountryName");
            return View(context.Cities.Include(x=>x.Cntry).ToList());
        }

        [HttpPost]
        public ActionResult Index(int countryID)
        {
            ViewBag.cntrs = new SelectList(context.Countries.ToList(), "CountryID", "CountryName", countryID);
            return View(context.Cities.Include(x => x.Cntry).Where(x=>x.Cntry.CountryID == countryID).ToList());
        }

        // GET: CityController/Details/5
        public ActionResult Details(int CityID)
        {
            return View(context.Cities.Include(x => x.Cntry).FirstOrDefault(x=>x.CityID == CityID));
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            ViewBag.countries = context.Countries.ToList();
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        public ActionResult Create(City c)
        {
            if (c != null && !context.Cities.Any(x=>x.CityID == c.CityID))
            {
                context.Cities.Add(c);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.countries = context.Countries.ToList();
                return View(c);
            }
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int CityID)
        {
            ViewBag.countries = context.Countries.ToList();
            return View(context.Cities.Include(x => x.Cntry).FirstOrDefault(x => x.CityID == CityID));
        }

        // POST: CityController/Edit/5
        [HttpPost]
        public ActionResult Edit(City cty)
        {
            var ctyWantingToChange = context.Cities.FirstOrDefault(x => x.CityID == cty.CityID);
            if (ctyWantingToChange != null)
            {
                ctyWantingToChange.CityName = cty.CityName;
                ctyWantingToChange.cID = cty.cID;
                ctyWantingToChange.CityName = cty.CityName;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(cty);                  // Good practice , as we send the data to avoid loosing it and re-writing it again 
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int CityID)
        {
            var cty = context.Cities.Include(x=>x.Cntry).FirstOrDefault(x => x.CityID == CityID);
            if(cty != null)
            {
                return View(cty);
            }
            return NotFound();
        }

        // POST: CityController/Delete/5
        [HttpPost]
        public ActionResult Delete(City c)
        {
            var city = context.Cities.FirstOrDefault(x => x.CityID == c.CityID);
            if (city != null)
            {
                context.Cities.Remove(city);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return BadRequest();
        }
    }
}
