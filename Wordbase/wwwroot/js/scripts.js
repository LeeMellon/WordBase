var word = "";
var cells = [];
var playerTurn = new PlayerTurn;

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
  // var playerTurn = 1;
  var player = playerTurn.getPlayer();
  var x = document.getElementById(square).innerHTML;
  var y = document.getElementById(square).id
  if(!cells.includes(y)) {
      if(player == 1)
      {
        document.getElementById(square).style.backgroundColor = "#BB8FCE";
      }
      else if (player == 2)
      {
        document.getElementById(square).style.backgroundColor = "#F1948A";
      }
      else
      {
        console.log("Not a turn");
      }
    this.onclick=null;
    word += x;
    newword.append(x);
    cells.push(y);
    console.log(word);
    console.log(cells);
  }
}

PlayerTurn.prototype.getPlayer = function(player) {
  return playerTurn.player;
}

PlayerTurn.prototype.setPlayer = function(player) {
  playerTurn.player = player;
}


$(document).ready(function() {
  playerTurn.setPlayer(1);
  var letters = ["A","B","C","D","E","F","G","H","I","J"];
  for(var i  = 1; i <= 13; i++)
  {
    for( var j = 0;j<letters.length; j++)
    {
      var newChar = randomChar()
      var element = document.getElementById(letters[j]+','+i);
      element.innerHTML = newChar;
    }
  }
  $("#turnEnd").click(function(event){
    event.preventDefault();
    // run a bunch of checks here for valid play
    // store play data in database
    if (playerTurn.getPlayer() == 1)
    {
      console.log("Player 1 Turn End");
      playerTurn.setPlayer(2);
      $(".turn1").show();
      $(".turn2").hide();
    }
    else if (playerTurn.getPlayer() == 2)
    {
      playerTurn.setPlayer(1);
      console.log("Player 2 Turn End");
      $(".turn2").show();
      $(".turn1").hide();
    }
    word = "";
    cells = [];
  });
});
