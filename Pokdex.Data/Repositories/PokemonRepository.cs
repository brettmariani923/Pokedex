using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Data.SqlClient;

namespace Pokdex.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IDbConnection _connection;
        public PokemonRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public IEnumerable<PokemonInfo> GetAllPokemonInfo()
        {
            return _connection.Query<PokemonInfo>("SELECT * FROM dbo.Pokemon");
        }
        public void AddPokemonInfo(int pokemonId, string name, int hp, int attack, int defense, int speed,
            string ability, bool legendary, string region)

        { _connection.Execute("INSERT INTO dbo.Pokemon (PokemonId, Name, HP, Attack, Defense, Speed, Ability, Legendary, Region) VALUES (@PokemonId, @Name, @HP, @Attack, @Defense, @Speed, @Ability, @Legendary, @Region)", 
            new { PokemonID = pokemonId, Name = name, HP = hp, Attack = attack, Defense = defense, Speed = speed, Ability = ability, Legendary = legendary, Region = region }); }
        public void UpdatePokemonInfo(int pokemonId, string name, int hp, int attack, int defense, int speed, string ability, bool legendary, string region, bool shiny)
        {
            _connection.Execute("UPDATE dbo.Pokemon SET Name = @Name, HP = @HP, Attack = @Attack, Defense = @Defense, Speed = @Speed, Ability = @Ability, Legendary = @Legendary, Region = @Region, Shiny = @Shiny WHERE PokemonId = @PokemonId", 
                new { PokemonID = pokemonId, Name = name, HP = hp, Attack = attack, Defense = defense, Speed = speed, Ability = ability, Legendary = legendary, Region = region, Shiny = shiny });
        }
        public void DeletePokemonInfo(int pokemonId)
        {
            _connection.Execute("DELETE FROM PokemonInfo WHERE PokemonId = @PokemonId", new { pokemonId });
        }
    }
}
