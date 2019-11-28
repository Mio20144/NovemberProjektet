using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace NovemberProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool succes = false;
            int potion = 2;
            int enemyPotion = 2;
            //anropar Pokemonklassen för att skapa en ny pokemon med tomma värden
            Pokemon p1 = new Pokemon();
            Random generator = new Random();
            //skapar en klient som hämtar information från Pokemon API:n
            RestClient client = new RestClient("https://pokeapi.co/api/v2/");

            Console.WriteLine("Welcome to Pokemon Battler");
            Console.WriteLine("Here you will battle other trainers with four random pokemon");
            Console.WriteLine("Please choose a type of Pokemon, and you will receive a pokemon of that type.");
            Console.WriteLine("Please enter the name of the Pokemon you wish to use");
            string pokemon = Console.ReadLine();
            pokemon.ToLower();

            //skickar en förfrågning till API:n att hämta all information angående spelarens val av pokemon
            RestRequest request = new RestRequest("pokemon/" + pokemon);

            //response innehåller all information från API:n
            IRestResponse response = client.Get(request);
            //om den pokemon man letar efter finns så går spelet vidare
            if (response.IsSuccessful)
            {
                succes = true;
            }
            //om pokemon inte finns får man skriva igen
            while (succes == false)
            {

                Console.WriteLine("Please enter the name of the Pokemon you wish to use");
                pokemon = Console.ReadLine();
                pokemon.ToLower();
                request = new RestRequest("pokemon/" + pokemon);
                response = client.Get(request);

                if (response.IsSuccessful)
                {

                    succes = true;

                }
                
            }
            //omvandlar Json informationen från API till .Net types som programmet kan använda
            p1 = JsonConvert.DeserializeObject<Pokemon>(response.Content);




            Console.WriteLine();
            Console.WriteLine("You have chosen to use " + p1.name + " as your Pokemon");
            Console.WriteLine("These are " + p1.name + "'s stats");
            Console.WriteLine("TYPE");
            //printar ut pokemons type, används inte till något än så länge
            p1.PrintTypes();
            Console.WriteLine();
            //printar ut de stats som ska användas: attack, defense och hp
            p1.PrintStats();
            Console.ReadLine();
            //genererar ett nummer mellan 1-807, antalet pokemon i databasen
            int pokeNumber = generator.Next(1, 808);
            //hämtar information om pokemon med det nummer som slumpas
            RestRequest enemyRequest = new RestRequest("pokemon/" + pokeNumber);
            IRestResponse enemyResponse = client.Get(enemyRequest);
            //skapar en ny pokemon med den informationen som omvandlas av Jsonconverter
            Pokemon p2 = JsonConvert.DeserializeObject<Pokemon>(enemyResponse.Content);
            Console.Clear();
            Console.WriteLine("Your enemy will be " + p2.name);
            Console.WriteLine("These are " + p2.name + "'s stats");
            Console.WriteLine("TYPE");
            p2.PrintTypes();
            Console.WriteLine();
            p2.PrintStats();
            Console.ReadLine();
            
            //först anropas alla get-metoder så att variabler hp, attack och defense får värdet från API
            p1.GetAttack();
            p1.GetDefense();
            p1.GetHp();
            p2.GetAttack();
            p2.GetDefense();
            p2.GetHp();
            //Fighten spelas så länge båda pokemon lever
            while (p1.hp > 0 && p2.hp > 0)
            {
                
                Console.WriteLine("You can attack, or you can heal your Pokemon");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Heal (" + potion + " potions left)");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine(p1.name + " attacks " + p2.name);
                    //metod som gör att pokemons attack är separata
                    p2.TakeDamage(p1.attack);
                    Console.WriteLine(p2.name + " has " + p2.hp + " hp left");
                    Console.ReadLine();
                }
                else if (choice == "2")
                {
                    if (potion > 0)
                    {
                        p1.hp += 20;
                        potion -= 1;
                        Console.WriteLine("You heal your Pokemon for 20 hp");
                    }
                    else
                    {
                        Console.WriteLine("You have no potions left");
                        Console.WriteLine(p1.name + " attacks " + p2.name);
                        //metod som gör att pokemons attack är separata
                        p2.TakeDamage(p1.attack);
                        Console.WriteLine(p2.name + " has " + p2.hp + " hp left");
                        Console.ReadLine();
                    }
                    
                }
                
                if (p2.hp > 0)
                {
                    Console.WriteLine();
                    if (p2.hp > 15 || enemyPotion == 0)
                    {
                        Console.WriteLine(p2.name + " attacks " + p1.name);
                        p1.TakeDamage(p2.attack);
                        Console.WriteLine(p1.name + " has " + p1.hp + " hp left");
                    }
                    else if (p2.hp < 15 && enemyPotion > 0)
                    {
                        p2.hp += 20;
                        enemyPotion -= 1;
                        Console.WriteLine(p2.name + " heals for 20 hp");
                    }
                    
                }
                
            }

            if (p2.hp <= 0)
            {
                Console.Clear();
                Console.WriteLine("Congratulations, " + p1.name + " won the battle");
            }
            
            if (p1.hp <= 0)
            {
                Console.Clear();
                Console.WriteLine("Too bad " + p2.name + " won the battle");

            }
            
            if (p2.hp <= 0 && p1.hp <= 0)
            {
                Console.WriteLine("It's a tie! Nobody wins");
            }















            Console.ReadLine();


        }
    }
}
