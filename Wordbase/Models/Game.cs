// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using MySql.Data.MySqlClient;
// using System;
// using Wordbase;
//
// namespace Wordbase.Models
// {
//     public class Game
//     {
//       private int _id;
//       private List<string> _player1Base;
//       private List<string> _player2Base;
//       private bool _isWin;
//
//       public Game( )
//       {
//         _id = id;
//         _player1Base = List{"A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "J1"};
//         _player2Base = List{"A13", "B13", "C13", "D13", "E13", "F13", "G13", "H13", "J13"};
//         _isWin = isWin;
//       }
//
//       public List<string> GetPlayer1Base()
//       {
//         return _player1Base;
//       }
//
//       public List<string> GetPlayer2Base()
//       {
//         return _player2Base;
//       }
//
//       public bool winCheck(Player currentPlayer)
//       {
//         bool isWin = false;
//         int playerId = currentPlayer.GetId();
//         List<string> currentPlayerCords = currentPlayer.MasterCordsList(currentPlayer);
//         if(playerId == 1)
//         {
//           List<string> opponentBase = Game.GetPlayer2Base();
//         }
//         else
//         {
//           List<string> opponentBase = Game.GetPlayer1Base();
//         }
//         foreach(string cord in currentPlayerCords)
//         {
//           if (cord in opponentBase)
//           {
//             isWin = true;
//             return isWin;
//           }
//           else
//           {
//             return isWin;
//           }
//         }
//       }
//
//
//
//     }
//
// }
