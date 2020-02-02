using GnomeVillage.Domain.Core;

namespace GnomeVillage.Domain
{
   public class HabitantName: ValueObject<HabitantName>
   { 
      public string Value { get; }
      internal HabitantName(string value) => Value = value;

      public static implicit operator string(HabitantName name) => name.Value;


      public static HabitantName FromString(string title)
      {
         return new HabitantName(title);
      }
   }
}
