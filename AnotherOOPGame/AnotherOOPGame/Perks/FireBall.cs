using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherOOPGame.Perks
{
	public class FireBall : Perk
	{
		public FireBall(Creature caster) : base(caster)
		{
			this.name = "Огненный всплеск";
			this.manacost = 40;
			this.base_value = 20;
		}

		public override void update()
		{
			value = base_value * lvl + caster.intelligence;
		}

		public override string _use()
		{
			try
			{
				return caster.attack(caster.getTarget(), "magic");
			}
			catch
			{
				return "Не удалось испольовать перк ";
			}
		}
	}
}
