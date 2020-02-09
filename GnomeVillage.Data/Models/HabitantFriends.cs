using System;

namespace GnomeVillage.Data.Models
{
   public partial class HabitantFriends
    {
        public Guid Id { get; set; }
        public int HabitantId { get; set; }
        public int FriendId { get; set; }

        public virtual Habitant Friend { get; set; }
        public virtual Habitant Habitant { get; set; }
    }
}
