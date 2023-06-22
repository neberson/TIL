using System;
using System.Globalization;

namespace MyAppMoedas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //TiposParaMoedas();
            FormatandoMoedas();
        }

        static void TiposParaMoedas()
        {
            // Cria com formato double
            var valor = 10.25;
            Console.WriteLine(valor);

            //É o mais indicado por causa da precisão, mas tem que ser analisado o tamanho do dado
            decimal valorDecimal = 1000.80M;
            Console.WriteLine(valorDecimal);
        }

        static void FormatandoMoedas()
        {

            decimal valor = 10.25m;
            Console.WriteLine(valor.ToString(CultureInfo.CreateSpecificCulture("en-US")));

            Console.WriteLine(valor.ToString(
                "G", //Formato númerico padrão
                CultureInfo.CreateSpecificCulture("en-US")));

            Console.WriteLine(valor.ToString(
                "C", //Formata com o simbolo da moeda
                CultureInfo.CreateSpecificCulture("pt-BR")));

            Console.WriteLine(valor.ToString(
                "P", //Formata com sinal de porcentagem
                CultureInfo.CreateSpecificCulture("pt-BR")));
        }
    }
}