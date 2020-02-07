using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Application.Commands
{
   public class AddFriendToHabitantCommand : ICommand
   {
      public AddFriendToHabitantCommand(
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
