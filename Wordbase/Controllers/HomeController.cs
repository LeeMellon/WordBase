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

    // [HttpPost("/")]
    // public ActionResult NewWord()
    // {
    //   List<List<string>> empty = new List<List<string>>();
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //
    //   string newPlayer = Request.Form["newplayer"];
    //
    //   Player currentPlayer = new Player(newPlayer, empty, 0);
    //
    //   string playerOneCell = Request.Form["newp1cells"];
    //   string[] newCells1 = playerOneCell.Split(',');
    //   // System.Console.WriteLine("newCells: " + newCells[0]);
    //   // List<string[]> playerOneCells = new List<string[]>() {newCells};
    //   // System.Console.WriteLine("playerOneCells" + playerOneCells);
    //
    //   string playerTwoCell = Request.Form["newp2cells"];
    //   string[] newCells2 = playerTwoCell.Split(',');
    // }
    //
    //
    // [HttpPost("PseudoCode")]
    // public ActionResult PESUDO()
    // {
    //   Player player1 = new Player(name);
    //   Player player2 = new Player(name);
    //   player1.Save();
    //   player2.Save();
    //   string word = word;
    //   bool used = player1.IsUsed(player1, word);
    //   if (used == true)
    //   {
    //     dosomething
    //   }
    //   else
    //   {
    //     bool isWord = player1.IsWord(word)
    //     if(isWord == false)
    //     {
    //       dosomething
    //     }
    //     else
    //     {
    //       player1.AddPlayedWord(word)
    //       player2
    //     }
    //   }
    //
    //   string newWord = Request.Form["newword"];
    //   bool isWord = currentPlayer.IsWord(newWord);
    //   if(isWord == true)
    //   {
    //
    //     model.Add("valid", "true");
    //     System.Console.WriteLine("true word");
    //   }
    //   else
    //   {
    //     model.Add("valid", "false");
    //     System.Console.WriteLine("false word");
    //   }
    //   model.Add("playerNum", newPlayer);
    //   model.Add("word", newWord);
    //   model.Add("player1cells", newCells1);
    //   model.Add("player2cells", newCells2);
    //   return View("Index", model);
    // }
    //
    //
    //     return newWord;
    //   }
    //   else
    //   return RedirectToAction("Index");
    // }

  }
}
