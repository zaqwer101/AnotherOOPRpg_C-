using System;
using System.Collections.Generic;

namespace AnotherOOPGame
{
	public class Buff
	{
		public int strength, agility, intelligence,//добавочные статы
		duration; //Сколько ходов осталось действовать
		Creature target;

		public Buff(int strength, int agility, int intelligence, int duration, Creature target)
		{
			this.target 		= target;
			this.agility 		= agility;
			this.strength 		= strength;
			this.intelligence 	= intelligence;
			this.duration 		= duration;
		}

		public void addStats()
		{
			target.agility 		+= this.agility;
			target.strength 	+= this.strength;
			target.intelligence += this.intelligence;
		}

		public void removeStats()
		{
			target.agility 		-= this.agility;
			target.strength 	-= this.strength;
			target.intelligence -= this.intelligence;
		}

		public void update()
		{
			this.duration--;
			if (duration <= 0) {
				removeStats ();
				target.buffs.Remove (this);
				target.recountStats ();
				MainClass.addToLog ("Истекло время действия баффа");
			} else
				target.recountStats ();
		}

	}

}

