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


        }
    }
}
