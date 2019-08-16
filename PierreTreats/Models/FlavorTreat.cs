using System.Collections.Generic;

namespace PierreTreats.Models
{
    public class FlavorTreat
    {
        public int FlavorTreatId {get; set;}

        public string Name {get; set;}

        public virtual Treat Treat {get; set;}

        public virtual Flavor Flavor {get; set;}
        
    }
}