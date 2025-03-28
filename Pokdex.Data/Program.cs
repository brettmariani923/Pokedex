using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace Pokdex.Data
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

                var pokemon = pokemonRepository.GetAllPokemonInfo();

                foreach (var p in pokemon)
                {
                    Console.WriteLine($"PokemonId: {p.pokemonId} | Name: {p.name} | HP: {p.hp} | Attack: {p.attack} | Defense: {p.defense} |" +
                        $" Speed: {p.speed} | Ability: {p.ability} | Legendary: {p.legendary} | Region: {p.region}");
                }



            }

        }
    }
