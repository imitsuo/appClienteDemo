using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace clientprj.Domain.Util
{
    public static class Cnpj
    {

        public static Boolean ValidaCNPJ(Int64 cnpj)
        {
            return ValidaCNPJ(cnpj.ToString("D14"));
        }


        public static Boolean ValidaCNPJ(string cnpj)
        {
            string new_cnpj = "";


            for (int i = 0; i < cnpj.Length; i++)
            {
                if (isDigito(cnpj.Substring(i, 1)))
                {
                    new_cnpj += cnpj.Substring(i, 1);
                }
            }

            new_cnpj = Convert.ToInt64(new_cnpj).ToString("D14");

            if (new_cnpj.Length > 14)
            {
                return false;
            }


            if (CalculaDigCNPJ(new_cnpj.Substring(0, 12)) == new_cnpj.Substring(12, 2))
            {
                return true;
            }

            return false;
        }

        public static string CalculaDigCNPJ(Int64 cnpj)
        {
            return CalculaDigCNPJ(cnpj.ToString("D12"));
        }

        public static string CalculaDigCNPJ(string cnpj)
        {
            // Declara variaveis para uso
            string new_cnpj = "";
            string digito = "";
            int[] calculo = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Int32 Aux1 = 0;
            Int32 Aux2 = 0;

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cnpj.Length; i++)
            {
                if (isDigito(cnpj.Substring(i, 1)))
                {
                    new_cnpj += cnpj.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CNPJ para 12 digitos completando com zeros a esquerda
            new_cnpj = Convert.ToInt64(new_cnpj).ToString("D12");

            // Caso o tamanho do CNPJ informado for maior que 12 digitos retorna nulo
            if (new_cnpj.Length > 12)
            {
                return null;
            }

            // Calcula o primeiro digito do CNPJ
            Aux1 = 0;

            for (int i = 0; i < new_cnpj.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cnpj.Substring(i, 1)) * calculo[i];
            }

            Aux2 = (Aux1 % 11);

            // Carrega o primeiro digito na variavel digito
            if (Aux2 < 2)
            {
                digito += "0";
            }
            else
            {
                digito += (11 - Aux2).ToString();
            }

            // Adiciona o primeiro digito ao final do CNPJ para calculo do segundo digito
            new_cnpj += digito;

            // Calcula o segundo digito do CNPJ
            calculo = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Aux1 = 0;

            for (int i = 0; i < new_cnpj.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cnpj.Substring(i, 1)) * calculo[i];
            }

            Aux2 = (Aux1 % 11);

            // Carrega o segundo digito na variavel digito
            if (Aux2 < 2)
            {
                digito += "0";
            }
            else
            {
                digito += (11 - Aux2).ToString();
            }

            return digito;
        }

        private static Boolean isDigito(string digito)
        {
            int n;
            return Int32.TryParse(digito, out n);
        }
    }
}