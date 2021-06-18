using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public static class Utilities
    {
        public static SelectList LoadUserData()
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                return new SelectList(service.GetUsers(""), "Id", "FirstName", "LastName");
            }
        }

        public static SelectList LoadSongData()
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                return new SelectList(service.GetSongs(""), "Id", "Title", "Author");
            }
        }
    }
}