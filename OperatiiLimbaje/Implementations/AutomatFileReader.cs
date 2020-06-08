using OperatiiLimbaje.Contracts;
using OperatiiLimbaje.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace OperatiiLimbaje.Implementations
{
    public class AutomatFileReader : IAutomatReader
    {
        public Automat ReadAutomat(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);

            string[] alfabet = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int nrStari = int.Parse(reader.ReadLine());

            int stareInitiala = int.Parse(reader.ReadLine());

            string[] stariTerminaleString = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<int> stariTerminale = new List<int>();
            for (int i = 0; i < stariTerminaleString.Length; i++)
            {
                int stare = int.Parse(stariTerminaleString[i]);

                stariTerminale.Add(stare);
            }

            List<int>[,] functiaDeTranzitie = new List<int>[alfabet.Length, nrStari];
            for (int i = 0; i < alfabet.Length; i++)
            {
                for (int j = 0; j < nrStari; j++)
                {
                    functiaDeTranzitie[i, j] = new List<int>();
                }
            }

            for (int i = 0; i < alfabet.Length; i++)
            {
                for (int j = 0; j < nrStari; j++)
                {
                    string linie = reader.ReadLine();
                    if (linie.Trim().ToLower() == "vid")
                        continue;

                    string[] tokens = linie.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int k = 0; k < tokens.Length; k++)
                    {
                        int stare = int.Parse(tokens[k]);

                        functiaDeTranzitie[i, j].Add(stare);
                    }
                }
            }

            Automat automat = new Automat(nrStari, stareInitiala, alfabet, stariTerminale, functiaDeTranzitie);
            return automat;
        }
    }
}