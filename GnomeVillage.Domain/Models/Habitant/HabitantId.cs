using GnomeVillage.Domain.Core;

namespace GnomeVillage.Domain
{
   public class HabitantId : IdBase<int>
   {
      public readonly static HabitantId NullHabitantId = new HabitantId(int.MinValue);

      public HabitantId(int value) : base(value)
      {
      }
   }
}
