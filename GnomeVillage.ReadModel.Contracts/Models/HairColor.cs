using System.Collections.Generic;

namespace GnomeVillage.ReadModel.Contracts.Models
{
    public class HairColor
    {
        public HairColor()
        {
            Habitant = new HashSet<Habitant>();
        }

        public string Name { get; set; }

        public virtual ICollection<Habitant> Habitant { get; set; }
    }
}
