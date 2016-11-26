using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherOOPGame
{
    public abstract class Perk
    {
        //Умение имеет какое-то значение, на которое оно действует. Эффективность умения зависит от уровня. Уровень прокачивает само существо за перкпоинты
        public string name;
        public Creature caster, target;
        public int manacost, lvl, base_value, value;
        public Perk(Creature caster)
        {
            this.lvl = 1;
            this.caster = caster;
        }

        public abstract string _use();  // То, что делает перк

        public string use()             // Обработчик для расчёта количества маны и прочего
        {
            update();
            if (caster.mana >= manacost)
                return _use();
            else
                return "Недостаточно маны (" + manacost + ")";
        }

        public abstract void update();
        public void lvlUp()
        {
            lvl++;
            update();
        }
    }
}

