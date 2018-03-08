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
      Player currentPlayer = new Player(newPlayer);
      currentPlayer.Save();
      Player otherPlayer = new Player(oldPlayer);
      otherPlayer.Save();

      string playerOneCell = Request.Form["newp1cells"];
      // string[] newCells1 = playerOneCell.Split(',');

      string playerTwoCell = Request.Form["newp2cells"];
      // string[] newCells2 = playerTwoCell.Split(',');

      string newWord = Request.Form["newword"];
      bool isUsed = false;

      if(currentPlayer.GetName() == "1")
      {
        isUsed = currentPlayer.IsUsed1(currentPlayer, newWord);
        if(isUsed == true)
        {
          model.Add("used", "true");
        }
        else
        {
          model.Add("used", "false");
        }
      }
      else
      {
        isUsed= currentPlayer.IsUsed2(currentPlayer, newWord);
        if(isUsed == true)
        {
          model.Add("used", "true");
        }
        else
        {
          model.Add("used", "false");
        }
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

      if (!isUsed && isWord && currentPlayer.GetName() == "1")
      {

        string[] playedCells = new string[]{};
        if (newPlayer == "1")
        {
          // playedCells = newCells1;
          playedCells = playerOneCell.Split(',');
          currentPlayer.AddCordsList1(playedCells);
          currentPlayer.AddPlayer1PlayedWord(newWord);
          currentPlayer.MasterKiller1(otherPlayer, playedCells);
        }
        else if (newPlayer == "2")
        {
          playedCells = playerTwoCell.Split(',');
          currentPlayer.AddCordsList2(playedCells);
          currentPlayer.AddPlayer2PlayedWord(newWord);
          currentPlayer.MasterKiller2(otherPlayer, playedCells);
        }
        else
        {
          Console.WriteLine("no player");
        }

      }

      // win check
      if(currentPlayer.GetName() == "1")
      {
        bool newWinCheck = currentPlayer.WinCheck1(currentPlayer);
        if (newWinCheck)
        {
          model.Add("winCheck", "true");
        }
        else
        {
          model.Add("winCheck", "false");
        }
      }
      else
      {
        bool newWinCheck = currentPlayer.WinCheck2(currentPlayer);
        if (newWinCheck)
        {
          model.Add("winCheck", "true");
        }
        else
        {
          model.Add("winCheck", "false");
        }
      }
      // generate new array for each player
    if (newPlayer == "1")
      {
        List<string> currentPlayerActiveCells = currentPlayer.GetCordsBundle1(currentPlayer);
        List<string> p1ActiveCells = new List<string>();
        List<string> otherPlayerActiveCells = otherPlayer.GetCordsBundle2(otherPlayer);
        List<string> p2ActiveCells = new List<string>();
        p1ActiveCells = currentPlayerActiveCells;
        p2ActiveCells = otherPlayerActiveCells;
        model.Add("player1cells", p1ActiveCells);
        model.Add("player2cells", p2ActiveCells);
      }
      else if (newPlayer == "2")
      {
        List<string> currentPlayerActiveCells = currentPlayer.GetCordsBundle2(currentPlayer);

        List<string> p1ActiveCells = new List<string>();

        List<string> otherPlayerActiveCells = otherPlayer.GetCordsBundle1(otherPlayer);

        List<string> p2ActiveCells = new List<string>();

        p2ActiveCells = currentPlayerActiveCells;
        p1ActiveCells = otherPlayerActiveCells;
        model.Add("player1cells", p1ActiveCells);
        model.Add("player2cells", p2ActiveCells);
      }
      else
      {
        Console.WriteLine("no player");
      }


      model.Add("playerNum", newPlayer);
      model.Add("word", newWord);
      // model.Add("player1cells", p1ActiveCells);
      // model.Add("player2cells", p2ActiveCells);
      return View("Index", model);
    }


    //     return newWord;
    //   }
    //   else
    //   return RedirectToAction("Index");
    // }

  }
}
