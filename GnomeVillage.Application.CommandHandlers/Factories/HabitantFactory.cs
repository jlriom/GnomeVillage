using GnomeVillage.Domain;
using System.Collections.Generic;
using System.Linq;

namespace GnomeVillage.Application.CommandHandlers
{
   public class HabitantFactory
   {
      protected HabitantFactory() { }

      public static Habitant CreateFromCommand(Commands.Dto.Habitant habitantCommand)
      {
         var habitant = new Habitant()
         {
            Name = HabitantName.FromString(habitantCommand.Name),
            Thumbnail = new System.Uri(habitantCommand.Thumbnail),
            Age = habitantCommand.Age,
            Weight = habitantCommand.Weight,
            Height = habitantCommand.Height,
            HairColor = new HairColor(new HairColorId(habitantCommand.HairColor)),
            Professions = habitantCommand.Professions
               .Select(p => new Profession(new ProfessionId(p))).ToList(),
            Friends = new List<HabitantName>()
         };
         return habitant;
      }
   }
}
