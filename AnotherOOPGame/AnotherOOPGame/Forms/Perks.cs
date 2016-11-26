using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherOOPGame.Forms
{

    public partial class Perks : Form
    {
        
        public Creature hero;
        List<EPerk> perks;
        public Perks(Creature hero)
        {
            
            this.hero = hero;
            InitializeComponent();
        }

        private void Perks_Load(object sender, EventArgs e)
        {
            
            perks = new List<EPerk>();
            this.Controls.Add(panel1);
            for (int i=0; i < hero.perks.Count; i++)
            {
                perks.Add(
                    new EPerk(
                        new Label()  { Text = hero.perks[i].name, Location = new Point(0, i * 50) } ,
                        new Label()  { Text = hero.perks[i].lvl + "", Location = new Point(150, i * 50) } , 
                        new Button() { Text = "+", Location = new Point(300, i * 50), Name = "button_upgrade" + i }
                        )
                    );
                panel1.Controls.Add(perks[perks.Count - 1].name);

                panel1.Controls.Add(perks[perks.Count - 1].value);

                panel1.Controls.Add(perks[perks.Count - 1].upgrade);

                panel1.Update();
                this.Update();
                perks[perks.Count - 1].upgrade.Click += new EventHandler(delegate (object s, EventArgs args) 
                {
                    MessageBox.Show(hero.upgradePerk(i));
                    this.Update();
                });
            }
        }

        class EPerk
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
