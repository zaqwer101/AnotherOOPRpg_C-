using System;
using System.Collections.Generic;

namespace AnotherOOPGame
{
	public class RoguelikeHandler
	{
		List<string> log;
		public static char[,] world;
		public Creature hero;

		public RoguelikeHandler (Creature hero)
		{
			this.hero = hero;
			worldInit ();
		}

		public void worldInit ()
		{
			world = new char[Location.size_x, Location.size_y];
			Location.worldInit ();
			foreach (Location location in Location.world) {
				if (location.passable) {
					if (location.creatures.Contains (IEnemy)) {
						world [location.x, location.y] = '$';
					} else {
						if (location.creatures.Contains (hero)) {
							world [location.x, location.y] = '*';
						} else {
							world [location.x, location.y] = ' ';
						}
					}
				} else {
					world [location.x, location.y] = '#';
				}
			}
		}

		public void render ()
		{
			for (int y = 0; y < Location.size_y; y++) {
				for (int x = 0; x < Location.size_x; y++) {
					Console.Write (world [x, y]);
				}
				Console.WriteLine ();
			}
		}

		public void handler ()
		{
			ConsoleKeyInfo k = Console.ReadKey (true);
			switch (k.Key) {
			case ConsoleKey.UpArrow:
				hero.goToDirection (0, 1);
				break;
			
			case ConsoleKey.DownArrow:
				hero.goToDirection (0, -1);
				break;
			}
			render ();
		}
		}
	}
}

