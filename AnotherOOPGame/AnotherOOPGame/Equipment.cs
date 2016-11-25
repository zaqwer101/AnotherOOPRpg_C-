using System;

namespace AnotherOOPGame
{
	public class Equipment : Item
	{
		Creature owner;
		public Equipment (string name)
			:base(name)
		{

		}

		public void setOwner(Creature creature)
		{
			this.owner = creature;
		}
		public Creature getOwner()
		{
			return this.owner;
		}


	}
}

