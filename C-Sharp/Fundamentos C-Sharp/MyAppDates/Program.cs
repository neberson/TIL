using System;

namespace MyAppDates
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void IniciandoDatas()
        {
            Console.Clear();

            //DateTime é um tipo struct, ou seja é um tipo primitivo que recebe valor e não é apenas uma referencia para o valor
            var data = new DateTime();

            //Now é utilizado para retornar a data atual
            var dataAtual = DateTime.Now;

            //DateTime tem várias construtores, dessa forma podemos iniciar a data já informando os dados no construtor
            //No exemplo abaixo é criado uma data com ano, mês, dia, hora, minuto e segundos
            var dataEspecifica = new DateTime(2023, 06, 21, 8, 23, 14);

            //Com as funções abaixo, é possível recuperar partes especificas da data
            Console.WriteLine(dataEspecifica);
            Console.WriteLine(dataEspecifica.Year);
            Console.WriteLine(dataEspecifica.Month);
            Console.WriteLine(dataEspecifica.Day);
            Console.WriteLine(dataEspecifica.Hour);
            Console.WriteLine(dataEspecifica.Minute);
            Console.WriteLine(dataEspecifica.Second);

            Console.WriteLine(dataEspecifica.DayOfWeek);
            Console.WriteLine(dataEspecifica.DayOfYear);
        }
    }
}