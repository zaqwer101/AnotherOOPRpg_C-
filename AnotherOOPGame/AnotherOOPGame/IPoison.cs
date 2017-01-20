using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherOOPGame
{
    public interface IPoison
    {
        string update();
        string remove();
        int getDuration();
        Creature getTarget();
        string poisonAttack();
    }
}
