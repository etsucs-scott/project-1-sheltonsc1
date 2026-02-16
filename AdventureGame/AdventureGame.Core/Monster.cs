using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// represents a monster in the game, which can attack the player and take damage.
    /// </summary>
    public class Monster : ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Monster(string name, int health)
        {
            Name = name;
            Health = 50;
        }

        /// <summary>
        /// monster's ability to attack any ICharacter target
        /// </summary>
        /// <param name="target"></param>
        public void Attack(ICharacter target)
        {
            target.Attack(this);
        }

        /// <summary>
        /// reduces the monster's health by the specified amount of damage 
        /// </summary>
        /// <param name="damage">amount of damage dealt to the monster</param>
        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Health = Math.Max(0, Health - damage);
                Console.WriteLine($"{Name} took {damage} damage and now has {Health} HP left.");
            }
            Health -= damage;
        }
    }
}
