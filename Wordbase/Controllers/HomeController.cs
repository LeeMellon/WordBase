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
    [HttpPost("/")]
    public ActionResult NewWord()
    {
      List<List<string>> empty = new List<List<string>>();
      Player currentPlayer = new Player("ERROR", empty, 0);
      string newWord = Request.Form["newword"];
      bool isWord = currentPlayer.IsWord(newWord);
      string test = "test";
      if(isWord == true)
      {
        System.Console.WriteLine("true word");
        return View("Index", newWord);
      }
      else
      System.Console.WriteLine("false word");
      return View("Index", newWord);
    }
  }
}
