using AutoMapper;
using CSharpFunctionalExtensions;
using GnomeVillage.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GnomeVillage.Domain.Implementation
{
   public abstract class Repository<T, TKey, TDomainEntity, TDomainEntitykey>
      where T : class
      where TDomainEntity : class
   {
      protected readonly DbSet<T> DbSet;
      protected readonly GnomeVillageContext Context;
      protected readonly IMapper Mapper;

      protected Repository(GnomeVillageContext context, IMapper mapper)
      {
         this.Context = context;
         DbSet = this.Context.Set<T>();
         Mapper = mapper;
      }

      public virtual async Task<IList<TDomainEntity>> GetAllAsync()
      {
         return await Task.FromResult(Mapper.Map<IList<TDomainEntity>>(DbSet.ToList()));
      }

      public virtual async Task<IEnumerable<TDomainEntity>> GetAsync(Func<T, bool> predicate)
      {
         var entities = DbSet.Where(predicate).Select(Mapper.Map<TDomainEntity>);
         return await Task.FromResult(entities);
      }

      public virtual async Task<Maybe<TDomainEntity>> FindAsync(TDomainEntitykey keyValue)
      {
         var entity = await DbSet.FindAsync(Mapper.Map<TKey>(keyValue));
         return entity == null
            ? Maybe<TDomainEntity>.None
            : Maybe<TDomainEntity>.From(Mapper.Map<TDomainEntity>(entity));
      }

      public async Task<TDomainEntity> DeleteAsync(TDomainEntity domainEntity)
      {
         DbSet.Remove(Mapper.Map<T>(domainEntity));
         await Context.SaveChangesAsync().ConfigureAwait(false);
         return domainEntity;
      }

      public virtual async Task<TDomainEntity> InsertAsync(TDomainEntity domainEntity)
      {
         var entity = Mapper.Map<T>(domainEntity);
         DbSet.Add(entity);
         await Context.SaveChangesAsync().ConfigureAwait(false);
         return domainEntity;
      }

      public async Task<TDomainEntity> UpdateAsync(TDomainEntity domainEntity)
      {
         DbSet.Update(Mapper.Map<T>(domainEntity));
         await Context.SaveChangesAsync().ConfigureAwait(false);
         return domainEntity;
      }
   }
}
