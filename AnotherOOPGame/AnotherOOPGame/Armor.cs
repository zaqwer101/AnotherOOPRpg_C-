using System;

namespace AnotherOOPGame
{
	/// <summary>
	/// Экипировка, увеличивающая защиту цели
	/// </summary>
	public class Armor : Equipment
	{
		float armor;
		public Armor(string name, float armor, Stats stats)
			: base(name, stats)
		{
			this.armor = armor;
		}

		public float getArmor()
		{
			return this.armor;
		}

		public override string ToString()
		{
			return "Armor";
		}
	}
}

