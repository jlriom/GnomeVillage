using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Application.Commands
{
   public class DeleteFriendFromHabitantCommand : ICommand
   {
      public DeleteFriendFromHabitantCommand(
         int habitantId,
         string friendName)
      {
         HabitantId = habitantId;
         FriendName = friendName;
      }

      public int HabitantId { get; }
      public string FriendName { get; }
   }
}
