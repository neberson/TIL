using System;

namespace MyAppMoedas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            TiposParaMoedas();
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
    }
}