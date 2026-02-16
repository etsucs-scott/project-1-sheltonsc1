using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// contract for characters in the adventure game, defining basic actions such as attacking and taking damage.
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// Performs an attack on the specified target character.
        /// </summary>
        /// <param name="target">The character to be attacked. Cannot be null.</param>
        public void Attack (ICharacter target);

        /// <summary>
        /// Reduces the current health by the specified amount of damage.
        /// </summary>
        /// <param name="damage">The amount of damage to apply. Must be a non-negative value.</param>
        public void TakeDamage (int damage);
    }
}
 