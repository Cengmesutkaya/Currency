using Currency.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Currency.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            List<DovizModel> CurList = null;

            WebClient client = new WebClient();

            var json = client.DownloadString("https://www.doviz.com/api/v1/currencies/all/latest");

            CurList = JsonConvert.DeserializeObject<List<DovizModel>>(json);

            if (CurList == null)
                return null;

            return View(CurList.Take(3).ToList());


           
        }
    }
}