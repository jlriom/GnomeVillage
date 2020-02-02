using GnomeVillage.Application.Commands.Dto;
using GnomeVillage.Cqrs.Implementation;

namespace GnomeVillage.Application.Commands
{
   public class CreateHabitantCommand : Command<Habitant>
   {
      public CreateHabitantCommand(Habitant habitant) : base(habitant)
      {
      }
   }
}
