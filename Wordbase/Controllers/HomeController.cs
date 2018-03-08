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
      List<string> playedWordsBlank = new List<string>();
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
      Player currentPlayer = new Player(newPlayer,playedWordsBlank, empty, 0);
      currentPlayer.Save();
      Player otherPlayer = new Player(oldPlayer, playedWordsBlank, empty, 0);
      otherPlayer.Save();

      string playerOneCell = Request.Form["newp1cells"];
      // string[] newCells1 = playerOneCell.Split(',');

      string playerTwoCell = Request.Form["newp2cells"];
      // string[] newCells2 = playerTwoCell.Split(',');

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
        currentPlayer.AddPlayedWord(newWord);

        // master killer
        // string[] playedCells = "";
        // string playedCells = "";

        string[] playedCells = new string[]{};
        if (newPlayer == "1")
        {
          // playedCells = newCells1;
          playedCells = playerOneCell.Split(',');
          currentPlayer.AddCordsList(playedCells);
          List<List<string>> test1 = currentPlayer.GetCordsList();
          Console.WriteLine("test1" + test1[0][1]);
        }
        else if (newPlayer == "2")
        {
          playedCells = playerTwoCell.Split(',');
          currentPlayer.AddCordsList(playedCells);
          List<List<string>> test2 = currentPlayer.GetCordsList();
          Console.WriteLine("test2" + test2[0][1]);
        }
        else
        {
          Console.WriteLine("no player");
        }
        currentPlayer.MasterKiller(otherPlayer, playedCells);

      }

      // win check
      bool newWinCheck = currentPlayer.WinCheck(currentPlayer);
      if (newWinCheck)
      {
        model.Add("winCheck", "true");
      }
      else
      {
        model.Add("winCheck", "false");
      }

      // generate new array for each player

      List<string> currentPlayerActiveCells = currentPlayer.GetCordsBundle(currentPlayer);
      List<string> otherPlayerActiveCells = otherPlayer.GetCordsBundle(otherPlayer);
      List<string> p1ActiveCells = new List<string>();
      List<string> p2ActiveCells = new List<string>();

      if (newPlayer == "1")
      {
        p1ActiveCells = currentPlayerActiveCells;
        p2ActiveCells = otherPlayerActiveCells;
        Console.WriteLine("p1 "+ p1ActiveCells[8]);
        Console.WriteLine("cpa1 "+currentPlayerActiveCells[8]);
      }
      else if (newPlayer == "2")
      {
        p2ActiveCells = currentPlayerActiveCells;
        p1ActiveCells = otherPlayerActiveCells;
      }
      else
      {
        Console.WriteLine("no player");
      }


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
