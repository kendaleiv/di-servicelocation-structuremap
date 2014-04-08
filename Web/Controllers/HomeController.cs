using Core;
using StructureMap;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.ServiceId = _service.Id;
            ViewBag.WhatDoIHave = ObjectFactory.Container.WhatDoIHave();

            return View();
        }
    }
}
