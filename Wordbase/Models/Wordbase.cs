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
      private string _word;
      private List<string> _playedWords;
      private List<List<string>> _cordsList;
      private int _rndScore;
      private int _playerScore;

      public Player(string name, List<List<string>> cordsList, int playerScore = 0, int id =0)
      {
        _id = id;
        _name = name;
        _cordsList = cordsList;
        _playerScore = playerScore;
      }

      //add more getters/setters

      public void SetId(int newId)
      {
        _id = newId;
      }

      public int GetId()
      {
        return _id;
      }

      public void SetName(string name)
      {
        _name = name;
      }

      public string GetName()
      {
        return _name;
      }

      public void SetWord(string newWord)
      {
        _word = newWord;
      }

      public string GetWord()
      {
        return _word;
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

      public int GetCordIndex(string targetCord)
      {
        int targetIndex =0;
        foreach(List<string> cordsList in _cordsList)
        {

          foreach(string cord in cordsList)
          {
            if (cord == targetCord)
            {
              targetIndex = cordsList.IndexOf(cord);
            }
          }
        }
        return targetIndex;
      }

      // public List<string> DeleteAfterId(int listId, int cordId)
      // {
      //   List<string> popList = new List<string>();
      //
      //   List<string> targetList = _cordsList[listId];
      //   for(int i = targetList.Length -1; i >= cordId; i--)
      //   {
      //     List<string> poppedCord = targetList.Pop(i);
      //   }
      //   _cordsList[listId] = targetList;
      //   return _cordsList[listId];
      // }
  }
}
