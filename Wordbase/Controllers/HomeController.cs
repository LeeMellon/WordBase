using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Wordbase.Models;
using System;
using System.Linq;

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

      string newPlayer = Request.Form["newplayer"];

      Player currentPlayer = new Player(newPlayer, empty, 0);

      string playerOneCell = Request.Form["newp1cells"];
      string[] newCells1 = playerOneCell.Split(',');
      // System.Console.WriteLine("newCells: " + newCells[0]);
      // List<string[]> playerOneCells = new List<string[]>() {newCells};
      // System.Console.WriteLine("playerOneCells" + playerOneCells);

      string playerTwoCell = Request.Form["newp2cells"];
      string[] newCells2 = playerTwoCell.Split(',');

      string newWord = Request.Form["newword"];
      bool isWord = currentPlayer.IsWord(newWord);
      if(isWord == true)
      {
        model.Add("valid", "true");
        System.Console.WriteLine("true word");
      }
      else
      {
        model.Add("valid", "false");
        System.Console.WriteLine("false word");
      }
      model.Add("playerNum", newPlayer);
      model.Add("word", newWord);
      model.Add("player1cells", newCells1);
      model.Add("player2cells", newCells2);
      return View("Index", model);
    }

  }
}
