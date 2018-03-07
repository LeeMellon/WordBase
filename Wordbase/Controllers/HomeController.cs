using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Wordbase.Models;
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
    // [HttpPost("/")]
    // public ActionResult NewWord()
    // {
    //   Player currentPlayer = new Player();
    //   string newWord = Request.Form["newword"];
    //   bool isWord = currentPlayer.IsWord(newWord);
    //   if(isWord == true)
    //   {
    //     return newWord;
    //   }
    //   else
    //   return RedirectToAction("Index");
    // }
  }
}
