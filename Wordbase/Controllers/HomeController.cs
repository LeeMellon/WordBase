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
    [HttpPost("PseudoCode")]
    public ActionResult PESUDO()
    {
      Player player1 = new Player(name);
      Player player2 = new Player(name);
      player1.Save();
      player2.Save();
      string word = word;
      bool used = player1.IsUsed(player1, word)
      if (used == true)
      {
        dosomething
      }
      else
      {
        bool isWord = player1.IsWord(word)
        if(isWord == false)
        {
          dosomething
        }
        else
        {
          player1.AddPlayedWord(word)
          player2
        }
      }
      string newWord = Request.Form["newword"];
      bool isWord = currentPlayer.IsWord(newWord);
      if(isWord == true)
      {
        return newWord;
      }
      else
      return RedirectToAction("Index");
    }
  }
}
