using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Wordbase.Models;

namespace Wordbase.Tests
{
  [TestClass]
  public class TurnTest : IDisposable
  {
    public TurnTest()
    {

      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=wordbase_test;";
    }

    public void Dispose()
    {
      // Turn.DeleteGames();
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
       Turn newTurn = new Turn("3", "ERROR");
       newTurn.Save();
      //action
      bool result = newTurn.IsWord(newTurn.GetWord());

      //assert
      Assert.AreEqual(result, true);
    }

    public void
  }
}
