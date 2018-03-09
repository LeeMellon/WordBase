var word = "";
var cells = [];
var playerTurn = new PlayerTurn;
var PlayerOneCells = ["A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1"];
var PlayerTwoCells = ["A13", "B13", "C13", "D13", "E13", "F13", "G13", "H13", "I13", "J13"];
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
        PlayerOneTempCells.push(y);
        word += x;
        newword.append(x);
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
      PlayerTwoTempCells.push(y);
      word += x;
      newword.append(x);
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
  // player = playerTurn.getPlayer();
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
    // var p1Array = $("#playerOneActiveCells").innerHTML;
    var p1cells11 = $("#p1testArray").val();
    var p1Array11 = [];
    for(var i = 0; i < p1cells11.length; i++)
    {
      p1Array11.push(p1cells11[i]);
      // PlayerOneCells.push(p1cells[i].innerHTML);
    }

    // var p1cells1 = $("#playerOneActiveCells").val();

    var p1cells1 = $("#playerOneActiveCells").val();
    var p1Array1 = [];

    for(var i = 0; i < p1cells1.length; i++)
    {
      p1Array1.push(p1cells1[i]);
      // PlayerOneCells.push(p1cells[i].innerHTML);
    }
    var p2cells2 = $("#playerTwoActiveCells").val();
    var p2Array2 = [];
    for(var i = 0; i < p2cells2.length; i++)
    {
      p2Array2.push(p2cells2[i]);
      // PlayerOneCells.push(p1cells[i].innerHTML);
    }
    console.log("p1 "+p1Array1);
    console.log("p1 "+p1Array1);
    console.log("p1 "+p1Array1[1]);
    // var p2Array = $("#playerTwoActiveCells").val();
    reloadBoard(player, p1Array1, p2Array2);
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
      console.log("Player 1 Turn End");
      playerTurn.setPlayer(2);
      $(".turn1").hide();
      $(".turn2").show();
    }
    else if (playerTurn.getPlayer() == "2")
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
