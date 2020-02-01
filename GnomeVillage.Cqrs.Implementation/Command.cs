using GnomeVillage.Cqrs.Contracts;

namespace GnomeVillage.Cqrs.Implementation
{
   public class Command<T> : ICommand where T : class
   {
      public T Data { get; }

      public Command(T data)
      {
         Data = data;
      }
   }
}
