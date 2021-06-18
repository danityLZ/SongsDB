using ApplicationService.DTOs;
using Data.Entities;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: Users
        public ActionResult Index(string Search_Data = "")
        {
            List<UserVM> usersVM = new List<UserVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetUsers(Search_Data))
                {
                    usersVM.Add(new UserVM(item));
                }
            }
            return View(usersVM);
        }

        public ActionResult Details(int id)
        {
            UserVM userVM = new UserVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var userDto = service.GetUsersById(id);
                userVM = new UserVM(userDto);
            }
            return View(userVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserVM userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        UserDTO userDTO = new UserDTO
                        {
                            Id = userVM.Id,
                            FirstName = userVM.FirstName,
                            LastName = userVM.LastName,
                            Age = userVM.Age,
                            DateOfBirth = userVM.DateOfBirth
                        };

                        service.PostUser(userDTO);

                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            UserVM userVM = new UserVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var userDto = service.GetUsersById(id);
                userVM = new UserVM(userDto);
            }
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserVM userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        UserDTO userDto = new UserDTO
                        {
                            Id = userVM.Id,
                            FirstName = userVM.FirstName,
                            LastName = userVM.LastName,
                            Age = userVM.Age,
                            DateOfBirth = userVM.DateOfBirth
                        };

                        service.PostUser(userDto);
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Delete (int id)
        {
            UserVM userVM = new UserVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                UserDTO userDto = service.GetUsersById(id);

                userVM = new UserVM(userDto);
            }
            return View(userVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteUser(id);
            }
            return RedirectToAction("Index");
        }
    }
}