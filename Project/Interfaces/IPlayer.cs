using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public interface IPlayer
    {
        string PlayerName { get; set; }
        List<Item> Items { get; set; }
    }

    // public class Item
    // {
    // }
}