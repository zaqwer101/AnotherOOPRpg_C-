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
    public partial class Battle : Form
    {
        Creature hero;
        public Battle(Creature hero)
        {
            this.hero = hero;
            InitializeComponent();
            
            listBox1.Items.AddRange(hero.getLocation().creatures.ToArray());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsDifferent())
            {
                
            }
        }

        private bool IsDifferent()
        {
            return hero.getLocation().creatures.Where((t, i) => t != listBox1.Items[i]).Any();
            /*
             * 
                for (int i = 0; i < hero.getLocation().creatures.Count; i++) 
                { 
                    if (hero.getLocation().creatures[i] != listBox1.Items[i]) 
                    { 
                    return true; 
                    } 
                } 
                return false;
             */
        }
    }
}
