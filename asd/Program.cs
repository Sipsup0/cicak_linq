﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asd
{
    enum Szine {Zold, Rozsaszin, Feher, Lila, Fekete}
    enum Neme {Fiu, Lany}
    class Cica
    {
        public int ID { get; set; }
        public string Neve { get; set; }
        public Szine Szine { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public Neme Neme { get; set; }
        public int Suly { get; set; }
        public int Kor => DateTime.Now.Year - SzuletesiDatum.Year;

        public override string ToString()
        {
            return $"{ID,5}{Neve,-15}{Szine,-10}{SzuletesiDatum.ToString("yyy.MM.dd"),-15}{Neme,-10}{Suly,-5}{Kor}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Cica> cicak = new List<Cica>()
            {
                new Cica()
                {
                    ID = 1,
                    Neme = Neme.Fiu,
                    Neve = "Megatron",
                    Suly = 10,
                    Szine = Szine.Fekete,
                    SzuletesiDatum = new DateTime(2018, 08, 13),
                },
                new Cica()
                {
                    ID = 2,
                    Neme = Neme.Lany,
                    Neve = "Pizsama",
                    Suly = 4,
                    Szine = Szine.Rozsaszin,
                    SzuletesiDatum = new DateTime(2022, 12, 20),
                },
                new Cica()
                {
                    ID = 3,
                    Neme = Neme.Lany,
                    Neve = "Cafka",
                    Suly = 7,
                    Szine = Szine.Lila,
                    SzuletesiDatum = new DateTime(2019, 07, 21),
                },
                new Cica()
                {
                    ID = 4,
                    Neme = Neme.Fiu,
                    Neve = "Dr Grofo",
                    Suly = 14,
                    Szine = Szine.Feher,
                    SzuletesiDatum = new DateTime(2016, 04, 06),
                }
            };

            //elso cica
            Cica elsoCica = cicak.First();
            Console.WriteLine(elsoCica);

            //utolso cica
            Cica utolsoCica = cicak.Last();
            Console.WriteLine(utolsoCica);

            //osszes suly
            int osszSuly = cicak.Sum(x=> x.Suly);
            Console.WriteLine($"Ossz suly: {osszSuly} kg");

            //atlag eletkor
            double atlagKor = cicak.Average(x => x.Kor);
            Console.WriteLine($"atlag eletkor: {atlagKor:0.00}");

            //lany macskak db
            int lanyDb = cicak.Count(x => x.Neme == Neme.Lany);
            Console.WriteLine($"lany cicak: {lanyDb}");

            //legveznabb macska
            int legveznabbMacska = cicak.Min(x => x.Suly);
            Console.WriteLine(legveznabbMacska);

            // 3 evnel idosebb cicak
            cicak.Where(x => x.Kor > 3).ToList()
                .ToList()
                .ForEach(x => Console.WriteLine(x.Neve));

            //fekete macska
            cicak.Where(x => x.Szine == Szine.Fekete)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Neve));

            Console.ReadKey();
        }
    }
}
