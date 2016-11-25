using System;

namespace AnotherOOPGame
{
	public class Armor : Equipment
	{
		float armor;
		public Armor (string name, float armor) 
			: base(name)
		{
			this.armor = armor;
		}

		public float getArmor()
		{
			return this.armor;
		}

		public override string ToString ()
		{
			return "Armor";
		}
	}
}

