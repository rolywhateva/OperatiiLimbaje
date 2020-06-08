using System.Collections.Generic;

namespace OperatiiLimbaje.Contracts
{
    public interface IMultimeService
    {
       List<T> Reuniune<T>(List<T> lista1, List<T> lista2);

        bool Egalitate<T>(List<T> lista1, List<T> lista2);
    }
}