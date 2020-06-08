using System.Collections.Generic;
using System.Text;

namespace OperatiiLimbaje.Models
{
    public class Automat
    {
        private int nrStari, stareInitiala;
        private string[] alfabet;
        private List<int> stariTerminale;
        private List<int>[,] functiaDeTranzitie;

        public int NrStari { get => nrStari; }

        public int StareInitiala { get =>stareInitiala; }

        public string[] Alfabet { get => alfabet; }

        public List<int> StariTerminale { get => stariTerminale; }

        public List<int>[,] FunctiaDeTranzitie { get => functiaDeTranzitie; }

        public Automat(int nrStari, int stareInitiala, string[] alfabet, List<int> stariTerminale, List<int>[,] functiaDeTranzitie)
        {
            this.nrStari = nrStari;
            this.stareInitiala = stareInitiala;
            this.alfabet = alfabet;
            this.stariTerminale = stariTerminale;
            this.functiaDeTranzitie = functiaDeTranzitie;
        }
        public bool AcceptaCuvantVid
        {
            get
            {
                return StariTerminale.Contains(stareInitiala);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Nr de stari :" + nrStari + "\n");
            sb.Append("Alfabet:" + string.Join(",", alfabet) + "\n");
            sb.Append("Stari terminale:" + string.Join(",", stariTerminale) + "\n");
            sb.Append("Functia de tranzitie:\n");

            for (int i = 0; i < alfabet.Length; i++)
            {
                for (int j = 0; j < nrStari; j++)
                {
                    string stariRezultate = "";

                    if (functiaDeTranzitie[i,j].Count > 1)
                    {
                        stariRezultate = $"s{j} prin '{alfabet[i]}' devine :" + string.Join(",", functiaDeTranzitie[i,j]);
                    }
                    else
                        if (functiaDeTranzitie[i,j].Count == 1)
                        {
                            stariRezultate = $"s{j} prin '{alfabet[i]}' devine :" + functiaDeTranzitie[i,j][0];
                        }
                        else
                        {
                            stariRezultate = $"s{j} prin '{alfabet[i]}' devine : multimea vida";
                        }

                    sb.Append(stariRezultate + "\n");
                }
            }

            return sb.ToString();
        }
    }
}
