using System;
using System.Globalization;

namespace Datas
{
    class Program{
        static void Main(string[] args){
            //var data = new DateTime(); Instancia uma nova data(Espera Parametro)
            var data = DateTime.Now; // Pega a data atual
            var dataDefinida = new DateTime(2020, 03, 14, 08, 23, 14);
            
            
            Console.WriteLine(dataDefinida);
            Console.WriteLine(data);
            Console.WriteLine(data.Year);
            Console.WriteLine(data.Day);
            Console.WriteLine(data.DayOfWeek);
            Console.WriteLine(data.DayOfYear);
            // --------------- Formatando data

            var minhaData = DateTime.Now;
            var formatada = String.Format("{0:yyyy/MM/dd}", minhaData);
            Console.WriteLine(formatada);

            var dataTeste = new DateTime(2025, 02, 24);
            
            Console.WriteLine(dataTeste.AddDays(10));
            Console.WriteLine(dataTeste.AddDays(-100));
            
            //---------------------Comparando Datas
            
            var data1 = DateTime.Now;

            if (data1 == DateTime.Now){
                Console.WriteLine("É Igual");//Nao vai cair aqui Fração de segundo e diferente
            }
            if (data1 == DateTime.Now.Date){
                Console.WriteLine("É Igual");//vai cair por que as datas sao iguais
            }

            
            var data2 = new DateTime(2025, 05, 06);

            if (data1 > data2){
                Console.WriteLine($"Data {data1.Date} e maior que {data2.Date}");
            }
            // ------------- Glabalizacao e Localização

            var br = new CultureInfo("pt-BR");
            var pt = new CultureInfo("pt-PT");
            var en = new CultureInfo("en-US");
            var de = new CultureInfo("de-DE");
            var current = CultureInfo.CurrentCulture; // atual do sistema
            
            Console.WriteLine(DateTime.Now.ToString("D",de));
            
            //---------------------------- Timezone

            var dataUTC = DateTime.UtcNow;
            Console.WriteLine(dataUTC);
            Console.WriteLine(dataUTC.ToLocalTime()); // Volta pra data do Sistema / Servidor

            //Pega um timezone especifico Consultar Documentação para ver alguma especifica
            var timezoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
            var timeAustralia = TimeZoneInfo.ConvertTime(dataUTC, timezoneAustralia);
            
            Console.WriteLine(timeAustralia);
            //----------------- Timespan

            var timespan = new TimeSpan();
            Console.WriteLine(timespan);
            
            //Usado para metricas bem precisas, como em tempo de exucçaõ em milisegundos
        }
        
    }
}