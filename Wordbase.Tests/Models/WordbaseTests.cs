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
      Player.DeleteGames();
    }


    [TestMethod]
    public void IsWord_TestIfWordMatches_Bool()
    {
      //arrange
      List<List<string>> empty = new List<List<string>>();
       Player newPlayer = new Player("ERROR", empty, 0);
       newPlayer.Save();
      //action
      bool result = newPlayer.IsWord("TEST");
      List<string> playedWords = newPlayer.GetPlayedWords();
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
      int result = newPlayer.GetCordIndex(newList, "B2");

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
      newPlayer.AddCordsList(newList);
      newPlayer.AddCordsList(newList2);
      List<List<string>> playerList = newPlayer.GetCordsList();
      List<int> playerCordsList = new List<int>();
      foreach(List<string> cordsList in playerList)
      {
        int index = newPlayer.GetCordIndex(newList, "C3");
        playerCordsList.Add(index);
      }

      int result = playerCordsList.Count;

      //assert
    Assert.AreEqual(result, 2);
    }

    [TestMethod]
    public void DeleteAfterId_DeletesCordsAtIdAndAfter_List()
    {
      //arrange
      List<List<string>> empty = new List<List<string>>();

      Player newPlayer = new Player("ERROR", empty, 0);
      newPlayer.Save();
      List<string> newList = new List<string>(){"B1", "B2", "C3", "D3"};
      empty.Add(newList);

       //act
       List<string> popList = newPlayer.DeleteAfterId(0, 1);

       //assert
       Assert.AreEqual("C3", popList[0]);
       Assert.AreEqual(1, newList.Count);
    }

    [TestMethod]
    public void MasterKillerAll_DeletesCordinMultipleLists_List()
    {
      //arrage
      List<List<string>> empty = new List<List<string>>();
      Player newPlayer = new Player("ERROR", empty, 0);
      newPlayer.Save();
      List<string> newList = new List<string>(){"B1", "B2", "C3", "D3"};
      newPlayer.AddCordsList(newList);
      List<string> newList2 = new List<string>(){"A1", "B2", "C2", "C3"};
      newPlayer.AddCordsList(newList2);
      List<string> newList3 = new List<string>(){"D1", "C2", "D3", "D4"};
      newPlayer.AddCordsList(newList3);
      List<string> newList4 = new List<string>(){"C2", "B3", "B4", "B5", "A6", "A7" };
      newPlayer.AddCordsList(newList4);

      //act
      newPlayer.MasterKiller(newPlayer, "B3,B2,C2" );
      List<List<string>> cordList = newPlayer.GetCordsList();
      List<string> practice = newPlayer.MasterCordsList(newPlayer);

      //assert
      Assert.AreEqual(3, practice.Count);
      Assert.AreEqual(cordList[0].Count, 1);
      Assert.AreEqual(cordList[1].Count, 1);
      Assert.AreEqual(cordList[2].Count, 1);
      Assert.AreEqual(cordList[3].Count, 0);
    }

    [TestMethod]
    public void winCheck_IsWinIsTrue_True()
    {
      //arrange
      List<List<string>> empty = new List<List<string>>();
      Player player1 = new Player("One", empty, 0);
      player1.Save();
      Player player2 = new Player("Two", empty, 0);
      List<string> player1cords = new List<string>(){"B13", "B12", "C11", "D11"};
      player1.AddCordsList(player1cords);

      //Act
      Console.WriteLine("player1 Id " + player1.GetId());

      bool winState = player1.winCheck(player1);

      //Assert
      Assert.AreEqual(winState, true);
    }



    [TestMethod]
    public void GetCordsBundle_ReturnsCorrectList_List()
    {
      //arrange
      List<List<string>> empty = new List<List<string>>();
      Player player1 = new Player("One", empty, 0);
      List<string> player1cords = new List<string>(){"B13", "B12", "C11", "D11"};
      player1.AddCordsList(player1cords);

      //Act
      List<string> bundle = player1.GetCordsBundle(player1);

      //Assert
      Assert.AreEqual(bundle[0], "B13");
    }

  }


}
