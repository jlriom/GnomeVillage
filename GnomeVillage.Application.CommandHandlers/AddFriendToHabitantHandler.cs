using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Application.Commands;
using GnomeVillage.Cqrs.Contracts;
using GnomeVillage.Cqrs.Implementation;
using GnomeVillage.Domain;
using GnomeVillage.Domain.Core;
using GnomeVillage.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GnomeVillage.Application.CommandHandlers
{
   public class AddFriendToHabitantHandle : CommandHandler<AddFriendToHabitantCommand>
   {
      readonly HabitantAddFriendValidator habitantAddFriendValidator;
      readonly IHabitantRepository habitantRepository;
      readonly IHabitantReadOnlyRepository habitantReadOnlyRepository;

      public AddFriendToHabitantHandle(
         ICommandDispatcher bus, 
         IMapper mapper, 
         ILogger<AddFriendToHabitantCommand> logger, 
         HabitantAddFriendValidator habitantAddFriendValidator,
         IHabitantReadOnlyRepository habitantReadOnlyRepository,
         IHabitantRepository habitantRepository) : base(bus, mapper, logger)
      {
         this.habitantAddFriendValidator = habitantAddFriendValidator;
         this.habitantRepository = habitantRepository;
         this.habitantReadOnlyRepository = habitantReadOnlyRepository;
      }

      protected override async Task<Result> HandleEx(AddFriendToHabitantCommand command, CancellationToken cancellationToken = default)
      {
         
         var habitant = await habitantReadOnlyRepository.GetSingleAsync(new HabitantId(command.HabitantId));

         await habitantAddFriendValidator.Validate(habitant, HabitantName.FromString(command.FriendName)).ConfigureAwait(false);

         habitant.Value.Friends.Add(HabitantName.FromString(command.FriendName));

         await habitantRepository.UpdateAsync(habitant.Value).ConfigureAwait(false);

         return Result.Ok();
      }
   }
}
