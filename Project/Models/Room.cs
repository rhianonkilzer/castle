using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits { get; set; }
        public bool Locked { get; set; }
        public bool GameOver { get; set; }


        public Room(string name, string description, bool locked, bool gameover)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<string, Room>();
            Items = new List<Item>();
            Locked = locked;
            GameOver = GameOver;

        }
    }

}