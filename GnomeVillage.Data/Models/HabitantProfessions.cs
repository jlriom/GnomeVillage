using System;

namespace GnomeVillage.Data.Models
{
   public partial class HabitantProfessions
    {
        public Guid Id { get; set; }
        public int HabitantId { get; set; }
        public string ProfessionId { get; set; }

        public virtual Habitant Habitant { get; set; }
        public virtual Profession Profession { get; set; }
    }
}
