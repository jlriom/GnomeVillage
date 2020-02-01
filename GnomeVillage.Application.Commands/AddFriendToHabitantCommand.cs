using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Application.Commands
{
   public class AddFriendToHabitantCommand : ICommand
   {
      public AddFriendToHabitantCommand(
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
