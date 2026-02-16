using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// creates a new class for potions, which are items that can heal the player when used.
    /// </summary>
    public class Potion
    {
        public string Name { get; set; }
        public int HealAmount { get; set; }

        public Potion(string name, int healAmount)
        {
            Name = name;
            HealAmount = healAmount;
        }

        /// <summary>
        /// applies the healing effect to the player
        /// </summary>
        /// <param name="player"></param>
        public void ApplyEffect(Player player) 
        {
            player.Health += HealAmount;
            Console.WriteLine($"You used {Name} and healed for {HealAmount} HP. Your current health is now {player.Health} HP.");
        }
    }
}
