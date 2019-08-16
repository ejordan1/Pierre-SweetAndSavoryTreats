using System.Collections.Generic;
using System;

namespace PierreTreats.Models
{
    public class Flavor
    {
        public int FlavorId {get; set;}

        public string Name {get; set; }

        public ICollection<FlavorTreat> FlavorTreats {get; set;}
    }
}