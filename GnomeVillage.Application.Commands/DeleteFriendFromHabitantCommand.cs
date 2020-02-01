using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Application.Commands
{
   public class DeleteFriendFromHabitantCommand : ICommand
   {
      public DeleteFriendFromHabitantCommand(
         string habitantId,
         string friendName)
      {
         HabitantId = habitantId;
         FriendName = friendName;
      }

      public string HabitantId { get; }
      public string FriendName { get; }
   }
}
