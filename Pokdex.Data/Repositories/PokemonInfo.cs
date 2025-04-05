using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Data.Repositories
{
    public class PokemonInfo
    {
        public int PokemonId {get; set;}
        public required string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public required string Ability { get; set; }
        public bool Legendary { get; set; }
        public required string Region { get; set; }
    }
}
