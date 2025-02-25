using System;

namespace PokemonGottaCatchmAll
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokemon charmander = new Pokemon
            {
                Naam = "Charmander",
                Nummer = 4,
                Type = "Fire",
                HP_Base = 39,
                Attack_Base = 52,
                Defense_Base = 43,
                SpecialAttack_Base = 60,
                SpecialDefense_Base = 50,
                Speed_Base = 65
            };

            Pokemon charmeleon = new Pokemon
            {
                Naam = "Charmeleon",
                Nummer = 5,
                Type = "Fire",
                HP_Base = 58,
                Attack_Base = 64,
                Defense_Base = 58,
                SpecialAttack_Base = 80,
                SpecialDefense_Base = 65,
                Speed_Base = 80
            };

            Pokemon charizard = new Pokemon
            {
                Naam = "Charizard",
                Nummer = 6,
                Type = "Fire/Flying",
                HP_Base = 78,
                Attack_Base = 84,
                Defense_Base = 78,
                SpecialAttack_Base = 109,
                SpecialDefense_Base = 85,
                Speed_Base = 100
            };

            charizard.ShowInfo();
            
            charizard.VerhoogLevel();
            charizard.ShowInfo();
            
 



        }

        
    }
}
