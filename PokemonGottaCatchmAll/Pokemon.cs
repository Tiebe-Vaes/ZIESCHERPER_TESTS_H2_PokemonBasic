using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonGottaCatchmAll
{
    public class Pokemon
    {
        public int HP_Base { get; set; }
        public int Attack_Base { get; set; }
        public int Defense_Base { get; set; }
        public int SpecialAttack_Base { get; set; }
        public int SpecialDefense_Base { get; set; }
        public int Speed_Base { get; set; }

        public string Naam { get; set; }
        public string Type { get; set; }
        public int Nummer { get; set; }

        public int Level { get; private set; }

        public void VerhoogLevel()
        {
            Level++;
        }

        public double Average => (HP_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefense_Base + Speed_Base) / 6.0;
        public int Total => HP_Base + Attack_Base + Defense_Base + SpecialAttack_Base + SpecialDefense_Base + Speed_Base;

        public int HP_Full => (((HP_Base + 50) * Level) / 50) + 10;
        public int Attack_Full => ((Attack_Base * Level) / 50) + 5;
        public int Defense_Full => ((Defense_Base * Level) / 50) + 5;
        public int SpecialAttack_Full => ((SpecialAttack_Base * Level) / 50) + 5;
        public int SpecialDefense_Full => ((SpecialDefense_Base * Level) / 50) + 5;
        public int Speed_Full => ((Speed_Base * Level) / 50) + 5;

        public void ShowInfo()
        {
            Console.WriteLine($"{Naam} (level {Level})  ");

            Console.WriteLine("Base stats:");

            Console.WriteLine($"     * Health: {HP_Base} ");
            Console.WriteLine($"     * Attack: {Attack_Base} ");
            Console.WriteLine($"     * Defense: {Defense_Base} ");
            Console.WriteLine($"     * Special Attack: {SpecialAttack_Base} ");
            Console.WriteLine($"     * Special Defense: {SpecialDefense_Base} ");
            Console.WriteLine($"     * Speed: {Speed_Base} ");

            Console.WriteLine("Full stats:");
            
            Console.WriteLine($"     * Health: {HP_Full} ");
            Console.WriteLine($"     * Attack: {Attack_Full} ");
            Console.WriteLine($"     * Defense: {Defense_Full} ");
            Console.WriteLine($"     * Special Attack: {SpecialAttack_Full} ");
            Console.WriteLine($"     * Special Defense: {SpecialDefense_Full} ");
            Console.WriteLine($"     * Speed: {Speed_Full} ");

            Console.WriteLine("Average stat: " + Average);
            Console.WriteLine("Total stat: " + Total);

            Console.WriteLine("----------------------------------------------------");
        }
    }
}
