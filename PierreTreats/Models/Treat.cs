using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PierreTreats.Models
{
    public class Treat
    {
        public int TreatId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<FlavorTreat> Flavors { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}