using ApplicationService.DTOs;
using Data.Entities;
using MVC.Helpers;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index(string Search_Data = "")
        {
            List<RatingVM> ratingVM = new List<RatingVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetRatings(Search_Data))
                {
                    ratingVM.Add(new RatingVM(item));
                }
            }
            return View(ratingVM);
        }

        public ActionResult Create()
        {
            ViewBag.Songs = Utilities.LoadSongData();
            ViewBag.Users = Utilities.LoadUserData();            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingVM ratingVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        RatingDTO ratingDTO = new RatingDTO
                        {
                            Id = ratingVM.Id,
                            Rate = ratingVM.Rate,
                            Review = ratingVM.Review,

                            User = new User
                            {
                                Id = ratingVM.UserID
                            },

                            Song = new Song
                            {
                                Id = ratingVM.SongID
                            }
                        };

                        service.PostRating(ratingDTO);

                        return RedirectToAction("Index");
                    }
                }                
                ViewBag.Songs = Utilities.LoadSongData();
                ViewBag.Users = Utilities.LoadUserData();
                return View();
            }
            catch
            {                
                ViewBag.Songs = Utilities.LoadSongData();
                ViewBag.Users = Utilities.LoadUserData();
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            RatingVM ratingVM = new RatingVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                RatingDTO ratingDto = service.GetRatingsById(id);
                ratingVM = new RatingVM(ratingDto);
            }
            return View(ratingVM);
        }

        public ActionResult Edit(int id)
        {
            RatingVM ratingVM = new RatingVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var ratingDto = service.GetRatingsById(id);
                ratingVM = new RatingVM(ratingDto);
            }            
            ViewBag.Users = Utilities.LoadUserData();
            ViewBag.Songs = Utilities.LoadSongData();

            return View(ratingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RatingVM ratingVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        RatingDTO ratingDto = new RatingDTO
                        {
                            Id = ratingVM.Id,
                            Rate = ratingVM.Rate,
                            Review = ratingVM.Review,
                            User = new User
                            {
                                Id = ratingVM.UserID
                            },

                            Song = new Song
                            {
                                Id = ratingVM.SongID
                            }
                        };
                        service.PostRating(ratingDto);
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.Songs = Utilities.LoadSongData();
                ViewBag.Users = Utilities.LoadUserData();
                return View();
            }
            catch
            {
                ViewBag.Songs = Utilities.LoadSongData();
                ViewBag.Users = Utilities.LoadUserData();
                return View();
            }
        } 

        public ActionResult Delete (int id)
        {
            RatingVM ratingVM = new RatingVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                RatingDTO ratingDto = service.GetRatingsById(id);
                ratingVM = new RatingVM(ratingDto);
            }
            return View(ratingVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteRating(id);
            }
            return RedirectToAction("Index");
        }
    }
}