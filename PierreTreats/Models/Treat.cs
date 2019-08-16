using System.Collections.Generic;
using System;

namespace PierreTreats.Models 
{
    public class Treat
    {
        public int TreatId {get; set;}

        public string Name {get; set;}

        public virtual ICollection<FlavorTreat> FlavorTreats {get; set;}
    }
}