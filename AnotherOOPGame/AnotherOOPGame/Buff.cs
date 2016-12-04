using System;
using System.Collections.Generic;

namespace AnotherOOPGame
{
	public class Buff
	{
        public Stats stats;  //Добавочные статы
		public int duration; //Сколько ходов осталось действовать
		Creature target;     //Цель добавления статов

		public Buff(Stats stats, int duration,Creature target)
		{
            this.stats                  = stats;
			this.target 		        = target;
			this.duration 		        = duration;
		}

		public void addStats()
		{
			target.agility 		+= this.stats.agility;
			target.strength 	+= this.stats.strength;
			target.intelligence += this.stats.intelligence;
		}

		public void removeStats()
		{
			target.agility 		-= this.stats.agility;
			target.strength 	-= this.stats.strength;
			target.intelligence -= this.stats.intelligence;
		}

		public void update()
		{
			this.duration--;
			if (duration == 0) {
				removeStats ();
				target.buffs.Remove (this);
				target.recountStats ();
				MainClass.addToLog ("Истекло время действия баффа");
			} else
				target.recountStats ();
		}

	}

}

