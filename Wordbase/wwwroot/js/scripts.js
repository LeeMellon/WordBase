var word = "";
var cells = [];

function randomChar(){
  var text = "";
  var possible = "AAAAAAAABBCCDDDDEEEEEEEEFFGGGHHIIIIIIIIIJKLLLLMMNNNNOOOOOOPPQRRRRRRSSSSTTTTTUUUUVVWWXYYZ";

  text = possible.charAt(Math.floor(Math.random() * possible.length));
  return text;
}

function myFunction(square)
{
  var playerTurn = 1;
  if(playerTurn == 1)
  {
    var x = document.getElementById(square).innerHTML;
    var y = document.getElementById(square).id;
    document.getElementById(square).style.backgroundColor = "#BB8FCE"
    playerTurn == 2;
    word += x;
    newword.append(x);
    cells.push(y);
    console.log(word);
    console.log(cells);
  }
}


$(function() {
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


  // $("#turnEnd").click()

});
