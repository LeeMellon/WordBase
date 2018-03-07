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
      newPlayer.AddCordsList(newList); //"TAGS"
      newPlayer.AddCordsList(newList2); //MADE UP WORD
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

    // [TestMethod]
    // public void MasterKiller_DeletesCordinMultipleLists_List()
    // {
    //   //arrage
    //   List<List<string>> empty = new List<List<string>>();
    //   Player newPlayer = new Player("ERROR", empty, 0);
    //   newPlayer.Save();
    //   List<string> newList = new List<string>(){"B1", "B2", "C3", "D3"};
    //   empty.Add(newList);
    //   List<string> newList2 = new List<string>(){"A1", "B2", "C2", "C3"};
    //   empty.Add(newList2);
    //   List<string> newList3 = new List<string>(){"B2", "B3", "C2", "C3"};
    //   empty.Add(newList3);
    //
    //   //act
    //   List<string> result = newPlayer.MasterKiller(newPlayer, "B2");
    //   // Console.WriteLine(result[0]);
    //
    //   //assert
    //   Assert.AreEqual(7, result.Count);
    // }

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
      List<string> newList3 = new List<string>(){"D2", "D3", "C4", "C5"};
      newPlayer.AddCordsList(newList3);
      List<string> newList4 = new List<string>(){"C2", "B3", "B4", "B5", "A6", "A7" };
      newPlayer.AddCordsList(newList4);

      //act
      List<string> result = newPlayer.MasterKiller(newPlayer, "B2");
      List<List<string>> cordList = newPlayer.GetCordsList();
      
      //  foreach(List<string> cord in cordList)
      // {
      //   foreach (string letter in cord)
      //   {
      //       count ++;
      //   }
      // }
      // Console.WriteLine(result[0]);

      //assert
      // Assert.AreEqual(3, count);
      // Assert.AreEqual(cordList[0].Count, 1);
      // Assert.AreEqual(cordList[1].Count, 1);
      // Assert.AreEqual(cordList[2].Count, 1);
      Assert.AreEqual(cordList[3].Count, 0);


    }
  }


}
