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
            System.Console.WriteLine("Which way would you like to go?");
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
                default:
                    System.Console.WriteLine("Invalid response");
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

        }

        public void Inventory()
        {
            //Buncha junk in this thing here
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
            StartingPoint.Exits.Add("west", KeyRoom);
            KeyRoom.Exits.Add("south", LockedRoom);
            LockedRoom.Exits.Add("east", FinalRoom);

            CurrentPlayer = new Player();
            CurrentRoom = StartingPoint;

        }

        public void StartGame()
        {
            Setup();
            Console.Clear();
            Console.WriteLine("You have just regained conciousness, you're on a cold wet floor of a castle..");
            Console.WriteLine("You look around, and as you get up the floor begins to shake!");
            Console.WriteLine("As you quickly scan the room you notice an endless black hole in the floor to the west, and a cracked open door to the east.");
            Console.WriteLine("I'd suggest not falling into the hole...");

        }

        public void TakeItem(string itemName)
        {
            Item foundItem = CurrentRoom.Items.Find(item => item.Name == itemName);
            if (foundItem != null)
            {

            }
            System.Console.WriteLine(itemName);
        }

        public void UseItem(string itemName)
        {
            System.Console.WriteLine(itemName);
        }

    }
}