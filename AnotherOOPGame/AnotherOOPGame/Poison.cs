using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherOOPGame
{
    class Poison : IPoison
    {
        float damage;
        int duration;
        Creature target;
        string type;
        public Poison(float damage, int duration, Creature target, string type)
        {
            this.damage = damage;
            this.duration = duration;
            this.target = target;
            target.poisons.Add(this);
        }



        public int getDuration()
        {
            return duration;
        }

        public Creature getTarget()
        {
            return target;
        }

        public string poisonAttack()
        {
            float _hp = target.getHp()[0];
            target.takeDamage(damage);
            return target.name + " получил " + (_hp - target.getHp()[0]) + " урона(" + type + ")" ;
        }

        public void remove()
        {
            target.poisons.Remove(this);
        }

        public void update()
        {
            if(duration > 0)
            {
                
            }
        }
    }
}
