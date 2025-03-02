namespace MiniGame.Service {


 public class  Engine 
 {

    static Random random = new Random();


// Returns true if the Terminal was resized 
public static bool TerminalResized(int height, int width) 
    {
        return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
    }

// Reads directional input from the Console and moves the player
public static void Move( ref int playerX, ref int playerY, bool shouldExit, ref string player, int height, int width, bool otherKeysExit = false,int speed = 1) 
{
    int lastX = playerX;
    int lastY = playerY;
    
    switch (Console.ReadKey(true).Key) {
        case ConsoleKey.UpArrow:
            playerY--; 
            break;
		case ConsoleKey.DownArrow: 
            playerY++; 
            break;
		case ConsoleKey.LeftArrow:  
            playerX -= speed; 
            break;
		case ConsoleKey.RightArrow: 
            playerX += speed; 
            break;
		case ConsoleKey.Escape:     
            shouldExit = true; 
            break;
        default:
            // Exit if any other keys are pressed
            shouldExit = otherKeysExit;
            break;
    }

    // Clear the characters at the previous position
    Console.SetCursorPosition(lastX, lastY);
    Console.Write(new string(' ', player.Length));

    // Keep player position within the bounds of the Terminal window
    playerX = Math.Clamp(playerX, 0, width - player.Length);
    playerY = Math.Clamp(playerY, 0, height - 1);


    // Draw the player at the new location
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Displays random food at a random location
public static void ShowFood(string[] foods, int height, int width, 
                         ref string player, ref int foodX, ref int foodY)
{
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[random.Next(0, foods.Length)]);
}


// Temporarily stops the player from moving
public static void FreezePlayer(ref string player, string[] states) 
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];
}


// Returns true if the player location matches the food location
public static bool GotFood(ref int playerX, ref int playerY, ref int foodX, ref int foodY) 
{
    return playerY == foodY && playerX == foodX;
}

// Returns true if the player appearance represents a sick state
public static bool PlayerIsSick(ref string player, string[] states) 
{
    return player.Equals(states[2]);
}

// Returns true if the player appearance represents a fast state
public static bool PlayerIsFaster(ref string player, string[] states) 
{
    return player.Equals(states[1]);
}

// Changes the player to match the food consumed
public static void ChangePlayer(ref string player, string[] states,ref int food, ref int playerX, ref int playerY) 
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

 }
}