var word = "";
var cells = [];
var playerTurn = new PlayerTurn;
var PlayerOneCells = ["A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "J1"];
var PlayerTwoCells = ["A13", "B13", "C13", "D13", "E13", "F13", "G13", "H13", "J13"];
var PlayerOneBaseCells = ["A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "J1"];
var PlayerTwoBaseCells = ["A13", "B13", "C13", "D13", "E13", "F13", "G13", "H13", "J13"];
var PlayerOneTempCells = [];
var PlayerTwoTempCells = [];

function PlayerTurn(){
  this.player = "";
}

function randomChar(){
  var text = "";
  var possible = "AAAAAAAABBCCDDDDEEEEEEEEFFGGGHHIIIIIIIIIJKLLLLMMNNNNOOOOOOPPQRRRRRRSSSSTTTTTUUUUVVWWXYYZ";

  text = possible.charAt(Math.floor(Math.random() * possible.length));
  return text;
}

function myFunction(square)
{
  var player = playerTurn.getPlayer();
  var x = document.getElementById(square).innerHTML;
  var y = document.getElementById(square).id;

  if (player == "1")
  {
    if (PlayerOneTempCells.length == 0 && !PlayerOneCells.includes(y))
    {
      document.getElementById(square).style.backgroundColor = "white";
      alert("Not a valid start");
    } else {
      document.getElementById(square).style.backgroundColor = "#BB8FCE";
      if (!PlayerOneTempCells.includes(y)){
        if(PlayerOneTempCells.length > 0)
        {
          if(adjacent(y))
          {
            PlayerOneTempCells.unshift(y);
            word += x;
            newword.append(x);
          }
          else {
            document.getElementById(square).style.backgroundColor = "white";
            alert("Not a valid move");
          }
        }
        else{
        PlayerOneTempCells.unshift(y);
        word += x;
        newword.append(x);
      }
      }
    }
  }
  if (player == "2")
  {
    if (PlayerTwoTempCells.length == 0 && !PlayerTwoCells.includes(y))
    {
      document.getElementById(square).style.backgroundColor = "white";
      alert("Not a valid start");
    } else {
      document.getElementById(square).style.backgroundColor = "#F1948A";
      if (!PlayerTwoTempCells.includes(y)){
        if(PlayerTwoTempCells.length > 0)
        {
          if(adjacent(y))
          {
            PlayerTwoTempCells.unshift(y);
            word += x;
            newword.append(x);
          }
          else {
            document.getElementById(square).style.backgroundColor = "white";
            alert("Not a valid move");
          }
        }
        else{
        PlayerTwoTempCells.unshift(y);
        word += x;
        newword.append(x);
      }
      }
    }
  }

  // this.onclick=null;

  console.log(word);
  console.log(cells);
  console.log("P1 " + PlayerOneCells);
  console.log("P2 " + PlayerTwoCells);
  console.log("P1 temp " + PlayerOneTempCells);
  console.log("P2 temp " + PlayerTwoTempCells);
  console.log("player "+ playerTurn.getPlayer());
}


function WinCheck(){
  if(player == 1)
  {
    for ( var i  = 0; i < PlayerOneTempCells; i++)
    {
      for( var j = 0; j < PlayerTwoBaseCells; j++)
      {
        if(PlayerOneTempCells[i] == PlayerTwoBaseCells[i])
        {
          return true;
        }
        else{
          return false;
        }
      }
    }
  }
  else if(player == 2)
  {
    for ( var i  = 0; i < PlayerTwoTempCells; i++)
    {
      for( var j = 0; j < PlayerOneBaseCells; j++)
      {
        if(PlayerTwoTempCells[i] == PlayerOneBaseCells[i])
        {
          return true;
        }
        else{
          return false;
        }
      }
    }
  }
}

function generateBoard(){
  playerTurn.setPlayer("1");
  PlayerOneTempCells = [];
  PlayerTwoTempCells = [];
  var board = [];
  var letters = ["A","B","C","D","E","F","G","H","I","J"];
  for(var i  = 1; i <= 13; i++)
  {
    for( var j = 0;j<letters.length; j++)
    {
      var newChar = randomChar();
      var element = document.getElementById(letters[j]+i);
      element.innerHTML = newChar;
      sessionStorage.setItem((letters[j]+i), newChar);
      board.push(newChar);
    }
  }
  console.log(board);
}

function reloadBoard(player, p1cells, p2cells){
  // 1, ["A1", "A2", "B3", "C4"], ["J10", "I9", "H8", "I8", "I7"]
  // feed in player
  // feed in array for player1cells
  // feed in array for player2cells
  player = playerTurn.getPlayer();
  var letters = ["A","B","C","D","E","F","G","H","I","J"];
  for(var i  = 1; i <= 13; i++)
  {
    for( var j = 0;j<letters.length; j++)
    {
      var element = document.getElementById(letters[j]+i);
      element.innerHTML = sessionStorage.getItem((letters[j]+i));
    }
  }
  for(var i=0; i < p1cells.length; i++){
    $("#" + p1cells[i]).addClass("player1color");
  }
  for(var i=0; i < p2cells.length; i++){
    $("#"+p2cells[i]).addClass("player2color");
  }
}

function isWord(){
  var result = document.getElementById("isword").value;
  alert(result);
}

function adjacent(y){
  var testArray = y.split(""); //Left
  var yourChar = testArray[0];
  var newX = String.fromCharCode(yourChar.charCodeAt(0) + 1) // increment letter by 1
  testArray[0] = newX;
  var check = testArray.join('');
  if(check == PlayerOneTempCells[0])
  {
    return true;
  }

  var testArray = y.split(""); //Right
  var yourChar = testArray[0];
  var newX = String.fromCharCode(yourChar.charCodeAt(0) - 1) // increment letter by 1
  testArray[0] = newX;
  var check = testArray.join('');
  if(check == PlayerOneTempCells[0])
  {
    return true;
  }


  var testArray = y.split(""); //Up
  if (testArray.length > 2)
  {
    var yourChar = testArray[0];
    var middleNum = testArray[1];
    var newNum = testArray[2];
    newNum = newNum + 1;
    testArray[1] = middleNum;
    testArray[2] = newNum;
  }
  else
  {
    var yourChar = testArray[0];
    var newNum = parseInt(testArray[1]);
    var middleNum;
    if (newNum == 9)
    {
      newNum = 0;
      middleNum = 1;
      testArray[1] = middleNum;
      testArray[2] = newNum;
      var check = testArray.join('');
      console.log("this array test" + testArray);
      if(check == PlayerOneTempCells[0])
      {
        return true;
      }
    }
  }

  var testArray = y.split('');//Down
  if (testArray.length > 2){
    var yourChar = testArray[0];
    var middleNum = testArray[1];
    var newNum = testArray[2];
    if (newNum == 0)
    {
      middleNum = 9;
      testArray.pop();
      testArray[1] = middleNum;
    }
    else {
      newNum = newNum - 1;
      testArray[2] = newNum;
    }
    var check = testArray.join('');
    if(check == PlayerOneTempCells[0])
    {
      return true;
    }
  } else {
    var yourChar = testArray[0];
    var newNum = testArray[1];
    newNum = newNum - 1;
    testArray[1] = newNum;
    var check = testArray.join('');
    if(check == PlayerOneTempCells[0])
    {
      return true;
    }
  }

  var testArray = y.split(""); //UpLeft
  var yourChar = testArray[0];
  var newX = String.fromCharCode(yourChar.charCodeAt(0) + 1) // increment letter by 1
  testArray[0] = newX;
  var newNum = parseInt(testArray[1]);
  newNum = newNum + 1;
  testArray[1] = newNum;
  var check = testArray.join('');
  if(check == PlayerOneTempCells[0])
  {
    return true;
  }


  var testArray = y.split(""); //UpRight
  var yourChar = testArray[0];
  var newX = String.fromCharCode(yourChar.charCodeAt(0) - 1) // increment letter by 1
  testArray[0] = newX;
  var newNum = parseInt(testArray[1]);
  newNum = newNum + 1;
  testArray[1] = newNum;
  var check = testArray.join('');
  if(check == PlayerOneTempCells[0])
  {
    return true;
  }


  var testArray = y.split(""); //DownLeft
  var yourChar = testArray[0];
  var newX = String.fromCharCode(yourChar.charCodeAt(0) + 1) // increment letter by 1
  testArray[0] = newX;
  var newNum = testArray[1];
  newNum = newNum - 1;
  testArray[1] = newNum;
  var check = testArray.join('');
  if(check == PlayerOneTempCells[0])
  {
    return true;
  }


  var testArray = y.split(""); //DownRight
  var yourChar = testArray[0];
  var newX = String.fromCharCode(yourChar.charCodeAt(0) - 1) // increment letter by 1
  testArray[0] = newX;
  var newNum = testArray[1];
  newNum = newNum - 1;
  testArray[1] = newNum;
  var check = testArray.join('');
  if(check == PlayerOneTempCells[0])
  {
    return true;
  }
}




//this was rewritten into myFunction
// function to check if beginning square is valid starting point
// function startingCheck(player,square){
//     if (player == "1" && PlayerOneCells.length == 0)
//     {
//       if(!PlayerOneCells.includes(square))
//       {
//         document.getElementById(square).style.backgroundColor = "white";
//         alert("Not a valid start");
//         return false;
//       }
//       else {
//         return true;
//       }
//     }
//   if (player == "2" && PlayerTwoCells.length == 0)
//   {
//     if (!PlayerTwoCells.includes(square))
//     {
//       document.getElementById(square).style.backgroundColor = "white";
//       alert("Not a valid start");
//       return false;
//     }
//     else {
//       return true;
//     }
//   }
// }


// function to check if selected square is adjacent to previous choice

// reset turn function


PlayerTurn.prototype.getPlayer = function(player) {
  return playerTurn.player;
}

PlayerTurn.prototype.setPlayer = function(player) {
  playerTurn.player = player;
}


$(document).ready(function() {

  $("#reset").click(function(){
    generateBoard();
  });

  // this needs to be tested
  $("#verifyWord").click(function(){
    $("#verify").val(word);
    $("#newp1cells").val(PlayerOneTempCells);
    $("#newp2cells").val(PlayerTwoTempCells);
    $("#newplayer").val(playerTurn.getPlayer());
  });

  $("#reload").click(function(){

    // reloadBoard(1, ["A1", "A2", "B3", "C4"], ["J10", "I9", "H8", "I8", "I7"]);
    // var p1cells = ["A1", "A2", "B3", "C4"];

    var p1cells = document.getElementsByClassName("p1");
    var p1Array = [];
    var p2cells = document.getElementsByClassName("p2");
    var p2Array = [];
    for(var i = 0; i < p1cells.length; i++)
    {
      p1Array.push(p1cells[i].innerHTML);
      PlayerOneCells.push(p1cells[i].innerHTML);
    }
    for(var i = 0; i < p2cells.length; i++)
    {
      p2Array.push(p2cells[i].innerHTML);
      PlayerTwoCells.push(p2cells[i].innerHTML);
    }

    // reloadBoard(1, p1Array, p2Array);
    // var player = playerTurn.getPlayer();
    var player = $("#playerNum").val();
    reloadBoard(player, p1Array, p2Array);
    isWord();
    // PlayerOneCells = [];
    // PlayerTwoCells = [];

  });

  $("#turnEnd").click(function(event){
    event.preventDefault();
    // run a bunch of checks here for valid play
    // store play data in database
    if (playerTurn.getPlayer() == "1")
    {
      playerTurn.setPlayer(2);
      if(WinCheck)
      {
        $.confetti.start();
      }
      $(".turn1").hide();
      $(".turn2").show();
    }
    else if (playerTurn.getPlayer() == "2")
    {
      playerTurn.setPlayer(1);
      if(WinCheck)
      {
        $.confetti.start();
      }
      $(".turn2").hide();
      $(".turn1").show();
    }
    word = "";
    cells = [];
    $("#newword").text("Current Word: ");

  });
});
