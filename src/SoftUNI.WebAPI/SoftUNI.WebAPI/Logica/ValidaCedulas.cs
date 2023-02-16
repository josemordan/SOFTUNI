using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftUNI.WebAPI.Logica
{
    public class ValidaCedulas
    {
        public bool CedulaValida(string IDENT)
        {
            if (!CedulaNumerica(IDENT)) return false;
            if (IDENT.Length < 11) return false;
            int[] digitCedula = new int[11];
            int[] multiplicadores = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int[] prodcutos = new int[10];
            int acumulado = 0;
            for (int i = 0; i < 11; i++)
                digitCedula[i] = int.Parse(IDENT.Substring(i, 1));
            for (int i = 0; i < 10; i++)
            {
                prodcutos[i] = digitCedula[i] * multiplicadores[i];
                if (prodcutos[i] > 9) prodcutos[i] = prodcutos[i] - 9;
                acumulado += prodcutos[i];
            }
            if (DigitoVerificardor(acumulado) == digitCedula[10]) return true;
            else return false;
        }

        private bool CedulaNumerica(string IDENT)
        {
            try
            {
                long ced = long.Parse(IDENT);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int DigitoVerificardor(int acumulado)
        {
            if (acumulado < 10) return 10 - acumulado;
            else if (acumulado < 20) return 20 - acumulado;
            else if (acumulado < 30) return 30 - acumulado;
            else if (acumulado < 40) return 40 - acumulado;
            else if (acumulado < 50) return 50 - acumulado;
            else if (acumulado < 60) return 60 - acumulado;
            else if (acumulado < 70) return 70 - acumulado;
            else if (acumulado < 80) return 80 - acumulado;
            else return acumulado - 90;
        }
    }
}