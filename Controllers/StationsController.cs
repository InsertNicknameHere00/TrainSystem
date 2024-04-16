using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrainSystem.Entities;
using TrainSystem.Extensions;
using TrainSystem.Models;
using TrainSystem.Repositories;
using TrainSystem.ViewModels.DataViews.Stations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TrainSystem.Controllers
{
    public class StationsController : Controller
    {
        public IActionResult Stations(int id)
        {
            StationsRepository stationrepo = new StationsRepository();

            IndexVM model = new IndexVM();
            model.Items = stationrepo.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            StationsRepository stationsrep = new StationsRepository();

            Station newstation = new Station();
            newstation.Location = model.Location;

            stationsrep.Save(newstation);

            return RedirectToAction("Stations", "Stations");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            StationsRepository stationsrep = new StationsRepository();
            Station stationedit = stationsrep.GetById(id);

            if (stationedit == null)
                return RedirectToAction("Stations", "Stations");

            EditVM model = new EditVM();
            model.Id = stationedit.Id;
            model.Location = stationedit.Location;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            StationsRepository stationsrep = new StationsRepository();
            Station stationedit = new Station();

            stationedit.Id = model.Id;
            stationedit.Location = model.Location;

            stationsrep.Save(stationedit);

            return RedirectToAction("Stations", "Stations");
        }
        public IActionResult Delete(int id)
        {
            StationsRepository stationsrep = new StationsRepository();

            Station toDelete = stationsrep.GetById(id);

            if (toDelete != null)
                stationsrep.Delete(toDelete);

            return RedirectToAction("Stations", "Stations");
        }
    }
}
