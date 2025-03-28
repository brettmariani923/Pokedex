using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Pokdex.Data.Repositories
{
    public interface IPokemonRepository
    {
        public IEnumerable<PokemonInfo> GetAllPokemonInfo();
        public void AddPokemonInfo(int pokemonId, string name, int hp, int attack, int defense, int speed,
            string ability, bool legendary, string region);
        public void UpdatePokemonInfo(int pokemonId, string name, int hp, int attack, int defense, int speed,
            string ability, bool legendary, string region, bool shiny);

        public void DeletePokemonInfo(int pokemonId);
    }
}
