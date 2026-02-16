namespace AdventureGame.Core
{
    /// <summary>
    /// creates a class for the player
    /// </summary>
    public class Player : ICharacter
    {
        public int Health { get; set; }
        public List<Item> Inventory { get; set; }

        /// <summary>
        /// new initialization of the player with a specified health value and an empty inventory.
        /// </summary>
        /// <param name="health"></param>
        public Player(int health)
        {
            Health = 150;
            Inventory = new List<Item>();
        }

        /// <summary>
        /// gives the player the ability to attack an ICharacter
        /// and calculates the damage given to said ICharacter.
        /// </summary>
        /// <param name="target">ICharacter target</param>
        public void Attack(ICharacter target)
        {
            if (target == null)
            {
                int damage = getBestWeaponDamage(GetInventory());
                target.TakeDamage(damage);
            }
        }

        /// <summary>
        /// allows the player to take damage 
        /// and updates the player's health accordingly.
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                Health = Math.Max(0, Health - damage);
                Console.WriteLine($"Player took {damage} damage and now has {Health} HP left.");
            }
            Health -= damage;
        }

        public System.Collections.IEnumerable GetInventory()
        {
            return Inventory;
        }

        /// <summary>
        /// determines the best weapon in the player's inventory.
        /// If no weapons are found, it returns a default damage value of 10.
        /// </summary>
        /// <returns>returns highest weapon damage value</returns>
        public int getBestWeaponDamage(System.Collections.IEnumerable inventory)
        {
            if (Inventory.Count == 0)
            {
                return 10; // default damage if no weapons are in the inventory
            }
            return inventory.OfType<Weapon>().Max(w => w.AtkDamage);
        }

        /// <summary>
        /// picks up an item and applies its effect to the player
        /// </summary>
        /// <param name="item">is the item that gets picked up</param>
        public void PicKUpItem(Item item)
        {
            item.ApplyEffect(this);
        }

        /// <summary>
        /// gives the player the ability to move in a specified direction within the maze
        /// </summary>
        /// <param name="direction">left, right, up, or down</param>
        /// <param name="maze">movement within the maze's perimeter</param>
        public void Move(string direction, Maze maze)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.W)
            {
                direction = "up";
            }
            else if (key == ConsoleKey.S)
            {
                direction = "down";
            }
            else if (key == ConsoleKey.A)
            {
                direction = "left";
            }
            else if (key == ConsoleKey.D)
            {
                direction = "right";
            }
        }


    }
}
