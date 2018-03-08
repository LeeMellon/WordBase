using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using Wordbase;
using System.Linq;

namespace Wordbase.Models
{
    public class Player
    {
      private int _id;
      private string _name;
      // private string _word;
      private List<string> _player1Base;
      private List<string> _player2Base;
      private static List<string> _player1PlayedWords = new List<string>{};
      private static List<string> _player2PlayedWords = new List<string>{};
      private static List<List<string>> _player1CordsList = new List<List<string>>{};
      private static List<List<string>> _player2CordsList = new List<List<string>>{};


      public Player(string name, int id =0)
      {
        _id = id;
        _name = name;
        _player1Base = new List<string>(){"A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "I13", "J1"};
        _player2Base = new List<string>(){"A13", "B13", "C13", "D13", "E13", "F13", "G13", "H13", "I13", "J13"};
      }

      public void SetId(int newId)
      {
        _id = newId;
      }

      public int GetId()
      {
        return _id;
      }

      public List<string> GetBase1()
      {
        return _player1Base;
      }

      public List<string> GetBase2()
      {
        return _player2Base;
      }

      public void SetName(string name)
      {
        _name = name;
      }

      public string GetName()
      {
        return _name;
      }

      public List<string> GetCordsBundle1(Player currentPlayer)
      {
        int id = currentPlayer.GetId();
        List<string> baseCords = new List<string>();
        List<string> bundle = currentPlayer.MasterCordsList1(currentPlayer);
        if(currentPlayer.GetName() == "1")
        {
          baseCords = currentPlayer.GetBase1();
        }
        else
        {
          baseCords = currentPlayer.GetBase2();
        }
        bundle.AddRange(baseCords);
        return bundle;
      }

      public List<string> GetCordsBundle2(Player currentPlayer)
      {
        int id = currentPlayer.GetId();
        List<string> baseCords = new List<string>();
        List<string> bundle = currentPlayer.MasterCordsList2(currentPlayer);
        if(currentPlayer.GetName() == "1")
        {
          baseCords = currentPlayer.GetBase1();
        }
        else
        {
          baseCords = currentPlayer.GetBase2();
        }
        bundle.AddRange(baseCords);
        return bundle;
      }

      public List<string> GetPlayer1PlayedWords()
      {
        return _player1PlayedWords;
      }

      public List<string> GetPlayer2PlayedWords()
      {
        return _player2PlayedWords;
      }

      public void AddPlayer1PlayedWord(string playerWord)
      {
        _player1PlayedWords.Add(playerWord);
      }

      public void AddPlayer2PlayedWord(string playerWord)
      {
        _player2PlayedWords.Add(playerWord);
      }

      public void AddCordsList1(string[] newCords)
      {
        List<string> cords = newCords.ToList();
        _player1CordsList.Add(cords);
      }

      public void AddCordsList2(string[] newCords)
      {
        List<string> cords = newCords.ToList();
        _player2CordsList.Add(cords);
      }

      public List<List<string>> GetCordsList1()
      {
        return _player1CordsList;
      }

      public List<List<string>> GetCordsList2()
      {
        return _player2CordsList;
      }

      public bool WinCheck1(Player currentPlayer)
      {
        bool isWin = false;
        List<string> opponentBase = new List<string>();
        int playerId = currentPlayer.GetId();
        List<string> currentPlayerCords = currentPlayer.MasterCordsList1(currentPlayer);
        if(playerId%2 == 1)
        {
          opponentBase = currentPlayer.GetBase2();
        }
        else
        {
          opponentBase = currentPlayer.GetBase1();
        }
        foreach(string cord in currentPlayerCords)
        {
          if(opponentBase.Contains(cord) == true)
          {
            isWin = true;
          }
        }
        return isWin;
      }

      public bool WinCheck2(Player currentPlayer)
      {
        bool isWin = false;
        List<string> opponentBase = new List<string>();
        int playerId = currentPlayer.GetId();
        List<string> currentPlayerCords = currentPlayer.MasterCordsList2(currentPlayer);
        if(playerId%2 == 1)
        {
          opponentBase = currentPlayer.GetBase2();
        }
        else
        {
          opponentBase = currentPlayer.GetBase1();
        }
        foreach(string cord in currentPlayerCords)
        {
          if(opponentBase.Contains(cord) == true)
          {
            isWin = true;
          }
        }
        return isWin;
      }


      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO games (player) VALUES (@player);";

        cmd.Parameters.Add(new MySqlParameter("@player", this._name));

         cmd.ExecuteNonQuery();

         _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

      public bool IsUsed1(Player currentPlayer, string newWord)
      {
        List<string> playerWords = currentPlayer.GetPlayer1PlayedWords();
        if(playerWords.Contains(newWord) == true)
        {
          return true;
        }
        else
        {
          return false;
        }
      }

      public bool IsUsed2(Player currentPlayer, string newWord)
      {
        List<string> playerWords = currentPlayer.GetPlayer2PlayedWords();
        if(playerWords.Contains(newWord) == true)
        {
          return true;
        }
        else
        {
          return false;
        }
      }


      public static void DeleteGames()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"TRUNCATE TABLE games;";

        cmd.ExecuteNonQuery();

        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
      }


      public bool IsWord(string newWord)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM dictionary WHERE word = @searchWord;";

        cmd.Parameters.Add(new MySqlParameter("@searchWord", newWord));
        var rdr = cmd.ExecuteReader() as MySqlDataReader;

        string returnString = "";
        bool testBool = false;

        while(rdr.Read())
        {
          returnString = rdr.GetString(1);
        }

        if (returnString == newWord)
        {
          testBool = true;
        }
        else
        {
          testBool = false;
        }

        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }

        return testBool;
      }


      public bool IsIn(List<string> playerWords, string targetCord)
      {
        bool isIn = false;

        foreach(string cord in playerWords)
        {
          if (cord == targetCord)
          {
            isIn = true;
          }
        }
        return isIn;
      }

      public int GetCordIndex(List<string> playerWords, string targetCord)
      {
        int targetIndex = 0;

        foreach(string cord in playerWords)
        {
          if (cord == targetCord)
          {
            targetIndex = playerWords.IndexOf(cord);
          }

        }
        return targetIndex;
      }

      public List<string> DeleteAfterId1(int listId, int cordId)
      {
        List<string> popList = new List<string>();

        List<string> targetList = _player1CordsList[listId];
        for(int i = targetList.Count -1; i >= cordId; i--)
        {
          popList.Insert(0, targetList[i]);
          targetList.RemoveAt(i);
          _player1CordsList[listId] = targetList;
        }
        popList.RemoveAt(0);
        return popList;
      }

      public List<string> DeleteAfterId2(int listId, int cordId)
      {
        List<string> popList = new List<string>();

        List<string> targetList = _player2CordsList[listId];
        for(int i = targetList.Count -1; i >= cordId; i--)
        {
          popList.Insert(0, targetList[i]);
          targetList.RemoveAt(i);
          _player2CordsList[listId] = targetList;
        }
        popList.RemoveAt(0);
        return popList;
      }

      public void MasterKiller1(Player opposingPlayer, string[] targetCords)
      {
        // string newTargetString = targetString;
        // string[] targetCords = newTargetString.Split(',');
        List<List<string>> playerWords = opposingPlayer.GetCordsList2();

        foreach(string cord in targetCords)
        {
          List<string> popList = new List<string>(){cord}; //list of removed coordinates
          while(popList.Count > 0)
          {
            for(int p = 0; p < playerWords.Count; p ++)
            {
              for(int i = 0; i < playerWords.Count; i++)
              {
                if(playerWords[i].Count > 0)
                {
                  if (opposingPlayer.IsIn(playerWords[i], popList[0]) == true)
                  {
                    int targetIndex = opposingPlayer.GetCordIndex(playerWords[i], popList[0]);
                    List<string> toPop = opposingPlayer.DeleteAfterId2(i, targetIndex);
                    popList.AddRange(toPop);
                  }
                }
                else
                {
                  continue;
                }
              }
            }
            popList.RemoveAt(0);
          }
        }
      _player2CordsList = playerWords;
        // return popList;
      }

      public void MasterKiller2(Player opposingPlayer, string[] targetCords)
      {
        // string newTargetString = targetString;
        // string[] targetCords = newTargetString.Split(',');
        List<List<string>> playerWords = opposingPlayer.GetCordsList1();

        foreach(string cord in targetCords)
        {
          List<string> popList = new List<string>(){cord}; //list of removed coordinates
          while(popList.Count > 0)
          {
            for(int p = 0; p < playerWords.Count; p ++)
            {
              for(int i = 0; i < playerWords.Count; i++)
              {
                if(playerWords[i].Count > 0)
                {
                  if (opposingPlayer.IsIn(playerWords[i], popList[0]) == true)
                  {
                    int targetIndex = opposingPlayer.GetCordIndex(playerWords[i], popList[0]);
                    List<string> toPop = opposingPlayer.DeleteAfterId1(i, targetIndex);
                    popList.AddRange(toPop);
                  }
                }
                else
                {
                  continue;
                }
              }
            }
            popList.RemoveAt(0);
          }
        }
        _player1CordsList = playerWords;
        // return popList;
      }

      public List<string> MasterCordsList1(Player currentPlayer)
      {
        List<string> cleanCordsList = new List<string>{};
        foreach(List<string> list in currentPlayer.GetCordsList1())
        {
          foreach(string cord in list)
          {
            cleanCordsList.Add(cord);
          }
        }
        return cleanCordsList;
      }

      public List<string> MasterCordsList2(Player currentPlayer)
      {
        List<string> cleanCordsList = new List<string>{};
        foreach(List<string> list in currentPlayer.GetCordsList2())
        {
          foreach(string cord in list)
          {
            cleanCordsList.Add(cord);
          }
        }
        return cleanCordsList;
      }
      //
      // public Dictionary<string,object> InspectorDeck(Dictionary<string,object> Deck)
      // {
      //   string word  = Deck["word"];
      //   string playerNumber  = Deck["player"];
      //   List<string> player1Cords= Deck["player1cells"];
      //   List<string> player2Cords = Deck["player2cells"];
      //
      //
      // }


  }
}
