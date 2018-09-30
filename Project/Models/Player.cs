using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string PlayerName { get; set; } = "Bob";
        public List<Item> Items { get; set; }


    }


}