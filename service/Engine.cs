namespace MiniGame.Service {


 public class  Engine 
 {

    static Random random = new Random();


    // Returns true if the Terminal was resized 
   public static bool TerminalResized(int height, int width) 
    {
        return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
    }

    // Displays random food at a random location
// Modified Move method signature
public static void Move(ref int playerX, ref int playerY, string player, 
                      int height, int width, ref bool shouldExit)
{
    int lastX = playerX;
    int lastY = playerY;
    
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow: playerY--; break;
        case ConsoleKey.DownArrow: playerY++; break;
        case ConsoleKey.LeftArrow: playerX--; break;
        case ConsoleKey.RightArrow: playerX++; break;
        case ConsoleKey.Escape: shouldExit = true; break;
    }

    // Cleaner bounds checking
    playerX = Math.Clamp(playerX, 0, width - player.Length);
    playerY = Math.Clamp(playerY, 0, height - 1);

    // Clear old position more efficiently
    Console.SetCursorPosition(lastX, lastY);
    Console.Write(new string(' ', player.Length));

    // Draw new position
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Modified ShowFood method signature
public static void ShowFood(string[] foods, int height, int width, 
                          string player, ref int foodX, ref int foodY)
{
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[random.Next(0, foods.Length)]);
}


    // Temporarily stops the player from moving
    public static void FreezePlayer(string player, string[] states) 
    {
        System.Threading.Thread.Sleep(1000);
        player = states[0];
    }







 }



}