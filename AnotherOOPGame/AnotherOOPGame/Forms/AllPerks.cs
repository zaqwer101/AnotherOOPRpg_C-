using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace AnotherOOPGame
{
	public partial class AllPerks : Form
	{
		Creature hero;
		List<Perk> perks;

		public AllPerks(Creature hero)
		{
			perks = new List<Perk>
			{
			new Perks.FireBall(hero), new Perks.BaseHeal(hero)
			};
			this.hero = hero;
			Panel panel1 = new Panel();
			Controls.Add(panel1);
			//Дальше на панель накидать перков, которые есть в списке, но нет у существа
		}
	}

	class EPerk //Вспомогательный класс
	{
		public Label name;
		public Button buy;

		public EPerk(Label name, Button buy)
		{
			this.name = name;
			this.buy = buy;
		}
	}
}
