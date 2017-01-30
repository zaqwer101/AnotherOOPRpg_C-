using System;

namespace AnotherOOPGame
{
	public class Equipment : Item
	{
		Buff stats;
		Creature owner;
		public Equipment(string name, Buff stats)
			: base(name)
		{
			this.name = name;
			this.stats = stats;
		}

		public void setOwner(Creature creature)
		{
			this.owner = creature;
		}

		public Creature getOwner()
		{
			return this.owner;
		}

		public Stats getStats()
		{
			return stats.stats;
		}
	}
}

