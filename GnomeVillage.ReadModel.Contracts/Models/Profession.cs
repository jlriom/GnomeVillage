using System.Collections.Generic;

namespace GnomeVillage.ReadModel.Contracts.Models
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
