using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Pokedex.Data.Repositories;


namespace Pokedex.Data
{
        public class Program
        {
            static void Main(string[] args)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory
                    .GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = config.GetConnectionString("DefaultConnection");

             IDbConnection connection = new SqlConnection(connectionString);
            
                connection.Open();

                var pokemonRepository = new Repositories.PokemonRepository(connection);


            //Returns all pokemon in the database
            /* var pokemon = pokemonRepository.GetAllPokemonInfo();

             foreach (var p in pokemon)
             {
                 Console.WriteLine($"PokemonId: {p.PokemonId} | Name: {p.Name} | HP: {p.HP} | Attack: {p.Attack} | Defense: {p.Defense} |" +
                     $" SpecialAttack: {p.SpecialAttack} | SpecialDefense: {p.SpecialDefense} | Speed: {p.Speed} | Ability: {p.Ability} | Legendary: {p.Legendary} | Region: {p.Region}");
                 Console.WriteLine();
             }
             */


            //Returns up to 25 Pokémon whose name contains the search term.
             var multiplePokemon = pokemonRepository.ReturnPokemonLike("regi");


            Console.WriteLine("Matching Pokémon:");
            foreach (var p in multiplePokemon)
            {
                Console.WriteLine($"PokemonId: {p.PokemonId} | Name: {p.Name} | HP: {p.HP} | Attack: {p.Attack} | Defense: {p.Defense} |"  +
                    $" SpecialAttack: {p.SpecialAttack} | SpecialDefense: {p.SpecialDefense} | Speed: {p.Speed} | Ability: {p.Ability} | Legendary: {p.Legendary} | Region: {p.Region}");
                Console.WriteLine();
            }
            








        }

    }
    }
