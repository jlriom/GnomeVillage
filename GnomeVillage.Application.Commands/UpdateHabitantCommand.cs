using GnomeVillage.Application.Commands.dto;
using GnomeVillage.Cqrs.Implementation;

namespace GnomeVillage.Application.Commands
{
   public class UpdateHabitantCommand : Command<Habitant>
   {
      public UpdateHabitantCommand(Habitant habitant) : base(habitant)
      {
      }
   }
}
