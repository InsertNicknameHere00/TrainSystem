using Microsoft.AspNetCore.Mvc;
using TrainSystem.Entities;
using TrainSystem.Repositories;
using TrainSystem.ViewModels.DataViews.Trips;

namespace TrainSystem.Controllers
{
    public class TripsController: Controller
    {
        public IActionResult Trips(int id)
        {
            TripsRepository triprepo = new TripsRepository();

            IndexVM model = new IndexVM();
            model.Items = triprepo.GetAll();

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

            TripsRepository triprepo = new TripsRepository();

            Trip newtrip = new Trip();
            newtrip.TrainId = model.TrainId;
            newtrip.StartPoint = model.StartPoint;
            newtrip.EndPoint = model.EndPoint;
            newtrip.DepartureTime = model.DepartureTime;
            newtrip.ArrivalTime = model.ArrivalTime;

            triprepo.Save(newtrip);

            return RedirectToAction("Trips", "Trips");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TripsRepository triprep= new TripsRepository();
            Trip tripedit = triprep.GetById(id);

            if (tripedit == null)
                return RedirectToAction("Trips", "Trips");

            EditVM model = new EditVM();
            model.Id = tripedit.Id;
            model.TrainId = tripedit.TrainId;
            model.StartPoint = tripedit.StartPoint;
            model.EndPoint = tripedit.EndPoint;
            model.DepartureTime = tripedit.DepartureTime;
            model.ArrivalTime = tripedit.ArrivalTime;

            return View(model);

        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            TripsRepository triprep = new TripsRepository();
            Trip tripedit = new Trip();

            tripedit.Id = model.Id;
            tripedit.TrainId = model.TrainId;
            tripedit.StartPoint = model.StartPoint;
            tripedit.EndPoint = model.EndPoint;
            tripedit.DepartureTime = model.DepartureTime;
            tripedit.ArrivalTime = model.ArrivalTime;

            triprep.Save(tripedit);

            return RedirectToAction("Trips", "Trips");
        }

        public IActionResult Delete(int id)
        {
            TripsRepository triprepo = new TripsRepository();

            Trip toDelete = triprepo.GetById(id);

            if (toDelete != null)
                triprepo.Delete(toDelete);

            return RedirectToAction("Trips", "Trips");
        }
    }
}
