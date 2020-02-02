using GnomeVillage.Application.Commands.Dto;
using GnomeVillage.Cqrs.Implementation;

namespace GnomeVillage.Application.Commands
{
   public class UpdateHabitantCommand : Command<Habitant>
   {
      public string HabitantId { get; }
      public UpdateHabitantCommand(string habitantId, Habitant habitant) : base(habitant)
      {
         HabitantId = habitantId;
      }
   }
}
