using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Wordbase.Models
using System;

namespace Wordbase.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
          public ActionResult Index()
          {

            return View();

          }
          [HttpPost("/")]
          public ActionResult Result()
          {

            return View();
          }


    }
}
