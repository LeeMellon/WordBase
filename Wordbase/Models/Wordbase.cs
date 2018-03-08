using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using Wordbase;

namespace Wordbase.Models
{
    public class Player
    {
      private int _id;
      private string _name;
      // private string _word;
      private List<string> _player1Base;
      private List<string> _player2Base;
      private List<string> _playedWords;
      private List<List<string>> _cordsList;
      private int _rndScore;
      private int _playerScore;

      public Player(string name, List<List<string>> cordsList, int playerScore = 0, int id =0)
      {
        _id = id;
        _name = name;
        _player1Base = new List<string>(){"A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "J1"};
        _player2Base = new List<string>(){"A13", "B13", "C13", "D13", "E13", "F13", "G13", "H13", "J13"};
        _cordsList = cordsList;
        _playerScore = playerScore;
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

      public List<string> GetCordsBundle(Player currentPlayer)
      {
        int id = currentPlayer.GetId();
        List<string> baseCords = new List<string>();
        List<string> bundle = currentPlayer.MasterCordsList(currentPlayer);
        if(id%2 == 1)
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

      public List<string> GetPlayedWords()
      {
        return _playedWords;
      }

      public void AddPlayedWord(string playerWord)
      {
        _playedWords.Add(playerWord);
      }

      public void AddCordsList(List<string> cords)
      {
        _cordsList.Add(cords);
      }

      public List<List<string>> GetCordsList()
      {
        return _cordsList;
      }

      public bool WinCheck(Player currentPlayer)
      {
        bool isWin = false;
        List<string> opponentBase = new List<string>();
        int playerId = currentPlayer.GetId();
        List<string> currentPlayerCords = currentPlayer.MasterCordsList(currentPlayer);
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

      public void PlayerSave()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO players (name, player_base, cords_list, played_words) VALUES (@name, @player_base, @cords_list, @played_words);";

        cmd.Parameters.Add(new MySqlParameter("@name", this._name));
        cmd.Parameters.Add(new MySqlParameter("@player_base", this._player1Base));
        cmd.Parameters.Add(new MySqlParameter("@cords_list", this._cordsList));
        cmd.Parameters.Add(new MySqlParameter("@played_words", this._playedWords));

         cmd.ExecuteNonQuery();

         _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }


      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO games (player, word) VALUES (@player, @score);";

        cmd.Parameters.Add(new MySqlParameter("@player", this._name));
        cmd.Parameters.Add(new MySqlParameter("@score", this._playerScore));

         cmd.ExecuteNonQuery();

         _id = (int) cmd.LastInsertedId;
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

      public bool IsUsed(Player currentPlayer, string newWord)
      {
        List<string> playerWords = currentPlayer.GetPlayedWords();
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

      public List<string> DeleteAfterId(int listId, int cordId)
      {
        List<string> popList = new List<string>();

        List<string> targetList = _cordsList[listId];
        for(int i = targetList.Count -1; i >= cordId; i--)
        {
          popList.Insert(0, targetList[i]);
          targetList.RemoveAt(i);
          _cordsList[listId] = targetList;
        }
        popList.RemoveAt(0);
        return popList;
      }


      public void MasterKiller(Player opposingPlayer, string targetCord)
      {
        List<string> popList = new List<string>(){targetCord}; //list of removed coordinates
        List<List<string>> playerWords = opposingPlayer.GetCordsList();

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
                  List<string> toPop = opposingPlayer.DeleteAfterId(i, targetIndex);
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
        _cordsList = playerWords;
        // return popList;
      }

      public List<string> MasterCordsList(Player currentPlayer)
      {
        List<string> cleanCordsList = new List<string>{};
        foreach(List<string> list in currentPlayer._cordsList)
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
