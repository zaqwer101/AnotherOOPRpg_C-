using System;

namespace AnotherOOPGame
{
	public class Equipment : Item
	{
		Buff stats_handler;
		Creature owner;
		public Equipment(string name, Buff stats_handler)
			: base(name)
		{
			this.name = name;
			this.stats_handler = stats_handler;
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
			return stats_handler.stats;
		}
	}
}

