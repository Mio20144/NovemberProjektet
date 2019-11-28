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

        //när API anropas så skapas två arrayer av Type i Typeslot: en för slot och en för namn
        public TypeSlot[] types;

        public BaseStat[] stats;
        //attack, defense och hp deklareras här så att de kan användas
        public int attack = 0;
        public int defense = 0;
        public int hp = 0;
        
        public void PrintName()
        {
            Console.WriteLine(name);
        }
        //metod som skriver ut namn på alla types
        public void PrintTypes()
        {
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i].type.name);
            }
        }
        //metod som skriver ut stats namn och värden. Använder bara tre stats
        public void PrintStats()
        {
            for (int i = 3; i < stats.Length; i++)
            {
                Console.WriteLine(stats[i].stat.name);
                Console.WriteLine(stats[i].base_stat);
            }
        }
        //ger attack ett värde baserat på API värde på attack
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
        //metod som gör att pokemon kan ta skada beroende på andra pokemons attack
        public void TakeDamage(int attack)
        {

            hp -= attack / (defense / 10);
        }
           
             
        
    }
}
