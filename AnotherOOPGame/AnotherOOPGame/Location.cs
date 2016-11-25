using System;
using System.Collections.Generic;

namespace AnotherOOPGame
{
	public class Location
	{
		public static int size_x = 20, size_y = 20;
		public static Location[,] world = new Location[size_x,size_y];

		public static void worldInit()
		{
			for (int i = 0; i < size_y; i++) {
				for (int f = 0; f < size_x; f++) {
					world [i, f] = new Location (i, f);
					if (world [i, f].lvl != 0)
						//world [i, f].addCreature (new Ogre (world [i, f])); 
						new Ogre(world [i, f]);
				}
			}
		}						   //Сотворение мира и население его существами (Ограми)

		public int x, y, lvl;
		List<Item> items; 										//Итемы, лежащие в локации
		public List<Creature> creatures; 						//Существа, стоящие в локации
		public Location (int x, int y)
		{
			this.items = new List<Item>();
			this.creatures = new List<Creature> ();
			this.x = x;
			this.y = y;
			this.lvl = Convert.ToInt32(Math.Floor( (double)((x + y) / 2) )); //Формула временная
		}
		public void addItem(Item item)
		{
			this.items.Add (item);
		}

		public void removeItem(Item item)
		{
			this.items.Remove (item);
		}

		public string[] returnItems()
		{
			List<string> _items = new List<string>();
			_items.Add ("предметы в локации:");
			for (int i = 0; i < items.Count; i++) {
				_items.Add("  " + items[i].name + "; ");
			}
			return _items.ToArray();
		}

		public void addCreature(Creature creature)
		{
			this.creatures.Add (creature);
		}

		public void removeCreature(Creature creature)
		{
			this.creatures.Remove (creature);
		}

		public string[] returnCreatures()
		{
			List<string> _creatures = new List<string> ();
			_creatures.Add ("Существа в локации: ");
			for (int i = 0; i < creatures.Count; i++) {
				_creatures.Add("  " + "[" + i + "]" + creatures [i].name + "(" + Convert.ToInt32(creatures[i].getHp()[0]) + "); ");
			}
			return _creatures.ToArray();
		}

		public List<Item> getItems()
		{
			return items;
		}
	}
}

