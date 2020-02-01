using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Application.Commands
{
   public class DeleteHabitantCommand : ICommand
   {
      public DeleteHabitantCommand(string habitantId)
      {
         HabitantId = habitantId;
      }

      public string HabitantId { get; }
   }
}
