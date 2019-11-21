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
            Pokemon p1 = new Pokemon();
            Random generator = new Random();
            RestClient client = new RestClient("https://pokeapi.co/api/v2/");

            Console.WriteLine("Welcome to Pokemon Battler");
            Console.WriteLine("Here you will battle other trainers with four random pokemon");
            Console.WriteLine("Please choose a type of Pokemon, and you will receive a pokemon of that type.");
            Console.WriteLine("Please enter the name of the Pokemon you wish to use");
            string pokemon = Console.ReadLine();
            pokemon.ToLower();

            RestRequest request = new RestRequest("pokemon/" + pokemon);

            IRestResponse response = client.Get(request);
            if (response.IsSuccessful)
            {
                succes = true;
            }

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
            p1 = JsonConvert.DeserializeObject<Pokemon>(response.Content);




            Console.WriteLine();
            Console.WriteLine("You have chosen to use " + p1.name + " as your Pokemon");
            Console.WriteLine("These are " + p1.name + "'s stats");
            Console.WriteLine("TYPE");
            p1.PrintTypes();
            Console.WriteLine();
            p1.PrintStats();
            Console.ReadLine();
            int pokeNumber = generator.Next(1, 808);

            RestRequest enemyRequest = new RestRequest("pokemon/" + pokeNumber);
            IRestResponse enemyResponse = client.Get(enemyRequest);
            Pokemon p2 = JsonConvert.DeserializeObject<Pokemon>(enemyResponse.Content);
            Console.Clear();
            Console.WriteLine("Your enemy will be " + p2.name);
            Console.WriteLine("These are " + p2.name + "'s stats");
            Console.WriteLine("TYPE");
            p2.PrintTypes();
            Console.WriteLine();
            p2.PrintStats();
            Console.ReadLine();
            p1.Attack();
















            Console.ReadLine();


        }
    }
}
