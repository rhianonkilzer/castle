using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.Clear();
            Console.WriteLine("You have just regained conciousness, you're on a cold wet floor of a castle..");
            Console.WriteLine("You look around, and as you get up the floor begins to shake!");
            Console.WriteLine("As you quickly scan the room you notice an endless black hole in the floor to the west, and a cracked open door to the east.");
            Console.WriteLine("Which direction would you like to go? I'd suggest not falling in the hole...");

            Game game = new Game();
            game.StartGame();
        }
    }
}
