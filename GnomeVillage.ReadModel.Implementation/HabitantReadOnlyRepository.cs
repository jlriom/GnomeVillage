﻿using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Data;
using GnomeVillage.ReadModel.Contracts;
using GnomeVillage.ReadModel.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GnomeVillage.ReadModel.Implementation
{
   public class HabitantReadOnlyRepository : ReadonlyBaseRepository<Data.Models.Habitant, Habitant>, IHabitantReadOnlyRepository
   {

      public HabitantReadOnlyRepository(GnomeVillageContext context, IMapper mapper) : base(context, mapper)
      {
      }

      public async Task<Paging<Habitant>> GetAsync(int limit, int offset)
      {
         var habitants = await base.GetAsync(h => h.HairColor,    habitant => true, h => h.Name, limit, offset).ConfigureAwait(false);
         return habitants;
      }

      public async Task<Maybe<Habitant>> GetSingleAsync(int habitantId)
      {

         var habitant = await DbSet
            .Include(h => h.HairColor)
            .Include(h => h.HabitantProfessions)
            .ThenInclude(p => p.Profession)
            .Include(h => h.HabitantFriendsHabitant)
            .ThenInclude(p => p.Friend)
            .FirstOrDefaultAsync(h => h.Id == habitantId);

         if (habitant != null)
         {
            return Maybe<Habitant>.From(Mapper.Map<Habitant>(habitant));
         }

         return Maybe<Habitant>.None;
      }
   }
}
