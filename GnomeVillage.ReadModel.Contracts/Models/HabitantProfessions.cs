using System;

namespace GnomeVillage.ReadModel.Contracts.Models
{
    public class HabitantProfessions
    {
        public Guid Id { get; set; }
        public int HabitantId { get; set; }
        public string ProfessionId { get; set; }

        public virtual Habitant Habitant { get; set; }
        public virtual Profession Profession { get; set; }
    }
}
