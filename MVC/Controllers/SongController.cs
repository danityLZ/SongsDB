using ApplicationService.DTOs;
using MVC.Helpers;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index(string Search_Data = "")
        {
            List<SongVM> songsVM = new List<SongVM>();

            using(SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetSongs(Search_Data))
                {
                    songsVM.Add(new SongVM(item));
                }
            }
            return View(songsVM);
        }

        public ActionResult Details(int id)
        {
            SongVM songVM = new SongVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var songDto = service.GetSongById(id);
                songVM = new SongVM(songDto);
            }
            return View(songVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SongVM songVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        SongDTO songDTO = new SongDTO
                        {
                            Title = songVM.Title,
                            Author = songVM.Author,
                            YearReleased = songVM.YearReleased,
                            Lenght = songVM.Lenght
                        };
                        service.PostSong(songDTO);

                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Songs = Utilities.LoadSongData();
                return View();
            }
            catch
            {
                ViewBag.Songs = Utilities.LoadSongData();
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            SongVM songVM = new SongVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var songDto = service.GetSongById(id);
                songVM = new SongVM(songDto);
            }

            return View(songVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SongVM songVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        SongDTO songDto = new SongDTO
                        {
                            Id = songVM.Id,
                            Title = songVM.Title,
                            Author = songVM.Author,
                            YearReleased = songVM.YearReleased,
                            Lenght = songVM.Lenght
                        };
                        service.PostSong(songDto);
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

        public ActionResult Delete(int id)
        {
            SongVM songVM = new SongVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                SongDTO songDto = service.GetSongById(id);
                songVM = new SongVM(songDto);
            }
            return View(songVM);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteSong(id);
            }
            return RedirectToAction("Index");
        }

    }
}