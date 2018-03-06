using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Wordbase.Models;

namespace Wordbase.Tests
{
  [TestClass]
  public class PlayerTest : IDisposable
  {
    public PlayerTest()
    {

      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=wordbase_test;";
    }

    public void Dispose()
    {
      // Player.DeleteGames();
    }

    // [TestMethod]
    // public void GetsAndSets_AllGettersAndSetters_Red()
    // {
    //   //arrange
    //   XXXXXXXXXX newXXXXXXXX = new XXXXXXXXX();
    //   //action
    //   XXXXXXXXXXXXX
    //   //assert
    //   Assert.AreEqual(XXXXX, XXXXX);
    //   Assert.AreEqual(XXXXX, XXXXXX);
    // }

    [TestMethod]
    public void IsWord_TestIfWordMatches_Bool()
    {
      //arrange
      List<List<string>> empty = new List<List<string>>();
       Player newPlayer = new Player("ERROR", empty, 0);
       newPlayer.Save();
      //action
      bool result = newPlayer.IsWord("TEST");

      //assert
      Assert.AreEqual(result, true);
    }

    [TestMethod]
    public void GetCordIndex_ReturnCorrectIndex_Int()
    {
      //arrange
      List<List<string>> empty = new List<List<string>>();
       Player newPlayer = new Player("ERROR", empty, 0);
       newPlayer.Save();
       List<string> newList = new List<string>(){"B1", "B2", "C3", "D3"};
       newPlayer.AddCordsList(newList); //"TAGS"

      //action
      int result = newPlayer.GetCordIndex("B2");

      //assert
      Assert.AreEqual(result, 1);
    }

    [TestMethod]
    public void AddCordsList_UpdatesCordsList_List()
    {
      //arrange
      List<List<string>> empty = new List<List<string>>();
       Player newPlayer = new Player("ERROR", empty, 0);
       newPlayer.Save();
       List<string> newList = new List<string>(){"B1", "B2", "C3", "D3"};
       List<string> newList2 = new List<string>(){"B1", "B3", "C3", "D3"};
      //  Console.WriteLine();

      //action
      newPlayer.AddCordsList(newList); //"TAGS"
      newPlayer.AddCordsList(newList2); //MADE UP WORD

      Console.WriteLine(newPlayer.GetName());
      int result = newPlayer.GetCordIndex("B2");
      List<List<string>> playerList = newPlayer.GetCordsList();

      //assert
      CollectionAssert.AreEqual(playerList[0], newList);
    }


    [TestMethod]
    public void TestCordsList_UpdatesCordsList_List()
    {
      //arrange
      List<List<string>> empty = new List<List<string>>();
       Player newPlayer = new Player("ERROR", empty, 0);
       newPlayer.Save();
       List<string> newList = new List<string>(){"B1", "B2", "C3", "D3"};
       List<string> newList2 = new List<string>(){"B1", "B3", "C3", "D3"};
      //  Console.WriteLine();

      //action
      newPlayer.AddCordsList(newList); //"TAGS"
      newPlayer.AddCordsList(newList2); //MADE UP WORD
      List<List<string>> playerList = newPlayer.GetCordsList();
      List<int> playerCordsList = new List<int>();
      foreach(List<string> cordsList in playerList)
      {
        int index = cordsList.GetCordIndex("C3");
        playerCordsList.Add(index);
      }

      int result = playerCordsList.Count;

      //assert
    Assert.AreEqual(result, 2);
    }

  }


}
