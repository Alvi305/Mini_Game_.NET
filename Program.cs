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
  
 if (Engine.TerminalResized(length, breadth)) 
    {
        Console.Clear();
        Console.Write("Console was resized. Program exiting.");
        shouldExit = true;
    } 
    else 
    {
        if (Engine.PlayerIsFaster(ref player, states)) 
        {
            Engine.Move(ref x_player, ref y_player, shouldExit,ref player, length, breadth, false, 1);
        } 
        else if (Engine.PlayerIsSick(ref player, states)) 
        {
            Engine.FreezePlayer(ref player,states);
        } else 
        {
            Engine.Move(ref x_player, ref y_player, shouldExit,ref player, length, breadth, false);        }
        if (Engine.GotFood(ref x_player, ref y_player, ref foodX, ref foodY))
        {
            Engine.ChangePlayer(ref player,states, ref food, ref x_player, ref y_player);
            Engine.ShowFood(foods, length, breadth,ref player, ref foodX, ref foodY);
        }
    }
}

if (shouldExit) {
    Console.Clear();
}

// Clears the console, displays the food and player
void InitializeGame() 
{
    Console.Clear();
    Engine.ShowFood(foods, length, breadth,ref player, ref foodX, ref foodY);
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}