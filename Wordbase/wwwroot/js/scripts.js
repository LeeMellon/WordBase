var word = "";
var cells = [];
var playerTurn = new PlayerTurn;
var PlayerOneCells = ["A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "J1"];
var PlayerTwoCells = ["A13", "B13", "C13", "D13", "E13", "F13", "G13", "H13", "J13"];
var PlayerOneTempCells = [];
var PlayerTwoTempCells = [];
// var TempCells = [];

function PlayerTurn(){
  this.player = 0;
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
  // if(player == 1)
  // {
  //   document.getElementById(square).style.backgroundColor = "#BB8FCE";
  //   // if (!PlayerOneCells.includes(y)){
  //   //   PlayerOneCells.push(y);
  //   if(startingCheck(player,square))
  //   {
  //     if (!PlayerOneTempCells.includes(y)){
  //       PlayerOneTempCells.push(y);
  //       //make temp list, then on
  //     }
  //     //make temp list, then on submit and validation push to main list
  //   }
  // }
  // else if (player == 2)
  // {
  //   document.getElementById(square).style.backgroundColor = "#F1948A";
  //   // if (!PlayerTwoCells.includes(y)){
  //   //   tempCells.push(x);
  //   if(startingCheck(player,square))
  //   {
  //     document.getElementById(square).style.backgroundColor = "#BB8FCE";
  //     if (!PlayerTwoTempCells.includes(y)){
  //       PlayerTwoTempCells.push(y);
  //     }
  //   }
  // }
  // else
  // {
  //   console.log("Not a turn");
  // }

  if(player == 1)
  {
    document.getElementById(square).style.backgroundColor = "#BB8FCE";
    if (!PlayerOneTempCells.includes(y)){
      PlayerOneTempCells.push(y);
  } else if (player == 2) {
    document.getElementById(square).style.backgroundColor = "#BB8FCE";
    if (!PlayerTwoTempCells.includes(y)){
      PlayerTwoTempCells.push(y);
      }
    }
  }



    this.onclick=null;
    word += x;
    newword.append(x);
    // if(player == 1){
    //   PlayerOneTempCells.push(y);
    // }
    // if(player == 2){
    //   PlayerTwoTempCells.push(y);
    // }
    // cells.push(y);
    console.log(word);
    console.log(cells);
    console.log("P1 " + PlayerOneCells);
    console.log("P2 " + PlayerTwoCells);
    console.log("P1 temp " + PlayerOneTempCells);
    console.log("P2 temp " + PlayerTwoTempCells);
    console.log("player "+ playerTurn.getPlayer());
    // console.log("temp " + TempCells);
}

function generateBoard(){
  playerTurn.setPlayer(1);
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
  playerTurn.setPlayer(player);
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
    $("#"+p1cells[i]).addClass("player1color");
  }
  for(var i=0; i < p2cells.length; i++){
    $("#"+p2cells[i]).addClass("player2color");
  }
}

function isWord(){
  var result = document.getElementById("isword").value;
  alert(result);
}


// function to check if beginning square is valid starting point
function startingCheck(player,square){
    if(player == 1 && PlayerOneCells.length == 0)
    {
      if(!PlayerOneCells.includes(square))
      {
        document.getElementById(square).style.backgroundColor = "white";
        alert("Not a valid start");
        return false;
      }
      else {
        return true;
      }
    }
  if(player == 2 && PlayerTwoCells.length == 0)
  {
    if(!PlayerTwoCells.includes(square))
    {
      document.getElementById(square).style.backgroundColor = "white";
      alert("Not a valid start");
      return false;
    }
    else {
      return true;
    }
  }
}


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
    $("#player").val(playerTurn.getPlayer());
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
    reloadBoard(1, p1Array, p2Array);
    isWord();
    PlayerOneCells = [];
    PlayerTwoCells = [];

  });

  $("#turnEnd").click(function(event){
    event.preventDefault();
    // run a bunch of checks here for valid play
    // store play data in database
    if (playerTurn.getPlayer() == 1)
    {
      console.log("Player 1 Turn End");
      playerTurn.setPlayer(2);
      $(".turn1").hide();
      $(".turn2").show();
    }
    else if (playerTurn.getPlayer() == 2)
    {
      playerTurn.setPlayer(1);
      console.log("Player 2 Turn End");
      $(".turn2").hide();
      $(".turn1").show();
    }
    word = "";
    cells = [];
    $("#newword").text("Current Word: ");

  });
});
