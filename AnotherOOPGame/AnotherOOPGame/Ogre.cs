using System;
using System.Collections.Generic;

namespace AnotherOOPGame
{
	public class Ogre : Creature, IEnemy
	{
		public static List<Ogre> ogres = new List<Ogre> ();	
		public Ogre (Location location) 
			:base(location)
		{
			this.isEnemy = true;
			this.__setHp  (location.lvl * 150);
			this.__setDmg (location.lvl * 2);
			this.name = "Ogre" + ogres.Count;
			this.addToInventory (new Item("Голова огра"));
			ogres.Add (this);
		}

		public virtual string AI(Creature hero)
		{
			return attack (hero);
		}


	}
}

