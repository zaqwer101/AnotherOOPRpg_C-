using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AnotherOOPGame.Forms
{

	public partial class HeroPerks : Form
	{

		public Creature hero;
		List<EPerk> perks;
		public HeroPerks(Creature hero)
		{

			this.hero = hero;
			InitializeComponent();
		}

		private void Perks_Load(object sender, EventArgs e)
		{

			perks = new List<EPerk>();

			this.Controls.Add(panel1);

			for (int i = 0; i < hero.perks.Count; i++)
			{
				perks.Add(
					new EPerk(
						new Label() { Text = hero.perks[i].name, Location = new Point(0, i * 50) },
						new Label() { Text = hero.perks[i].lvl + "", Location = new Point(150, i * 50) },
						new Button() { Text = "+", Location = new Point(300, i * 50), Name = "button_upgrade" + i }
						)
					);

				panel1.Controls.Add(perks[perks.Count - 1].name);
				panel1.Controls.Add(perks[perks.Count - 1].value);
				panel1.Controls.Add(perks[perks.Count - 1].upgrade);

				panel1.Update();
				Update();
				perks[perks.Count - 1].upgrade.Click += new EventHandler(delegate (object s, EventArgs args)
				{
					MessageBox.Show(hero.upgradePerk(i));
					this.Update();
				});
			}
		}

		class EPerk //Вспомогательный класс
		{
			public Label name, value;
			public Button upgrade;

			public EPerk(Label name, Label value, Button upgrade)
			{
				this.name = name;
				this.value = value;
				this.upgrade = upgrade;
			}
		}
	}
}
