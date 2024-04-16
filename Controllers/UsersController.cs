using Microsoft.AspNetCore.Mvc;
using TrainSystem.Entities;
using System.Diagnostics;
using TrainSystem.Extensions;
using TrainSystem.Models;
using TrainSystem.Repositories;
using TrainSystem.ViewModels.Users;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace TrainSystem.Controllers
{
    public class UsersController: Controller
    {
        public IActionResult User(int id)
        {
            UsersRepository userrepo = new UsersRepository();

            IndexVM model = new IndexVM();
            model.Items = userrepo.GetAll();

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
            UsersRepository userrepo = new UsersRepository();

            User addnew = new User();
            addnew.Username = model.Username;
            addnew.Password = model.Password;
            addnew.Firstname = model.Firstname;
            addnew.Lastname = model.Lastname;
            addnew.Email = model.Email;

            userrepo.Save(addnew);

            return RedirectToAction("User", "Users");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            UsersRepository userrepo = new UsersRepository();
            User toEdit = userrepo.GetById(id);

            if (toEdit == null)
                return RedirectToAction("User", "Users");

            EditVM model = new EditVM();
            model.Id = toEdit.Id;
            model.Username = toEdit.Username;
            model.Password = toEdit.Password;
            model.Firstname = toEdit.Firstname;
            model.Lastname = toEdit.Lastname;
            model.Email = toEdit.Email;

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            UsersRepository usersrepo = new UsersRepository();
            User edituser = new User();

            edituser.Id = model.Id;
            edituser.Username = model.Username;
            edituser.Password = model.Password;
            edituser.Firstname = model.Firstname;
            edituser.Lastname = model.Lastname;
            edituser.Email = model.Email;

            usersrepo.Save(edituser);

            return RedirectToAction("User", "Users");
        }

        public IActionResult Delete(int id)
        {
            UsersRepository repo = new UsersRepository();

            User toDelete = repo.GetById(id);

            if (toDelete != null)
                repo.Delete(toDelete);

            return RedirectToAction("User", "Users");
        }
    }
}
