// CREATE TABLE `word_base`.`cell` ( `id` INT NOT NULL AUTO_INCREMENT , `position` VARCHAR(255) NOT NULL , `letter` VARCHAR(255) NOT NULL , `score` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
// 
//
// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using MySql.Data.MySqlClient;
// using System;
// using Wordbase;
//
// namespace Wordbase.Models
// {
//   public class Cell
//   {
//     private int _id;
//     private string _position;
//     private string _letter;
//     private int _score;
//
//     public Cell(string position, string letter="", int score=0, int id=0 )
//     {
//       _id = id;
//       _position = position;
//       _letter = letter;
//       _score = score;
//     }
//
//     public int GetId()
//     {
//       return _id;
//     }
//
//     public string GetPosition()
//     {
//       return _position;
//     }
//
//     public void SetPosition(string newPosition)
//     {
//       _position = newPosition;
//     }
//
//     public string GetLetter()
//     {
//       return _letter;
//     }
//
//     public void SetLetter(string newLetter)
//     {
//       _letter = newLetter;
//     }
//
//     public int GetScore()
//     {
//       return _score;
//     }
//
//     public void SetScore(string newScore)
//     {
//       _score = newScore;
//     }
//
//     public string randomChar()
//     {
//       string possible = "AAAAAAAABBCCDDDDEEEEEEEEFFGGGHHIIIIIIIIIJKLLLLMMNNNNOOOOOOPPQRRRRRRSSSSTTTTTUUUUVVWWXYYZ";
//       string randChar = possible[Random.Range(possible.length)];
//       return randChar;
//     }
//
//   }
// }


//   // console testing
//   public class Program
//   {
//     public static void Main()
//     {
//       Cell newCell = newCell("A1");
//       string x = newCell.randomChar();
//       newCell.SetLetter(x);
//       Console.WriteLine(x);
//       Console.WriteLine(newCell.GetLetter());
//     }
//   }
// }
