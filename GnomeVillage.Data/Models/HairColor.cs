using System.Collections.Generic;

namespace GnomeVillage.Data.Models
{
   public partial class HairColor
    {
        public HairColor()
        {
            Habitant = new HashSet<Habitant>();
        }

        public string Name { get; set; }

        public virtual ICollection<Habitant> Habitant { get; set; }
    }
}
