using System;
using AdventureGame.Core;

namespace AdventureGame.Cli;

public class Program
{
    public static void Main(string[] args, Maze maze)
    {
        // introduce the game and its objective to the player
        Console.WriteLine("Welcome to the Adventure Game!");
        Console.WriteLine("You are a brave adventurer exploring a mysterious dungeon.");
        Console.WriteLine("Your goal is to defeat the monsters and escape.");
        Console.WriteLine("Good luck!");

        maze.InitializeGrid();
        maze.GenerateMaze(0, 0);
        maze.SetEndTile();
        maze.PlaceItems(1, 1);
        maze.PlaceMonster(2, 2);
        maze.PrintPlayer(0, 0);
        maze.IsWalkable(0, 1);

        // Create a player with 150 health
        Player player = new Player(150);
        player.Move("right", maze);
        player.Move("left", maze);
        player.Move("down", maze);
        player.Move("up", maze);

        // Create some monsters
        Monster goblin = new Monster("Slime", 50);
        // Create some items
        Weapon sword = new Weapon("Sword", 10);
        Potion healthPotion = new Potion("Health Potion", 20);
        // Simulate picking up items
        sword.ApplyEffect(player);
        healthPotion.ApplyEffect(player);
        // Simulate combat
        Console.WriteLine("\nA wild Slime appears!");
        player.Attack(goblin);
        goblin.Attack(player);
        Console.WriteLine("\nGame Over. Thanks for playing!");
    }
}
