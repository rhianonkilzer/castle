using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        bool playing = false;


        public void GetUserInput()
        {
            //get that user input stuff
        }

        public void Go(string direction)
        {
            //move the direction to go

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
            CurrentPlayer = new Player();
            //setup rooms
            Room StartingPoint = new Room("Starting Room", "Where you woke up");
            Room KeyRoom = new Room("The next room through the cracked door", "This room has a shiney key on the floor with a hall leading to the next room");
            Room LockedRoom = new Room("Locked Room", "This room looks locked...");
            Room FinalRoom = new Room("The Final Room", "You found the final room!!");

            //setup my exits
            StartingPoint.Exits.Add("West", KeyRoom);
            KeyRoom.Exits.Add("South", LockedRoom);
            LockedRoom.Exits.Add("East", FinalRoom);




        }

        public void StartGame()
        {
            Setup();
            Console.Clear();
            Console.WriteLine("You have just regained conciousness, you're on a cold wet floor of a castle..");
            Console.WriteLine("You look around, and as you get up the floor begins to shake!");
            Console.WriteLine("As you quickly scan the room you notice an endless black hole in the floor to the west, and a cracked open door to the east.");
            Console.WriteLine("Which direction would you like to go? I'd suggest not falling into the hole...");

        }

        public void TakeItem(string itemName)
        {

        }

        public void UseItem(string itemName)
        {

        }

    }
}