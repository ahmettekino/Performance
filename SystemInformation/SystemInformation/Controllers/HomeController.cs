using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemInformation.Models;
using System.Management;   //This namespace is used to work with WMI classes. For using this namespace add reference of System.Management.dll .


namespace SystemInformation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SystemInformation()
        {
            return Json(new Informations().getOperatingSystemInfo());
        }
    }
}