using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using Wordbase;

namespace Wordbase.Models
{
    public class Game
    {
      private int _id;
      private List<string> _player1Cords;
      private List<string> _player2Cords;
      private List<string> _player1Base;
      private List<string> _player2Base;
      private bool _isWin;

      public Game
      {
        
      }
    }

}

