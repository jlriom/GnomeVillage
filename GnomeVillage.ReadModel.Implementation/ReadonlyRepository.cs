using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Data;
using GnomeVillage.ReadModel.Contracts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GnomeVillage.ReadModel.Implementation
{
   public abstract class ReadonlyBaseRepository<T, TReadonlyEntity> 
      where T: class
      where TReadonlyEntity : class
   {
      protected readonly DbSet<T> DbSet;
      protected readonly IMapper Mapper;

      protected ReadonlyBaseRepository(GnomeVillageContext context, IMapper mapper)
      {
         DbSet = context.Set<T>();
         Mapper = mapper;
      }

      public virtual async Task<IList<TReadonlyEntity>> GetAllAsync()
      {
         return await Task.FromResult(Mapper.Map<IList<TReadonlyEntity>> (DbSet.ToList()));
      }

      public virtual async Task<Paging<TReadonlyEntity>> GetAsync<TKey>(Func<T, bool> predicate, Func<T, TKey> keySelector, int limit, int offset)
      {
         var entitiesCount = DbSet.Count(predicate);
         var entities = DbSet.Where(predicate).OrderBy(keySelector).Skip(offset).Take(limit).Select(Mapper.Map<TReadonlyEntity>);
         return await Task.FromResult(new Paging<TReadonlyEntity>(entities, limit, offset, entitiesCount));
      }

      public virtual async Task<Maybe<TReadonlyEntity>> FindAsync(params object[] keyValues)
      {
         var entity = await DbSet.FindAsync(keyValues);
         return entity == null ? Maybe<TReadonlyEntity>.From(Mapper.Map<TReadonlyEntity>(entity)) : Maybe<TReadonlyEntity>.None;
      }
   }
}
