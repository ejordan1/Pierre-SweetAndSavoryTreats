using System.Collections.Generic;

namespace PierreTreats.Models
{
    public class Treat
    {

        public Treat ()
        {
            Flavors = new HashSet<FlavorTreat>();
        }
        public int TreatId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<FlavorTreat> Flavors { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}