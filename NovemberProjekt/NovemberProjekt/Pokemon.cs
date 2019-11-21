using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovemberProjekt
{
    class Pokemon : Character
    {
        public string name;

        public TypeSlot[] types;

        public BaseStat[] stats;
        public int attack = 0;
        public int defense = 0;
        public int hp = 0;
        
        public void PrintName()
        {
            Console.WriteLine(name);
        }

        public void PrintTypes()
        {
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i].type.name);
            }
        }
        public void PrintStats()
        {
            for (int i = 3; i < stats.Length; i++)
            {
                Console.WriteLine(stats[i].stat.name);
                Console.WriteLine(stats[i].base_stat);
            }
        }

        public void GetAttack()
        {
            attack = stats[4].base_stat;
        }
        public void GetDefense()
        {
            defense = stats[3].base_stat;
        }
        public void GetHp()
        {
            hp = stats[5].base_stat;
        }
        public void TakeDamage(int attack)
        {

            hp -= attack / (defense / 10);
        }
           
             
        
    }
}
