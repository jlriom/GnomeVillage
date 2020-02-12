using GnomeVillage.Domain;
using System.Linq;

namespace GnomeVillage.Application.CommandHandlers
{
   public class HabitantFactory
   {
      public static Habitant CreateFromCommand(Commands.Dto.Habitant habitantCommand)
      {
         var habitant = new Habitant();
         habitant.Name = HabitantName.FromString(habitantCommand.Name);
         habitant.Thumbnail = new System.Uri(habitantCommand.Thumbnail);
         habitant.Age = habitantCommand.Age;
         habitant.Weight = habitantCommand.Weight;
         habitant.HairColor = new HairColor(new HairColorId(habitantCommand.HairColor));

         habitant.Professions = habitantCommand.Professions
            .Select(p => new Profession(new ProfessionId(p))).ToList();

         habitant.Friends = habitantCommand.Friends
            .Select(f => HabitantName.FromString(f)).ToList();

         return habitant;
      }
   }
}
