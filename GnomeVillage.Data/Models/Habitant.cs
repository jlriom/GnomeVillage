using System.Collections.Generic;

namespace GnomeVillage.Data.Models
{
    public partial class Habitant
    {
        public Habitant()
        {
            HabitantFriendsFriend = new HashSet<HabitantFriends>();
            HabitantFriendsHabitant = new HashSet<HabitantFriends>();
            HabitantProfessions = new HashSet<HabitantProfessions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string HairColorId { get; set; }

        public virtual HairColor HairColor { get; set; }
        public virtual ICollection<HabitantFriends> HabitantFriendsFriend { get; set; }
        public virtual ICollection<HabitantFriends> HabitantFriendsHabitant { get; set; }
        public virtual ICollection<HabitantProfessions> HabitantProfessions { get; set; }
    }
}
