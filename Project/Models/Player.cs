using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string PlayerName { get; set; } = "Bob";
        public List<Item> Inventory { get; set; }


        // public Item PickupItem(string itemName)
        // {

        //         return Items.Find(i => i.Name == itemName);

        // }
    }


}