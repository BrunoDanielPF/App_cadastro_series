using System.Collections.Generic;

namespace CRUD_DOTNET.Interfaces
{  
   public interface iRepositorio<T>
   {
       List<T> Lista();
       T RetornaPorId(int id);
       void Insere(T entidade);
       void Exclui(int id);
       void Atualiza(int id, T entidade);
       int ProximoId();
   }
}