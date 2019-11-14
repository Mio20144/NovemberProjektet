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

            RestClient client = new RestClient("https://pokeapi.co/api/v2/");
           
            Console.WriteLine("Welcome to Pokemon Battler");
            Console.WriteLine("Here you will battle other trainers with four random pokemon");
            Console.WriteLine("Please choose a type of Pokemon, and you will receive a pokemon of that type.");
            
            
            Console.WriteLine("Please enter the name of the Pokemon you wish to use");
            string pokemon = Console.ReadLine();
            pokemon.ToLower();

            RestRequest request = new RestRequest("pokemon/" + pokemon);

            IRestResponse response = client.Get(request);
            Pokemon p1 = JsonConvert.DeserializeObject<Pokemon>(response.Content);
            Console.WriteLine();
            Console.WriteLine("You have choosen to use " + p1.name + " as your Pokemon");
            Console.WriteLine("These are " + p1.name + "'s stats");
            Console.WriteLine("TYPE");
            p1.PrintTypes();
            
            p1.PrintStats();





            
            
            
            







            Console.ReadLine();


        }
    }
}
