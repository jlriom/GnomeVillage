using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Application.Commands;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using GnomeVillage.Domain;
using GnomeVillage.Domain.Models;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.CommandHandlers
{
   public class DeleteFriendFromHabitantHandler : CommandHandler<DeleteFriendFromHabitantCommand>
   {
      readonly HabitantRemoveFriendValidator habitantRemoveFriendValidator;
      readonly IHabitantRepository habitantRepository;
      readonly IHabitantReadOnlyRepository habitantReadOnlyRepository;

      public DeleteFriendFromHabitantHandler(
         ICommandDispatcher bus, 
         IMapper mapper, 
         ILogger<DeleteFriendFromHabitantCommand> logger, 
         HabitantRemoveFriendValidator habitantRemoveFriendValidator,
         IHabitantReadOnlyRepository habitantReadOnlyRepository,
         IHabitantRepository habitantRepository) : base(bus, mapper, logger)
      {
         this.habitantRemoveFriendValidator = habitantRemoveFriendValidator;
         this.habitantRepository = habitantRepository;
         this.habitantReadOnlyRepository = habitantReadOnlyRepository;
      }

      protected override async Task<Result> HandleEx(DeleteFriendFromHabitantCommand command, CancellationToken cancellationToken = default)
      {

         var habitant = await habitantReadOnlyRepository.GetSingleAsync(new HabitantId(command.HabitantId));

         await habitantRemoveFriendValidator.Validate(habitant, HabitantName.FromString(command.FriendName)).ConfigureAwait(false);

         habitant.Value.Friends.Remove(HabitantName.FromString(command.FriendName));

         await habitantRepository.UpdateAsync(habitant.Value).ConfigureAwait(false);

         return Result.Ok();
      }
   }
}
