using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Application.Commands
{
   public class DeleteHabitantCommand : ICommand
   {
      public DeleteHabitantCommand(int habitantId)
      {
         HabitantId = habitantId;
      }

      public int HabitantId { get; }
   }
}
