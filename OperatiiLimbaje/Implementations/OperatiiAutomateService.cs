using OperatiiLimbaje.Contracts;
using OperatiiLimbaje.Exceptions;
using OperatiiLimbaje.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OperatiiLimbaje.Implementations
{
    class OperatiiAutomateService : IOperatiiAutomateService
    {
        private IMultimeService multimeService;

        public OperatiiAutomateService(IMultimeService multimeService)
        {
            this.multimeService = multimeService;
        }

        public Automat Produs(Automat automat1, Automat automat2)
        {

            bool acelasiAlfabet = multimeService.Egalitate(automat1.Alfabet.ToList(), automat2.Alfabet.ToList());

            if(!acelasiAlfabet)
            {
                throw new AlfabeteDiferiteException("Alfabetele celor doua automate difera!");
            }

            int stareInitiala = automat1.StareInitiala;

            int nrStari = automat1.NrStari + automat2.NrStari;

            List<int> stariTerminale = Shift(automat2.StariTerminale, automat1.NrStari);

            if (automat2.AcceptaCuvantVid)
            {
                stariTerminale = multimeService.Reuniune(automat1.StariTerminale, stariTerminale);
                stariTerminale.Remove(automat2.StareInitiala+automat1.NrStari);
            }

            List<int>[,] functiaDeTranzitie = new List<int>[automat1.Alfabet.Length, nrStari];

            for (int i = 0; i < automat1.NrStari; i++)
            {
                bool esteStareTerminala = automat1.StariTerminale.Contains(i);

                for (int j = 0; j < automat1.Alfabet.Length; j++)
                {

                    if (esteStareTerminala)
                    {

                        functiaDeTranzitie[j, i] = multimeService.Reuniune(
                                                   automat1.FunctiaDeTranzitie[j, i],
                                                  Shift(automat2.FunctiaDeTranzitie[j, automat2.StareInitiala], automat1.NrStari));

                    }
                    else
                    {
                        functiaDeTranzitie[j, i] = automat1.FunctiaDeTranzitie[j, i];
                    }
                }
            }

            for (int i = automat1.NrStari; i < nrStari; i++)
            {
                for (int j = 0; j < automat1.Alfabet.Length; j++)
                {
                    functiaDeTranzitie[j, i] = automat2.FunctiaDeTranzitie[j, i - automat1.NrStari];

                    functiaDeTranzitie[j, i] = Shift(functiaDeTranzitie[j, i], automat1.NrStari);
                }
            }

            Automat rezultat = new Automat(nrStari, stareInitiala, automat1.Alfabet, stariTerminale, functiaDeTranzitie);
            return rezultat;
        }

        private List<int> Shift(List<int> lista, int valoare)
        {
            int[] temp = lista.ToArray();

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] += valoare;
            }

            return temp.ToList();
        }
    }
}