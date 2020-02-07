using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Models
{
   public class HabitantAddFriendValidator : HabitantBaseValidator
   {

      public HabitantAddFriendValidator() :base( null, null, null)
      {
      }

      public async Task Validate(Maybe<Habitant> habitant, HabitantName friendName)
      {

         if (!habitant.HasValue)
         {
            habitant = Maybe<Habitant>.From(new Habitant());
            habitant.Value.AddBrokenRule("Habitant not found");
         }
         else
         {
            if (habitant.Value.Friends.Contains(friendName))
               habitant.Value.AddBrokenRule("Habitant has this friend yet");
         }
         habitant.Value.Validate("Can not add friend");
         await Task.CompletedTask;
      }
   }
}
