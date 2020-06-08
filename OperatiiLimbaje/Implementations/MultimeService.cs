using OperatiiLimbaje.Contracts;
using System.Collections.Generic;

namespace OperatiiLimbaje.Implementations
{
    public class MultimeService :IMultimeService
    {
        public List<T> Reuniune<T>(List<T> lista1, List<T> lista2)
        {
            List<T> reuniune = new List<T>();

            for (int i = 0; i < lista1.Count; i++)
            {
                reuniune.Add(lista1[i]);
            }

            for (int i = 0; i < lista2.Count; i++)
            {
                if (!reuniune.Contains(lista2[i]))
                {
                    reuniune.Add(lista2[i]);
                }
            }

            return reuniune;
        }

        public bool Egalitate<T>(List<T> lista1, List<T> lista2) 
        {
            if(lista1.Count!=lista2.Count)
            {
                return false;
            }

            lista1.Sort();
            lista2.Sort();
            for(int i=0;i<lista1.Count;i++)
            {
                if(!lista1[i].Equals(lista2[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
