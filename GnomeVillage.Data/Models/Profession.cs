using System.Collections.Generic;

namespace GnomeVillage.Data.Models
{
   public partial class Profession
    {
        public Profession()
        {
            HabitantProfessions = new HashSet<HabitantProfessions>();
        }

        public string Name { get; set; }

        public virtual ICollection<HabitantProfessions> HabitantProfessions { get; set; }
    }
}
