using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherOOPGame.Perks
{
    public class BaseHeal : Perk
    {
        public BaseHeal(Creature caster) : base(caster)
        {
            name = "Божественное вмешательство";
            this.manacost = 20;
            this.base_value = 20;
        }

        public override void update()
        {
            value = base_value * lvl;
        }

        public override string _use()
        {
            return caster.addHp(value);
        }
    }
}
