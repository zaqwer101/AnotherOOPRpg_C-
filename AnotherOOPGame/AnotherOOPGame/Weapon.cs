using System;

namespace AnotherOOPGame
{
	public class Weapon : Equipment
	{
		int damage;
		public Weapon (string name, int damage)
			: base(name)
		{
			this.damage = damage;
		}

		public int getDamage()
		{
			return damage;
		}

		public override string ToString ()
		{
			return ("Weapon");
		}
	}
}

