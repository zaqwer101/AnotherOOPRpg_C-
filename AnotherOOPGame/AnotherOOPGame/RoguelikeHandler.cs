using System;
using System.Collections.Generic;

namespace AnotherOOPGame
{
	public class RoguelikeHandler
	{
		List<string> log;
		public static char[,] world;
		public Creature hero;

		public RoguelikeHandler ()
		{
			worldInit ();
		}

		public void worldInit ()
		{
			world = new char[Location.size_x, Location.size_y];
			Location.worldInit ();
            updateWorld();
		}

        public void updateWorld()
        {
            foreach (Location location in Location.world)
            {
                if (location.passable)
                {
                    if (location.creatures.Count > 0)
                    {
                        world[location.x, location.y] = '$';
                        if (location.creatures.Contains(hero))
                        {
                            world[location.x, location.y] = '*';
                        }
                    }
                    else
                    {
                        if (location.creatures.Contains(hero))
                        {
                            world[location.x, location.y] = '*';
                        }
                        else
                        {
                            world[location.x, location.y] = ' ';
                        }
                    }
                }
                else
                {
                    world[location.x, location.y] = '#';
                }
            }
        }

		public void render ()
		{
			for (int i = 0; i < Location.size_y; i++) {
				for (int f = 0; f < Location.size_x; f++) {
					Console.Write (world [i, f]);
				}
				Console.WriteLine ();
			}
		}

		public void handler ()
		{
            updateWorld();
            render();
            ConsoleKeyInfo k = Console.ReadKey (true);
			switch (k.Key) {
			case ConsoleKey.UpArrow:
				hero.goToDirection (0, -1);
				break;
			
			case ConsoleKey.DownArrow:
				hero.goToDirection (0, 1);
				break;

            case ConsoleKey.RightArrow:
                hero.goToDirection(1, 0);
                break;

            case ConsoleKey.LeftArrow:
                hero.goToDirection(-1, 0);
                break;
            }

		}
	}
	
}