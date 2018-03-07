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
      Dictionary<string, object> model = new Dictionary<string, object>();

      Player currentPlayer = new Player("ERROR", empty, 0);
      // List<string>playerOneCells = Request.Form["p1cells"];
      List<string> playerOneCells = new List<string>{"A1", "A2", "B3", "C4"};
      string newWord = Request.Form["newword"];
      bool isWord = currentPlayer.IsWord(newWord);
      if(isWord == true)
      {
        model.Add("valid", "true");
        System.Console.WriteLine("true word");
        // return View("Index", newWord);
      }
      else
      {
        model.Add("valid", "false");
        System.Console.WriteLine("false word");
        // return View("Index", newWord);
      }
      model.Add("word", newWord);
      model.Add("player1cells", playerOneCells);
      return View("Index", model);
    }

  }
}
