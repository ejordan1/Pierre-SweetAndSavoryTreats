using System.Collections.Generic;
using System;

namespace PierreTreats.Models
{
    public class Flavor
    {

        public Flavor()
        {
            Treats = new HashSet<FlavorTreat>();
        }
        public int FlavorId { get; set; }

        public string Name { get; set; }

        public ICollection<FlavorTreat> Treats { get; set; }
    }
}