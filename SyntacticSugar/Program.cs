using System;
using System.Collections.Generic;

namespace SyntacticSugar
{
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public ICollection<string> Predators { get; } = new List<string>();
        public ICollection<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName => $"{this.Name} the {this.Species}";
        

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        public string PreyList() => string.Join(",", this.Prey);
        public string PredatorList() => string.Join(",", this.Predators);

   
        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
  
    }
    class Program
    {
        static void Main(string[] args)
        {
            var LadyBug = new Bug("LadyBug", "Ladybird Beetle", new List<string> {"tree frogs", "parasites"}, new List<string> {"dragonflies"} );
          
            Console.WriteLine(LadyBug.Eat("aphids"));
            Console.ReadLine();
        }
    }
}
