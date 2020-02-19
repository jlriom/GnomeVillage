using GnomeVillage.Application.Commands.Dtos;
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
