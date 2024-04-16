using Microsoft.AspNetCore.Mvc;
using TrainSystem.Repositories;
using TrainSystem.Entities;
using TrainSystem.ViewModels.DataViews.Newsletter;

namespace TrainSystem.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult News(int id)
        {
            NewsRepository newsrepo = new NewsRepository();

            IndexVM model = new IndexVM();
            model.Items = newsrepo.GetAll();

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

            NewsRepository newsrepo = new NewsRepository();

            News addnews = new News();
            addnews.Title = model.Title;
            addnews.CreationDate = model.CreationDate;
            addnews.Text = model.Text;
            addnews.Author = model.Author;
            addnews.StationId = model.StationId;

            newsrepo.Save(addnews);

            return RedirectToAction("News", "News");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            NewsRepository newsrepo = new NewsRepository();
            News editnews = newsrepo.GetById(id);

            if (editnews == null)
                return RedirectToAction("News", "News");

            EditVM model = new EditVM();
            model.Id = editnews.Id;
            model.Title = editnews.Title;
            model.CreationDate = editnews.CreationDate;
            model.Text = editnews.Text;
            model.Author = editnews.Author;
            model.StationId = editnews.StationId;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            NewsRepository newsrepo = new NewsRepository();
            News editnews = new News();

            editnews.Id = model.Id;
            editnews.Title = model.Title;
            editnews.CreationDate = model.CreationDate;
            editnews.Text = model.Text;
            editnews.Author = model.Author;
            editnews.StationId = model.StationId;

            newsrepo.Save(editnews);

            return RedirectToAction("News", "News");
        }
        public IActionResult Delete(int id)
        {
            NewsRepository newsrepo = new NewsRepository();

            News toDelete = newsrepo.GetById(id);

            if (toDelete != null)
                newsrepo.Delete(toDelete);

            return RedirectToAction("News", "News");
        }
    }
}
