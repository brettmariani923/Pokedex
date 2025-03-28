using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokdex.Data.Repositories
{
    public class PokemonInfo
    {

        public int pokemonId {get; set;}
        public string name { get; set; }
        public int hp { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int speed { get; set; }
        public string ability { get; set; }
         
        public bool legendary { get; set; }
        public string region { get; set; }
    }
}
