using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using Wordbase;

namespace Wordbase.Models
{
    public class Turn
    {
      private int _id;
      private string _player;
      private string _word;

      public Turn(string player, string word, int id =0)
      {
        _id = id;
        _player = player;
        _word = word;
      }

      public void SetId(int newId)
      {
        _id = newId;
      }

      public int GetId()
      {
        return _id;
      }

      public void SetPlayer(string player)
      {
        _player = player;
      }

      public string GetPlayer()
      {
        return _player;
      }

      public void SetWord(string newWord)
      {
        _word = newWord;
      }

      public string GetWord()
      {
        return _word;
      }


      public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO games (player, word) VALUES (@player, @word);";

        cmd.Parameters.Add(new MySqlParameter("@player", this._player));
        cmd.Parameters.Add(new MySqlParameter("@word", this._word));

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
    }

}
