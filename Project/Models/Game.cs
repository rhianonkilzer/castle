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
                default:
                    System.Console.WriteLine("Invalid command, please try again or type help for a list of commands.");
                    break;

            }

        }

        public void Go(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
                Look();
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
            ");
        }

        public void Inventory()
        {
            System.Console.WriteLine(CurrentPlayer.Items);
        }

        public void Look()
        {
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

        }

        public void Reset()
        {
            StartGame();
        }

        public void Setup()
        {
            playing = true;
            //setup rooms
            Room StartingPoint = new Room("Starting Room", "Where you woke up");
            Room KeyRoom = new Room("The next room through the cracked door", "This room has a shiney key on the floor with a hall leading to the next room");
            Room LockedRoom = new Room("Locked Room", "This room looks locked...");
            Room FinalRoom = new Room("The Final Room", "You found the final room!!");

            Item ShineyKey = new Item("key", "It's shiney!");
            KeyRoom.Items.Add(ShineyKey);
            //setup my exits
            StartingPoint.Exits.Add("east", KeyRoom);
            KeyRoom.Exits.Add("west", StartingPoint);
            KeyRoom.Exits.Add("south", LockedRoom);
            LockedRoom.Exits.Add("west", FinalRoom);
            LockedRoom.Exits.Add("north", KeyRoom);
            FinalRoom.Exits.Add("east", LockedRoom);


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

        }

        public void TakeItem(string itemName)
        {
            Item foundItem = CurrentRoom.Items.Find(item => item.Name == itemName);
            if (foundItem != null)
            {
                CurrentRoom.Items.Remove(foundItem);
                CurrentPlayer.Items.Add(foundItem);
            }
            System.Console.WriteLine(itemName);
        }

        public void UseItem(string itemName)
        {
            System.Console.WriteLine(itemName);
        }

    }
}