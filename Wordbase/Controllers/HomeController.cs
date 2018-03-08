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
      string oldPlayer = "";
      if (newPlayer == "1")
      {
        oldPlayer = "2";
      }
      else if (newPlayer == "2")
      {
        oldPlayer = "1";
      }
      else
      {
        Console.WriteLine("no player");
      }
      Player currentPlayer = new Player(newPlayer, empty, 0);
      Player otherPlayer = new Player(oldPlayer, empty, 0);

      string playerOneCell = Request.Form["newp1cells"];
      string[] newCells1 = playerOneCell.Split(',');


      // System.Console.WriteLine("newCells: " + newCells[0]);
      // List<string[]> playerOneCells = new List<string[]>() {newCells};
      // System.Console.WriteLine("playerOneCells" + playerOneCells);

      string playerTwoCell = Request.Form["newp2cells"];
      string[] newCells2 = playerTwoCell.Split(',');


      string newWord = Request.Form["newword"];
      bool isUsed = currentPlayer.IsUsed(currentPlayer, newWord);
      if(isUsed == true)
      {
        model.Add("used", "true");
      }
      else
      {
        model.Add("used", "false");
      }

      bool isWord = currentPlayer.IsWord(newWord);
      if(isWord == true)
      {
        model.Add("valid", "true");
      }
      else
      {
        model.Add("valid", "false");
      }

      if (!isUsed && isWord)
      {
        // save to players list
        currentPlayer.AddPlayedWord(newWord);

        // master killer
        // string[] playedCells = "";
        // string playedCells = "";

        string[] playedCells = new string[]{};
        if (newPlayer == "1")
        {
          // playedCells = newCells1;
          playedCells = playerOneCell.Split(',');
        }
        else if (newPlayer == "2")
        {
          playedCells = playerTwoCell.Split(',');
        }
        else
        {
          Console.WriteLine("no player");
        }
        currentPlayer.MasterKiller(otherPlayer, playedCells);

      }

      // win check
      bool newWinCheck = currentPlayer.WinCheck(currentPlayer);

      // generate new array for each player

      List<string> currentPlayerActiveCells = currentPlayer.MasterCordsList(currentPlayer);
      List<string> otherPlayerActiveCells = otherPlayer.MasterCordsList(otherPlayer);
      List<string> p1ActiveCells = new List<string>();
      List<string> p2ActiveCells = new List<string>();

      if (newPlayer == "1")
      {
        p1ActiveCells = currentPlayerActiveCells;
      }
      else if (newPlayer == "2")
      {
        p2ActiveCells = currentPlayerActiveCells;
      }
      else
      {
        Console.WriteLine("no player");
      }

      if (newPlayer == "2")
      {
        p2ActiveCells = otherPlayerActiveCells;
      }
      else if (newPlayer == "1")
      {
        p1ActiveCells = otherPlayerActiveCells;
      }
      else
      {
        Console.WriteLine("no player");
      }

      model.Add("winCheck", newWinCheck);
      model.Add("playerNum", newPlayer);
      model.Add("word", newWord);
      // rename these to return the new values
      model.Add("player1cells", p1ActiveCells);
      model.Add("player2cells", p2ActiveCells);
      return View("Index", model);
    }


    //     return newWord;
    //   }
    //   else
    //   return RedirectToAction("Index");
    // }

  }
}
