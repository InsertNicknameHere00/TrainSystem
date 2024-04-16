using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrainSystem.Entities;
using TrainSystem.Extensions;
using TrainSystem.Models;
using TrainSystem.Repositories;
using TrainSystem.ViewModels.DataViews.Tickets;

namespace TrainSystem.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Tickets(int id)
        {
            TicketsRepository ticketrepo = new TicketsRepository();

            IndexVM model = new IndexVM();
            model.Items = ticketrepo.GetAll();

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

            TicketsRepository ticketrep = new TicketsRepository();

            Ticket newticket = new Ticket();
            newticket.RouteId = model.RouteId;
            newticket.Price = model.Price;
            newticket.UserId = model.UserId;

            ticketrep.Save(newticket);

            return RedirectToAction("Tickets", "Tickets");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TicketsRepository ticketrepo = new TicketsRepository();
            Ticket newticket = ticketrepo.GetById(id);

            if (newticket == null)
                return RedirectToAction("Tickets", "Tickets");

            EditVM model = new EditVM();
            model.Id = newticket.Id;
            model.RouteId = newticket.RouteId;
            model.Price = newticket.Price;
            model.UserId = newticket.UserId;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            TicketsRepository ticketrepo = new TicketsRepository();
            Ticket ticketedit = new Ticket();

            ticketedit.Id = model.Id;
            ticketedit.RouteId = model.RouteId;
            ticketedit.Price = model.Price;
            ticketedit.UserId = model.UserId;

            ticketrepo.Save(ticketedit);

            return RedirectToAction("Tickets", "Tickets");
        }
        public IActionResult Delete(int id)
        {
            TicketsRepository ticketrepo = new TicketsRepository();

            Ticket toDelete = ticketrepo.GetById(id);

            if (toDelete != null)
                ticketrepo.Delete(toDelete);

            return RedirectToAction("Tickets", "Tickets");
        }
    }
}
