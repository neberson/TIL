using System;
using System.Globalization;

namespace MyAppDates
{
    class Program
    {
        static void Main(string[] args)
        {
            //IniciandoDatas();
            //FormatandoDatas();
            //AdicionandoValores();
            //CompararDatas();
            //EstudoCultureInfo();
            //EstudoTimeZone();
            TimeSpan();
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

        static void FormatandoDatas()
        {
            var data = DateTime.Now;

            var formatada = String.Format("{0:dd/MM/yyyy hh:mm:ss ff}", data);

            Console.WriteLine(formatada);
            //Apenas com um t minusculo formata para um ShortTime hh:mm
            formatada = String.Format("{0:t}", data);
            Console.WriteLine(formatada);

            //Apenas com um d minusculo formata para um Date yyyy-MM-dd
            formatada = String.Format("{0:d}", data);
            Console.WriteLine(formatada);

            //Apenas com um T maiúsculo formata para um tempo longo hh:mm:ss
            formatada = String.Format("{0:T}", data);
            Console.WriteLine(formatada);

            //Apenas com um D maiúsculo formata para uma data por extenso
            formatada = String.Format("{0:D}", data);
            Console.WriteLine(formatada);
        }
        static void AdicionandoValores()
        {
            var data = DateTime.Now;
            Console.WriteLine(data);
            Console.WriteLine(data.AddDays(12));
            Console.WriteLine(data.AddMonths(1));
            Console.WriteLine(data.AddYears(1));

        }
        static void CompararDatas()
        {
            var data = DateTime.Now;

            //Para comparar datas pode ser utilizado os operadores comuns de comparação para outros tipos struct
            //obs.: Para datas será comparada toda a estrutura da data
            if (data.Date == DateTime.Now.Date)
                Console.WriteLine("É igual");

            if (data.Date > DateTime.Now.Date)
                Console.WriteLine("É maior");

            if (data.Date < DateTime.Now.Date)
                Console.WriteLine("É menor");

            Console.WriteLine(data);
        }
        static void EstudoCultureInfo()
        {
            var pt = new CultureInfo("pt-PT");
            var br = new CultureInfo("pt-BR");
            var en = new CultureInfo("en-US");
            var de = new CultureInfo("de-DE");
            var atual = CultureInfo.CurrentCulture;

            Console.WriteLine(DateTime.Now.ToString("D", en));
        }
        static void EstudoTimeZone()
        {
            var utcDate = DateTime.UtcNow;

            Console.WriteLine(utcDate);
            Console.WriteLine(utcDate.ToLocalTime());

            var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
            Console.WriteLine(timezoneAustralia);

            var horaAustralia = TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezoneAustralia);
            Console.WriteLine(horaAustralia);

            var timezones = TimeZoneInfo.GetSystemTimeZones();

            foreach (var timezone in timezones)
            {
                Console.WriteLine(timezone.Id);
                Console.WriteLine(timezone);
                Console.WriteLine(TimeZoneInfo.ConvertTimeFromUtc(utcDate, timezone));
                Console.WriteLine("______________");
            }

        }
        static void TimeSpan()
        {
            var TimeSpan = new TimeSpan();
            Console.WriteLine(TimeSpan);

            var timeSpanNanosegundos = new TimeSpan(1);
            Console.WriteLine(timeSpanNanosegundos);

            var timeSpanHoraMinutoSegundo = new TimeSpan(10, 2, 10);
            Console.WriteLine(timeSpanHoraMinutoSegundo);

            var timeSpanDiaHoraMinutoSegundo = new TimeSpan(3, 10, 2, 10);
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo);

            var timeSpanDiaHoraMinutoSegundoMilissegundo = new TimeSpan(3, 10, 2, 10, 150);
            Console.WriteLine(timeSpanDiaHoraMinutoSegundoMilissegundo);

            Console.WriteLine(timeSpanHoraMinutoSegundo - timeSpanDiaHoraMinutoSegundoMilissegundo);
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Days);
            Console.WriteLine(timeSpanDiaHoraMinutoSegundo.Add(new TimeSpan(12, 0, 0)));
        }
    }
}