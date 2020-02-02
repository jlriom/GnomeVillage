using System;
using System.Collections.Generic;
using System.Text;

namespace GnomeVillage.Domain.Core
{
   public class IdBase<T> 
   {
      private readonly T _value;

      public IdBase(T value)
      {
         _value = value;
      }

      public static implicit operator T(IdBase<T> self) => self._value;
   }
}
