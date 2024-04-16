using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrainSystem.Extensions;
using TrainSystem.Models;
using TrainSystem.Repositories;
using TrainSystem.Entities;
using TrainSystem.ViewModels.DataViews.Trains;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace TrainSystem.Controllers
{
    public class TrainsController : Controller
    {
        public IActionResult Trains(int id)
        {
            TrainsRepository trainrepo = new TrainsRepository();

            IndexVM model = new IndexVM();
            model.Items = trainrepo.GetAll();

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

            TrainsRepository trainrep = new TrainsRepository();

            Train newtrain = new Train();
            newtrain.TrainNum = model.TrainNum;
            newtrain.TrainType = model.TrainType;
            newtrain.Capacity = model.Capacity;

            trainrep.Save(newtrain);

            return RedirectToAction("Trains", "Trains");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TrainsRepository trainsrepo = new TrainsRepository();
            Train trainedit = trainsrepo.GetById(id);

            if (trainedit == null)
                return RedirectToAction("Trains", "Trains");

            EditVM model = new EditVM();
            model.Id = trainedit.Id;
            model.TrainNum = trainedit.TrainNum;
            model.TrainType = trainedit.TrainType;
            model.Capacity = trainedit.Capacity;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            TrainsRepository trainrepo = new TrainsRepository();
            Train trainedit = new Train();

            trainedit.Id = model.Id;
            trainedit.TrainNum = model.TrainNum;
            trainedit.TrainType = model.TrainType;
            trainedit.Capacity = model.Capacity;

            trainrepo.Save(trainedit);

            return RedirectToAction("Trains", "Trains");
        }

        public IActionResult Delete(int id)
        {
            TrainsRepository trainrepo = new TrainsRepository();

            Train toDelete = trainrepo.GetById(id);

            if (toDelete != null)
                trainrepo.Delete(toDelete);

            return RedirectToAction("Trains", "Trains");
        }
    }
}
