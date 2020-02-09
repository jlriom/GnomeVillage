using System.Collections.Generic;

namespace GnomeVillage.ReadModel.Contracts.Models
{
    public class Habitant: HabitantBase
   {
        public Habitant()
        {
            Friends = new List<Friend>();
            Professions = new List<Profession>();
        }
       
        public string Thumbnail { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public virtual HairColor HairColor { get; set; }
        public virtual IList<Friend> Friends{ get; set; }
        public virtual IList<Profession> Professions { get; set; }
    }
}
