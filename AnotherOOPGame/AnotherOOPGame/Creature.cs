using System;
using System.Collections.Generic;

namespace AnotherOOPGame
{
    public class Creature : GameObject
    {
        public List<Buff> buffs;
        Weapon weapon;
        Armor equipment;                                //Доспех - один итем 
        public bool isEnemy = false, isInBattle = false;
        Location location;
        //Ссылка на текущую локацию персонажа
        List<Item> inventory;
        Creature target;

        #region Stats
        public string name;
        float basehp, basedamage;
        int basemana;                                   //базовые значения статов
        float hp, maxhp, damage, armor;                 //Статы(финальные)
        public int strength, agility, intelligence;         //характеристики на основе которых считаются статы 
        int base_strength, base_agility, base_intelligence;
        string hero_class;                              //Класс героя(rogue, warrior, mage)
        public int lvl, exp, exp_to_lvl, mana, maxmana;
        public int lvl_heal, lvl_fire;                         //Уровень прокачки умений
        int free_perks,                                 //Свободные очки перков, которые получаются при получении нового уровня				
            free_stats;                                 //Свободные очки статов, которые получаются при получении нового уровня

        #endregion

        public Creature(string name, Location location, string hero_class)
        {
            this.basehp = 100;
            this.basedamage = 10;
            buffs = new List<Buff>();
            base_strength = 0; base_agility = 0; base_intelligence = 0;
            if (hero_class.Equals("warrior"))
            {
                base_strength = 5;
            }
            if (hero_class.Equals("mage"))
            {
                base_intelligence = 5;
            }
            if (hero_class.Equals("rogue"))
            {
                base_agility = 5;
            }
            strength = base_strength;
            intelligence = base_intelligence;
            agility = base_agility;
            this.hero_class = hero_class;
            basemana = 100;
            this.isEnemy = false;
            equipment = null;
            this.target = null;
            this.lvl = 1;
            this.exp = 0;
            this.exp_to_lvl = 100;
            this.inventory = new List<Item>();
            this.armor = 0;
            this.name = name;
            this.location = location;           //Стартовая локация
            recountStats();
            this.hp = maxhp;
            this.mana = maxmana;
            this.location.addCreature(this);
        }
        public Creature(Location location)
        {
            strength = 0; agility = 0; intelligence = 0;
            basemana = 100; basehp = hp; basedamage = damage;
            equipment = null;
            this.target = null;
            this.location = location;
            this.inventory = new List<Item>();
            this.armor = 0;
            this.location.addCreature(this);
        }

        #region Для конструктора

        public void __setHp(float hp)
        {
            this.maxhp = hp;
            this.hp = hp;
        }

        public void __setDmg(float damage)
        {
            this.damage = damage;
        }

        #endregion

        #region Вывод информации
        public float getMana()
        {
            return this.mana;
        }

        public string getTextInventory()
        {
            string _inventory = "";
            for (int i = 0; i < this.inventory.Count; i++)
            {
                _inventory += this.inventory[i].name + ":" + this.inventory[i].id + "\n";
            }

            return _inventory;
        }
        public Creature getTarget()
        {
            return target;
        }
        public Location getLocation()
        {
            return location;
        }
        public Item[] getInventory()
        {
            return this.inventory.ToArray();
        }
        public float[] getHp()
        {
            return new float[2] { this.hp, this.maxhp };
        }
        public bool isAlive()
        {
            if (this.hp > 0)
                return true;
            else
            {
                return false;
            }
        }
        public string printStats()
        {
            return
                "Name : " + this.name + "\n" +
                "HP   : " + this.hp + "/" + this.maxhp + "\n" +
                "LVL  : " + this.lvl + "\n" +
                "EXP  : " + this.exp + "/" + this.exp_to_lvl + "\n" +
                "DMG  : " + this.damage + "\n" +
                "ARMOR: " + this.armor * 100 + "%" + "\n" +
                "POS  : " + this.location.x + ", " + this.location.y;
        }
        #endregion


        public void selectTarget(Creature creature)
        {
            isInBattle = true;
            this.target = creature;
        }

        public void goToLocation(Location location)
        {
            this.location.removeCreature(this);
            location.addCreature(this);
            this.location = location;
        }

        public string goToDirection(int x_direction, int y_direction)
        {
            if (this.location.x + x_direction >= 0 && this.location.y + y_direction >= 0 &&
                (this.location.x + x_direction) < Location.size_x && (this.location.y + y_direction) < Location.size_y)
            {
                goToLocation(Location.world[this.location.x + x_direction, this.location.y + y_direction]);
                return this.name + " перешел в локацию [" + this.location.x + ", " + this.location.y + "]";
            }
            else
                return "Не удалось перейти в локацию";
        }



        public void addToInventory(Item item)
        {
            this.inventory.Add(item);
        }

        public void removeFromInventory(Item item)
        {
            this.inventory.Remove(item);
        }

        public void takeDamage(float damage)
        {
            this.hp -= damage - damage * this.armor;
        }

        public void Die()
        {
            for (int i = 0; i < inventory.Count; i++)
                location.addItem(inventory[i]);
            this.location.removeCreature(this);
        }

        public string attack(Creature enemy)   //Желательно переделать в виртуальный метод, и для каждого класса существ переопределять отдельно
        {
            target = enemy;
            if (target != null)
            {
                if (target.isAlive())
                {

                    //if (target.isEnemy) {
                    isInBattle = true;
                    float _enemy_hp = target.getHp()[0];  //нужно для расчёта нанесённого урона
                    target.takeDamage(this.damage);
                    if (!target.isAlive())
                    {
                        string _enemy_name = target.name;
                        this.takeExp((int)target.maxhp);
                        target.Die();
                        target = null;
                        isInBattle = false;
                        return this.name + " убил " + _enemy_name;
                    }
                    else
                        return this.name + " нанёс " + Convert.ToInt32(_enemy_hp - target.hp) + " урона по " + target.name;
                    //} else
                    //	return "Невозможно атаковать цель"; Commented: Иначе противник не атакует героя, потому что для него флаг isEnemy не проходит
                }
                else
                    return target.name + " уже мёртв";
            }
            else
                return ("Цель отсутствует");
        }



        public void takeExp(int exp)
        {
            this.exp += exp;
            if (this.exp >= this.exp_to_lvl)
                this.lvlUp();
        }

        public void recountStats()
        {
            strength = base_strength;
            agility = base_agility;
            intelligence = base_intelligence;
            for (int i = 0; i < buffs.Count; i++)
            {
                buffs[i].addStats();
            }
            if (hp == maxhp)
            {
                maxhp = basehp + strength * 10;
                hp = maxhp;
            }
            else
            {
                maxhp = basehp + strength * 10;
            }
            if (mana == maxmana)
            {
                maxmana = basemana + (intelligence * 10);
                mana = maxmana;
            }
            else
            {
                maxmana = basemana + (intelligence * 10);
            }
            if (hero_class.Equals("warrior")) { damage = basedamage + strength * 2; }
            if (hero_class.Equals("rogue")) { damage = basedamage + agility * 2; }
            if (hero_class.Equals("mage")) { damage = basedamage + intelligence * 2; }

            if (hp > maxhp)
                hp = maxhp;
            if (mana > maxmana)
                mana = maxmana;
        }

        public void lvlUp()
        {
            this.exp_to_lvl *= 2;
            this.exp = 0;
            this.lvl++;
            this.damage += 5;
            this.maxhp += 50;
            this.hp = this.maxhp;
            this.maxmana += 50;
            this.mana = maxmana;
            if (lvl % 2 == 0)
            {
                free_perks++;
            }
            free_stats += 3;
            Console.WriteLine(this.name + " поднял свой уровень!");
        }

        #region Взаимодействие с предметами
        public string pickUpItem(Item item)
        {
            if (location.getItems().Contains(item))
            {
                location.removeItem(item);
                addToInventory(item);
                return name + " подобрал " + item.name;
            }
            else
                return "Предмета не существует в локации";
        }

        public string equipArmor(Armor armor)
        {
            if (inventory.Contains(armor))
            {
                if (this.equipment != null)
                {
                    this.unEquipArmor();
                }
                inventory.Remove(armor);
                this.equipment = armor;
                armor.setOwner(this);
                this.armor += armor.getArmor();
                return this.name + " надел " + armor.name;
            }
            else
                return "Такого в инвентаре нет";
        }
        public string unEquipArmor()
        {
            this.equipment.setOwner(null);
            inventory.Add(this.equipment);
            this.armor -= this.equipment.getArmor();
            this.equipment = null;
            return this.name + " снял доспехи";
        }
        public Armor getArmor()
        {
            return equipment;
        }

        public string equipWeapon(Weapon weapon)
        {
            if (inventory.Contains(weapon))
            {
                if (this.weapon != null)
                {
                    unEquipWeapon();
                }
                inventory.Remove(weapon);
                weapon.setOwner(this);
                this.damage += weapon.getDamage();
                return this.name + " надел " + weapon.name;
            }
            else
            {
                return "Такого в инвентаре нет";
            }


        }
        public string unEquipWeapon()
        {
            this.weapon.setOwner(null);
            inventory.Add(this.weapon);
            this.damage -= weapon.getDamage();
            this.weapon = null;
            return this.name + " убрал оружие";
        }
        public Weapon getWeapon()
        {
            return this.weapon;
        }
        #endregion

        public override string ToString()
        {
            return ("Creature");
        }

        public bool hasFreeStats()
        {
            if (this.free_stats > 0)
            { return true; }
            else
            { return false; }
        }

        public int getFreeStats()
        {
            return free_stats;
        }
        public string addStat(int stat)
        {
            if (hasFreeStats())
            {
                this.free_stats--;
                if (stat == 0)
                {
                    base_strength++;
                    recountStats();
                    return "Сила повышена";
                }
                if (stat == 1)
                {
                    base_agility++;
                    recountStats();
                    return "Ловкость повышена";
                }
                if (stat == 2)
                {
                    base_intelligence++;
                    recountStats();
                    return "Интеллект повышен";
                }
                else
                {
                    return "Такой характеристики нет";
                }

            }
            else
                return "Нет свободных очков характеристик";
        }
    }
}

