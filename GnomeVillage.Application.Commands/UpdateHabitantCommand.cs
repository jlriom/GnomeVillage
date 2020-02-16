using GnomeVillage.Application.Commands.Dtos;
using GnomeVillage.Cqrs.Implementation;

namespace GnomeVillage.Application.Commands
{
   public class UpdateHabitantCommand : Command<Habitant>
   {
      public int HabitantId { get; }
      public UpdateHabitantCommand(int habitantId, Habitant habitant) : base(habitant)
      {
         HabitantId = habitantId;
      }
   }
}
