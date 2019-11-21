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

        public void Attack()
        {
            Console.WriteLine(stats[4].base_stat); 
        }
    }
}
