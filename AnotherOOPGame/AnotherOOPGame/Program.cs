using System;

namespace AnotherOOPGame
{
    class MainClass
    {
        static int right_i = 4;
        public static void writeOnRightSide(string msg)
        {
            Console.SetCursorPosition(50, right_i);
            Console.WriteLine(msg);
            right_i++;
        }

        static void drawHeroStats(Creature hero)
        {
            writeOnRightSide("Информация о герое:");
            writeOnRightSide("\t[0]Сила:       " + hero.strength);
            writeOnRightSide("\t[1]Ловкость:   " + hero.agility);
            writeOnRightSide("\t[2]Интеллект:  " + hero.intelligence);
            writeOnRightSide("\tСвободные очки характеристик:" + hero.getFreeStats());
            right_i = 4;
        }

        static void drawHeroPerks(Creature hero)
        {

        }

        static void drawFightInfo(Creature hero)
        {
            right_i = 4;
            writeOnRightSide("Противник: " + hero.getTarget().name);
            writeOnRightSide("  HP  : " + hero.getTarget().getHp()[0] + "/" + hero.getTarget().getHp()[1]);
            writeOnRightSide("  Мана: " + hero.getTarget().getMana());
            writeOnRightSide("Вещи: ");
            for (int i = 0; i < hero.getTarget().getInventory().Length; i++)
            {
                writeOnRightSide("  " + hero.getTarget().getInventory()[i].name);
            }
            right_i = 4;
        }

        static void drawSelectTarget(Creature hero)
        {
            right_i = 4;
            writeOnRightSide("Выберите цель");
            for (int i = 0; i < hero.getLocation().returnCreatures().Length; i++)
            {
                writeOnRightSide(hero.getLocation().returnCreatures()[i]);
            }
            right_i = 4;
        }

        public static void resetToDefault(Creature hero)
        {
            info = "LocationInfo";
            right_i = 4;
            //updateUI (hero, info);
        }

        public static void choiceItemToPick(Creature hero)
        {
            right_i = 4;
            writeOnRightSide("Выберите предмет:");
            for (int i = 0; i < hero.getLocation().getItems().Count; i++)
            {
                writeOnRightSide("  " + "[" + i + "]" + hero.getLocation().getItems()[i].name);
            }
            right_i = 4;

        }

        public static void choiceDirection()
        {
            right_i = 4;
            writeOnRightSide("Выберите направление:");
            writeOnRightSide("  Q  W  E");
            writeOnRightSide("  A     D");
            writeOnRightSide("  Z  X  C");
            right_i = 4;
        }

        public static void drawLocationInfo(Creature hero)
        {
            right_i = 4;
            for (int i = 0; i < hero.getLocation().returnCreatures().Length; i++)
            {
                writeOnRightSide(hero.getLocation().returnCreatures()[i]);
            }
            for (int i = 0; i < hero.getLocation().returnItems().Length; i++)
            {
                writeOnRightSide(hero.getLocation().returnItems()[i]);
            }
            right_i = 4;
        }

        static void drawInventory(Creature hero)
        {
            right_i = 4;
            writeOnRightSide("Инвентарь героя:");
            for (int i = 0; i < hero.getInventory().Length; i++)
            {
                writeOnRightSide("  [" + i + "]" + hero.getInventory()[i].name);
            }
            right_i = 4;
        }

        public static void updateUI(Creature hero, string action)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write(String.Format("HP: {0}/{6} MANA: {7}/{8} LVL: {1} EXP: {2}/{3} POS: [{4},{5}]", hero.getHp()[0], hero.lvl, hero.exp, hero.exp_to_lvl, hero.getLocation().x, hero.getLocation().y, hero.getHp()[1], hero.mana, hero.maxmana));
            switch (action)
            {

                case "LocationInfo":
                    drawLocationInfo(hero);
                    break;
                case "ChoiceDirection":
                    choiceDirection();
                    break;
                case "FightInfo":
                    drawFightInfo(hero);
                    break;
                case "ChoiceItemToPick":
                    choiceItemToPick(hero);
                    break;
                case "Inventory":
                    drawInventory(hero);
                    break;
                case "SelectTarget":
                    drawSelectTarget(hero);
                    break;
                case "drawHeroStats":
                    drawHeroStats(hero);
                    break;
            }
            Console.SetCursorPosition(0, 4);
            Console.Write(getLog());
        }

        public static string[] log = new string[Console.WindowHeight - 5];
        public static int log_iterator = 0;

        public static void initLog()
        {
            for (int i = 0; i < log.Length; i++)
            {
                log[i] = "";
            }
        }

        public static void addToLog(string msg)
        {
            string[] _log = log;

            if (log_iterator < log.Length)
            {
                log[log_iterator] = msg;
                log_iterator++;
            }
            else
            {
                for (int i = 1; i < log.Length; i++)
                {
                    log[i - 1] = _log[i];
                }
                log[log.Length - 1] = msg;
            }
        }

        public static string getLog()
        {
            string _log = "";
            for (int i = 0; i < log.Length; i++)
            {
                if (log[i] != null && !log[i].Equals(""))
                    _log += log[i] + ".\n";
            }
            return _log;
        }
        static string info = null;
        static void gameHandler(Creature hero)
        {
            ConsoleKeyInfo key;
            while (hero.isAlive())
            {
                right_i = 4;
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.L:
                        {
                            resetToDefault(hero);
                            break;
                        }
                    case ConsoleKey.G:
                        {
                            resetToDefault(hero);
                            choiceDirection();
                            info = "ChoiceDirection";
                            updateUI(hero, info);
                            resetToDefault(hero);
                            ConsoleKeyInfo choice = Console.ReadKey(true);
                            switch (choice.Key)
                            {
                                case ConsoleKey.W: //Вверх
                                    addToLog(hero.goToDirection(0, 1));
                                    break;
                                case ConsoleKey.Q://Вверх влево
                                    addToLog(hero.goToDirection(-1, 1));
                                    break;
                                case ConsoleKey.A://влево
                                    addToLog(hero.goToDirection(-1, 0));
                                    break;
                                case ConsoleKey.Z://вниз влево
                                    addToLog(hero.goToDirection(-1, -1));
                                    break;
                                case ConsoleKey.X://вниз
                                    addToLog(hero.goToDirection(0, -1));
                                    break;
                                case ConsoleKey.C://Вниз вправо
                                    addToLog(hero.goToDirection(1, -1));
                                    break;
                                case ConsoleKey.D://вправо
                                    addToLog(hero.goToDirection(1, 0));
                                    break;
                                case ConsoleKey.E://вверх вправо
                                    addToLog(hero.goToDirection(1, 1));
                                    break;
                                case ConsoleKey.S:
                                    break;
                            }
                            resetToDefault(hero);
                            break;
                        }  //end of case
                    case ConsoleKey.T:
                        {
                            resetToDefault(hero);
                            info = "SelectTarget";
                            updateUI(hero, info);
                            int choice_target = Convert.ToInt32(Console.ReadLine());
                            hero.selectTarget(hero.getLocation().creatures[choice_target]);
                            addToLog(hero.name + " выбрал целью " + hero.getLocation().creatures[choice_target].name);
                            resetToDefault(hero);
                            right_i = 4;
                            updateUI(hero, info);
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            addToLog(hero.attack(hero.getTarget()));
                            if (hero.isInBattle && hero.getTarget() != null)
                            {
                                info = "FightInfo";
                            }
                            else
                            {
                                resetToDefault(hero);
                            }
                            break;
                        }
                    case ConsoleKey.P:
                        {
                            info = "ChoiceItemToPick";
                            updateUI(hero, info);
                            int item = Convert.ToInt32(Console.ReadLine());
                            addToLog(hero.pickUpItem(hero.getLocation().getItems()[item]));
                            resetToDefault(hero);
                            break;
                        }
                    case ConsoleKey.I:
                        {
                            info = "Inventory";
                            updateUI(hero, info);
                            right_i = 4;
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            info = "drawHeroStats";
                            updateUI(hero, info);
                            break;
                        }
                    case ConsoleKey.U:
                        {
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.S:
                                    addToLog("Выберите характеристику для улучшения");
                                    updateUI(hero, "drawHeroStats");
                                    string choice = Console.ReadLine();
                                    addToLog(hero.addStat(Convert.ToInt32(choice)));
                                    break;
                            }
                            break;
                        }
                } //end of switch
                for (int i = 0; i < hero.getLocation().creatures.Count; i++)
                {
                    if (hero.getLocation().creatures[i].isEnemy)
                        addToLog(((IEnemy)(hero.getLocation().creatures[i])).AI(hero));
                }
                for (int i = 0; i < hero.buffs.Count; i++)
                {
                    hero.buffs[i].update();
                }
                updateUI(hero, info);
            }
            Console.WriteLine("Лол ты сдох");
        }

        /*static public void testHandler()
		{
			Location.worldInit ();

			Creature hero = new Creature ("Hero", 100, 5, Location.world[0,0]);
			hero.addToInventory (new Item("Бабулех"		 ));
			hero.addToInventory (new Item ("Сладкий хлеб"));
			hero.addToInventory(new Armor("Доспехи веры", 0.5f));
			Location.world [0, 0].addItem (new Item("Штука, лежащая в локации"));

			Console.WriteLine (hero.printStats());
			Console.WriteLine (hero.getTextInventory ());
			while(true)
			{
				ConsoleKeyInfo key;
				key = Console.ReadKey (true);
				switch ( key.Key ) {
				case ConsoleKey.A:
					{
						Console.WriteLine (hero.attack (hero.getTarget ()));
						break;
					}
				case ConsoleKey.S:
					{
						Console.WriteLine (hero.printStats ());
						break;
					}
				case ConsoleKey.M:
					{
						Console.Write ("M+");
						ConsoleKeyInfo _key = Console.ReadKey ();
						Console.WriteLine ();
						if (_key.Key == ConsoleKey.S)
						if (hero.getTarget () != null) {
							Console.WriteLine (hero.getTarget ().printStats ());
						}
						break;
					}
				case ConsoleKey.L:
					{
						Console.WriteLine ("Существа в локации: ");
						Console.WriteLine ("  " + hero.getLocation().returnCreatures ());
						Console.WriteLine ("Вещи в локации: ");
						Console.WriteLine ("  " + hero.getLocation().returnItems ());
						break;
					}
				case ConsoleKey.T:
					{
						Console.WriteLine ("Выберите цель:");
						for (int i = 0; i < hero.getLocation ().creatures.Count; i++) {
							Console.WriteLine ("  " + i + "  " + hero.getLocation ().creatures [i].name + " " + (int)hero.getLocation ().creatures [i].getHp ());
						}
						hero.selectTarget (hero.getLocation ().creatures [Convert.ToInt32 (Console.ReadLine ())]);
						break;
					}
				case ConsoleKey.I:
					{
						Console.WriteLine ("Инвентарь: ");
						for (int i = 0; i < hero.getInventory ().Length; i++) {
							Console.Write ("  " + hero.getInventory () [i].name + "; ");
						}
						break;
					}
				case ConsoleKey.P:
					{
						Console.WriteLine ("Выберите предмет");
						for (int i = 0; i < hero.getLocation ().getItems ().Count; i++) {
							Console.WriteLine ("  " + i + "  " + hero.getLocation ().getItems () [i].name);
						}
						int choice = Convert.ToInt32 (Console.ReadLine ());
						hero.pickUpItem (hero.getLocation ().getItems () [choice]);
						break;
					}
				case ConsoleKey.G:
					{
						Console.WriteLine ("Выберите направление");
						ConsoleKeyInfo choice = Console.ReadKey (true);
						switch (choice.Key) {
						case ConsoleKey.W:
							{
								Console.WriteLine(hero.goToDirection (0, 1));
								break;
							}
						case ConsoleKey.S:
							{
								Console.WriteLine(hero.goToDirection (0, -1));
								break;
							}
						case ConsoleKey.A:
							{
								Console.WriteLine(hero.goToDirection (-1, 0));
								break;
							}
						case ConsoleKey.D:
							{
								Console.WriteLine(hero.goToDirection (1, 0));
								break;
							}
						}
						break;
					}
					case ConsoleKey.E:
						{
							Console.WriteLine("Выберите предмет для надевания");
							for(int i=0;i<hero.getInventory().Length;i++)
							{
							if(hero.getInventory()[i].ToString().Equals("Armor"))
								{
									Console.WriteLine("  " + i + " " + hero.getInventory()[i].name);
								}
							}
						int choice = Convert.ToInt32(Console.ReadLine());
						try
						{
							Console.WriteLine (hero.equipArmor(((Armor)hero.getInventory()[choice])));
						}
						catch
						{
							Console.WriteLine ("Ошибка при экипировании брони");
						}
						break;
						}
				case ConsoleKey.U:
					{
						try {
							Console.WriteLine (hero.unEquipArmor ());
						} catch {
							Console.WriteLine ("Ошибка при снятии брони");
						}
						break;
					}
				}
				for (int i = 0; i < hero.getLocation ().creatures.Count; i++) {
					if (hero.getLocation ().creatures [i].isEnemy) {
							Console.WriteLine(((IEnemy)hero.getLocation ().creatures [i]).AI(hero));
					}
				}
			}
		} */   //Тестовый обработчик. Больше не нужен 

        public static void Main(string[] args)
        {

            //testHandler ();
            //Console.BackgroundColor = ConsoleColor.Blue;
            initLog();
            Console.Clear();
            Location.worldInit();
            Location.world[2, 2].addItem(new Item("Деревянный дилдо")); 
            Creature hero = new Creature("Hero", Location.world[0, 0], "warrior");
            hero.buffs.Add(new Buff(10, 10, 10, 5, hero));
            hero.takeDamage(100);
            hero.perks.Add(new Perks.BaseHeal(hero));
            addToLog(hero.perks[0].use());
            addToLog(hero.perks[0].use());
            addToLog(hero.perks[0].use());
            addToLog(hero.perks[0].use());
            addToLog(hero.perks[0].use());
            addToLog(hero.perks[0].use());
            addToLog(hero.perks[0].use());
            addToLog(hero.perks[0].use());
            addToLog(hero.perks[0].use());
            addToLog(hero.perks[0].use());
            gameHandler(hero);
        }
    }
}
