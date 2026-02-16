using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// reoresents the base class of all the items in the game
    /// </summary>
    public abstract class Item
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public int HealingAmount { get; set; }

        public int Damage { get; set; } 

        public Item(string name, string message, int damage)
        {
            Name = name;
            Message = message;
            HealingAmount = 20; // default healing amount
            Damage = damage; // default damage amount
        }

        /// <summary>
        /// applies the item's effect to the player
        /// </summary>
        /// <param name="player">the player who receives the item's effect</param>
        public abstract void ApplyEffect(Player player);
    }
}
