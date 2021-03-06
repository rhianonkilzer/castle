using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        public bool playing = false;


        public void GetUserInput()
        {
            System.Console.WriteLine("What would you like to do?");
            string input = Console.ReadLine();
            string[] data = input.Split(" ");
            switch (data[0].ToLower())
            {
                case "go":
                    Go(data[1].ToLower());
                    break;
                case "take":
                    TakeItem(data[1].ToLower());
                    break;
                case "use":
                    UseItem(data[1].ToLower());
                    break;
                case "help":
                    Help();
                    break;
                case "restart":
                    Reset();
                    break;
                case "inventory":
                    Inventory();
                    break;
                case "quit":
                    Quit();
                    break;
                case "look":
                    Look();
                    break;

                default:
                    System.Console.WriteLine("Invalid command, please try again or type help for a list of commands.");
                    break;

            }

        }

        public void Go(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction) && CurrentRoom.Locked != true)
            {
                CurrentRoom = CurrentRoom.Exits[direction];
                Look();
            }
            else if (CurrentRoom.Locked)
            {
                System.Console.WriteLine("It's locked... do you have a key?");
            }
            else
            {
                System.Console.WriteLine("....That's a wall, you can't go that direction.");
            }

        }

        public void Help()
        {

            System.Console.WriteLine(@"

                      | |__|__|__|__|__|__|__|__|__|_|
 __    __    __       |_|___|___|___|___|___|___|___||       __    __    __
|__|  |__|  |__|      |___|___|___|___|___|___|___|__|      |__|  |__|  |__|
|__|__|__|__|__|       \____________________________/       |__|__|__|__|__|
|_|___|___|___||        |_|___|___|___|___|___|___||        |_|___|___|___||
|___|___|___|__|        |___|___|___|___|___|___|__|        |___|___|___|__|
 \_|__|__|___|/          \________________________/          \_|__|__|__|_/
  \__|____|__/            |___|___|___|___|___|__|            \__|__|__|_/
   |||_|_|_||             |_|___|___|___|___|__|_|             |_|_|_|_||
   ||_|_|||_|__    __    _| _  __ |_ __  _ __  _ |_    __    __||_|_|_|_|
   |_|_|_|_||__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|__|_|_|_|_||
   ||_|||_|||___|___|___|___|___|___|___|___|___|___|___|___|__||_|_|_|_|
   |_|_|_|_||_|___|___|___|___|___|___|___|___|___|___|___|___||_|_|_|_||
   ||_|_|_|_|___|___|___|___|___|___|___|___|___|___|___|___|__||_|_|_|_|
   |_|||_|_||_|___|___|___|___|___|___|___|___|___|___|___|___||_|_|_|_||
   ||_|_|_|_|___|___|___|___|___|_/| | | \__|___|___|___|___|__||_|_|_|_|
   |_|_|_|_||_|___|___|___|___|__/ | | | |\___|___|___|___|___||_|_|_|_||
   ||_|_|_|||___|___|___|___|___|| | | | | |____|___|___|___|__||_|_|_|_|
   |_|_|_|_||_|___|___|___|___|_|| | | | | |__|___|___|___|___||_|_|_|_||
  /___|___|__\__|___|___|___|___|| | | | | |____|___|___|___|_/_|___|__|_\
 |_|_|_|_|_|_||___|___|___|___|_|| | | | | |__|___|___|___|__|_|__|__|__|_|
 ||_|_|_|_|_|_|_|___|___|___|___||_|_|_|_|_|____|___|___|____|___|__|__|__|
              ___
             (._.)   
             <|>     
            _/\_     


            

            Here is a list of commands:
            Help
            Go <East, West, North, South>
            Use <item>
            Take <item>
            Quit
            Restart
            Inventory
            
            ");
        }

        public void Inventory()
        {
            foreach (var item in CurrentPlayer.Items)
            {
                System.Console.WriteLine(item.Name);

            }
        }

        public void Look()
        {
            System.Console.WriteLine(CurrentRoom.Name);
            System.Console.WriteLine(CurrentRoom.Description);
            System.Console.WriteLine("ITEMS:\n");
            foreach (var item in CurrentRoom.Items)
            {

                System.Console.WriteLine(item.Description);
            }
            //WHERE?!
        }

        public void Quit()
        {
            playing = false;

        }

        public void Reset()
        {

            StartGame();
        }

        public void Setup()
        {
            playing = true;
            //setup rooms
            Room StartingPoint = new Room("Starting Room:", "Where you woke up", false);
            Room KeyRoom = new Room("The next room through the cracked door:", "This room has a shiney key on the floor with a hall leading to the next room", false);
            Room LockedRoom = new Room("Locked Room:", "This room looks locked...", true);
            Room StinkyRoom = new Room("The Stinky Room:", "This room smells like feet...", false);
            Room EndlessBlackHole = new Room("Endless Black Hole:", "Looks like you made a poor choice, ...or don't cause You D E D", false);
            Room Lose = new Room("You lost... Oh jeez. Now what?!", "You should probably try again.", false);
            Room Winning = new Room("Congratulations!!! You have defeated the worlds hardest castle challenge, you win thousands, and thousands of bubbles.", "You are the GREATEST OF ALL TIME.", false);

            Item ShinyKey = new Item("key", "It's shiny!");
            KeyRoom.Items.Add(ShinyKey);
            //setup my exits
            StartingPoint.Exits.Add("east", KeyRoom);
            StartingPoint.Exits.Add("west", EndlessBlackHole);
            KeyRoom.Exits.Add("west", StartingPoint);
            KeyRoom.Exits.Add("south", LockedRoom);
            LockedRoom.Exits.Add("west", StinkyRoom);
            LockedRoom.Exits.Add("north", KeyRoom);
            StinkyRoom.Exits.Add("east", LockedRoom);
            StinkyRoom.Exits.Add("south", Winning);



            CurrentPlayer = new Player();
            CurrentRoom = StartingPoint;

        }

        public void StartGame()
        {
            Setup();
            Console.Clear();
            Console.WriteLine("You have just regained conciousness, you're on a cold wet floor of a castle..");
            Console.WriteLine("As you scan the room you notice an endless black hole in the floor to the west, and a cracked open door to the east.");
            Console.WriteLine("I'd suggest not falling into the hole...");

            while (playing)
            {
                GetUserInput();
                if (CurrentRoom.Name == "Endless Black Hole:")
                {
                    System.Console.WriteLine("You have died, you lose...");
                    Console.WriteLine("Would you like to play again? y/n");
                    ConsoleKeyInfo cki = Console.ReadKey(); //wait for player to press a key
                    playing = cki.KeyChar == 'y'; //continue only if y was pressed
                    Reset();
                    Console.WriteLine("");
                }
                if (CurrentRoom.Name == "Congratulations!!! You have defeated the worlds hardest castle challenge, you win thousands, and thousands of bubbles.")
                {
                    System.Console.WriteLine("WINNER WINNER CHICKEN DINNER");
                    Console.WriteLine("Would you like to play again? y/n");
                    ConsoleKeyInfo cki = Console.ReadKey(); //wait for player to press a key
                    playing = cki.KeyChar == 'y'; //continue only if y was pressed
                    Reset();
                    Console.WriteLine("");
                }
            }

        }



        public void TakeItem(string itemName)
        {
            Item foundItem = CurrentRoom.Items.Find(item => item.Name == itemName);
            if (foundItem != null)
            {
                CurrentRoom.Items.Remove(foundItem);
                CurrentPlayer.Items.Add(foundItem);
                System.Console.WriteLine(foundItem.Name);
            }
        }

        public void UseItem(string itemName)
        {
            //find item, if not null, flip locked on currentroom
            Item playerItem = CurrentPlayer.Items.Find(item => item.Name == itemName);
            if (playerItem != null)
            {
                CurrentPlayer.Items.Remove(playerItem);
                CurrentRoom.Locked = false;
                System.Console.WriteLine(itemName + " used! The Door unlocked");
            }
        }

    }
}