using System;

using MiniGame.Service;

Console.CursorVisible = false;
int length = Console.WindowHeight - 1;
int breadth = Console.WindowWidth - 5;
bool shouldExit = false;

// Console position of the player
int x_player = 0;
int y_player = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = {"('-')", "(^-^)", "(X_X)"};
string[] foods = {"@@@@@", "$$$$$", "#####"};

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;

InitializeGame();
while (!shouldExit) 
{
  
shouldExit  = Engine.TerminalResized(length,breadth);

    Engine.Move(ref x_player, ref y_player, player, length, breadth, ref shouldExit);
}



// Clears the console, displays the food and player
void InitializeGame() 
{
    Console.Clear();
    Engine.ShowFood(foods, length, breadth, player, ref foodX, ref foodY);
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}