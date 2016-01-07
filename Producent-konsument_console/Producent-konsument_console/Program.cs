using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Producent_konsument_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Część licząca czas operacji
            #region czas operacji
            Action<Action> mierzenie = (cialo) =>
                {
                    var stoper = DateTime.Now;
                    cialo();
                    Console.WriteLine("{0} {1}", DateTime.Now - stoper,
                        Thread.CurrentThread.ManagedThreadId); // Daje unikalny identyfikator dla obecnie obsługiwanego wątku
                };
            #endregion


            //Część wielkości obliczeń zadania
            #region podejście 3
            //Action obliczenia = () =>
            //{
            //    for (int i = 0; i < 99000000; i++) ;
            //};
            #endregion
            #region podejście 4, 5, 6, 7
            //Action obliczenia = () =>
            //{
            //    for (int i = 0; i < 99000000; i++) ;
            //};
            //Action wejscie_obliczenia = () =>
            //    {
            //        Thread.Sleep(1000);
            //    };
            #endregion

            #region podejście producenci-konsumenci
            Action obliczenia = () =>
            {
                for (int i = 0; i < 99000000; i++) ;
            };
            Action wejscie_obliczenia = () =>
            {
                Thread.Sleep(1000);
            };
            #endregion

            //Część do zadań
            #region podejście 1
            //var zadania = new[]
            //        {
            //            Task.Factory.StartNew(obliczenia)
            //        };
            //Task.WaitAll(zadania);
            #endregion
            #region podejście 2
            //mierzenie(() =>
            //    {
            //        var zadania = new[]
            //        {
            //            Task.Factory.StartNew(() => mierzenie(obliczenia)),
            //            Task.Factory.StartNew(() => mierzenie(obliczenia)),
            //            Task.Factory.StartNew(() => mierzenie(obliczenia)),
            //            Task.Factory.StartNew(() => mierzenie(obliczenia)),
            //            Task.Factory.StartNew(() => mierzenie(obliczenia))
                
            //        };
            //        Task.WaitAll(zadania);
            //    });
            #endregion
            #region podejscie 3
            //mierzenie(() =>
            //{
            //    var zadania = Enumerable.Range(1, 10)
            //        .Select(_ => Task.Factory.StartNew(() => mierzenie(obliczenia)))
            //        .ToArray();
            //    Task.WaitAll(zadania);
            //});
            #endregion
            #region podejście 4
            ////mierzenie(() =>
            ////{
            ////    var zadania = Enumerable.Range(1, 10)
            ////        .Select(_ => Task.Factory.StartNew(() => mierzenie(wejscie_obliczenia)))
            ////        .ToArray();
            ////    Task.WaitAll(zadania);
            ////});

            //Parallel.For(0, 10, _ =>
            //    {
            //        mierzenie(wejscie_obliczenia);
            //    });
            #endregion
            #region podejście 5
            //Enumerable.Range(1, 10)
            //    //Daję nam sekwencję:
            //    //.ToList()
            //    //.ForEach(_ => mierzenie(wejscie_obliczenia));

            //    //Daję nam zrównoleglanie:
            //    .AsParallel()
            //    .WithDegreeOfParallelism(10) //Maksymalna liczba wątków
            //    .ForAll(_ => mierzenie(wejscie_obliczenia));
            #endregion
            #region podejście 6
            //ParallelEnumerable.Range(1, 10)
            //.WithDegreeOfParallelism(5) //Maksymalna liczba wątków
            //    .ForAll(_ => mierzenie(wejscie_obliczenia));
            #endregion
            #region podejście 7
            ThreadPool.SetMinThreads(10, 10);
            Parallel.For(0, 10, _ =>
                {
                    mierzenie(wejscie_obliczenia);
                });
            #endregion

            //Producenci-konsumenci
            #region p-k_1 - blokowanie się wątków (totalne dno)
            //var zapytanie = new Queue<int>();

            //var producenci = Enumerable.Range(1, 3)
            //    .Select(_ => Task.Factory.StartNew(() =>
            //        {
            //            Enumerable.Range(1, 100)
            //                .ToList()
            //                .ForEach(i =>
            //                {
            //                    // BŁĄD
            //                    zapytanie.Enqueue(i);
            //                    Thread.Sleep(100);
            //                });
            //        }))
            //        .ToArray();

            //var konsumenci = Enumerable.Range(1, 2)
            //    .Select(_ => Task.Factory.StartNew(() =>
            //    {
            //        while (zapytanie.Count > 0)
            //        {
            //            // BŁĄD
            //            Console.WriteLine(zapytanie.Dequeue());
            //        }
            //    }))
            //        .ToArray();

            //Task.WaitAll(producenci);
            //Task.WaitAll(konsumenci);
            #endregion

            var zapytanie = new BlockingCollection<int>(100000000); // Jakim dysponujemy przedziałem (wyznaczanie górnej granicy)

            var producenci = Enumerable.Range(1, 5) // Ile razy wysyłamy to samo zapytanie
                .Select(_ => Task.Factory.StartNew(() =>
                {
                    Enumerable.Range(1, 5) // Jaki przedział badamy
                        .ToList()
                        .ForEach(i =>
                        {
                            // Lepiej dodać zapytanie niż odpowiadać na nie "Enqueue"
                            zapytanie.Add(i); // Dodanie zapytania do listy
                            Thread.Sleep(10); //Czas uśpienia
                        });
                }))
                    .ToArray(); // Zapis do tablicy

            var konsumenci = Enumerable.Range(1, 3)
                .Select(_ => Task.Factory.StartNew(() =>
                {
                    //zamiast "while (zapytanie.Count > 0)" trzeba stopniowo usuwać stare zapytania
                    foreach(var item in zapytanie.GetConsumingEnumerable())
                    {
                        // BŁĄD "zapytanie.Dequeue()" zamieniamy na "item"
                        Console.WriteLine(item); // Wypisywanie w konsoli wykonywanych zapytań
                    }
                }))
                    .ToArray(); // Zapis do tablicy

            Task.WaitAll(producenci); // Czekanie na zakończenie zadań producentów
            zapytanie.CompleteAdding(); // Sprawdzenie czy wszystko zostało dodane
            Task.WaitAll(konsumenci); // Czekanie na zakończenie zadań konsumentów

            Console.WriteLine();
            Console.Write("Naciśnij dowolny klawisz...");
            Console.ReadKey();
        }
    }
}
