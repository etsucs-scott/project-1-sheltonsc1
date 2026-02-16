using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// creates a class for weapons 
    /// </summary>
    public class Weapon : Item 
    {
        public int AtkDamage { get; set; }
        public Weapon(string name, int damage)
            : base(name, string.Empty, damage) 
        {
            AtkDamage = damage;
            Damage = 10; // Optionally set Item's Damage property
        }

        /// <summary>
        /// applies the weapon's effect to the player and adds it to their inventory
        /// </summary>
        /// <param name="player">the player who receives the weapon</param>
        public override void ApplyEffect(Player player)
        {
            player.Inventory.Add(this);
            Console.WriteLine($"You have picked up {Name}. {Name} added to inventory.");
        }
    }
}
