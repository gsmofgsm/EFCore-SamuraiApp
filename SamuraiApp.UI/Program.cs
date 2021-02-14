using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        private static SamuraiContext _contextNT = new SamuraiContextNoTracking();

        private static void Main(string[] args)
        {
            // press F5 to start debugging
            // do right click to set this project as startup project herebefore
            _context.Database.EnsureCreated(); // This causes EFcore to read the provider and connection string, check if the db exists, and creates it on the fly

            // AddSamuraisByName("Shimada", "Okamoto", "Kikuchio", "Hayashida");
            // GetSamurais();
            //AddVariousTypes();
            //QueryFilters();
            //QueryAggregates();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //MultipleDatabaseOperations();
            //RetrieveAndDeleteASamurai();

            QueryAndUpdateBattles_Disconnected();
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void QueryAndUpdateBattles_Disconnected()
        {
            List<Battle> disconnectedBattles;
            using (var context1 = new SamuraiContext())
            {
                disconnectedBattles = context1.Battles.ToList();
            } // context1 is disposed
            disconnectedBattles.ForEach(b =>
            {
                b.StartDate = new DateTime(1570, 01, 01);
                b.EndDate = new DateTime(1570, 12, 1);
            });

            using (var context2 = new SamuraiContext())
            {
                context2.UpdateRange(disconnectedBattles);   // you must call update in a disconnected context
                context2.SaveChanges();   // name get also updated in sql, because EF core knows about the update, but not what get updated
            }
        }

        private static void RetrieveAndDeleteASamurai()
        {
            var samurai = _context.Samurais.Find(15);  // let context know and start tracking it
            PrintSamurais(samurai);
            _context.Samurais.Remove(samurai);         // delete
            PrintSamurais(samurai);
            _context.SaveChanges();                    // SaveChanges
            PrintSamurais(samurai);  // 15 Shino - so you can still print it after deleted
        }

        private static void MultipleDatabaseOperations()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "San";
            _context.Samurais.Add(new Samurai { Name = "Shino" });
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.Skip(1).Take(4).ToList();
            PrintSamurais(samurais);
            samurais.ForEach(s => s.Name += "San");
            PrintSamurais(samurais);
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            PrintSamurais(samurai);
            samurai.Name += "San";
            PrintSamurais(samurai);
            _context.SaveChanges();
            PrintSamurais(samurai);
        }

        private static void QueryAggregates()
        {
            var name = "Sampson";
            //var samurai = _context.Samurais.Where(s => s.Name == name).FirstOrDefault();
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);
            PrintSamurais(samurai);
            samurai = _context.Samurais.Find(2);  // this isn't a Linq query, it is a DbSet method that gets executed directly
                                                  // if key is found in change tracker, avoids unneeded db query
            PrintSamurais(samurai);
        }

        private static void QueryFilters()
        {
            //var name = "Sampson";
            //var samurais = _context.Samurais.Where(s => s.Name == name).ToList(); // parameter is created in sql because search value is in a variable
            //var samurais = _context.Samurais.Where(s => s.Name == "Sampson").ToList();  // no parameter is created in sql, because search value is directly in query

            var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();
            PrintSamurais(samurais);
        }

        private static void AddVariousTypes()
        {
            _context.AddRange(new Samurai { Name = "Shimada" },
                              new Samurai { Name = "Okamoto" },
                              new Battle { Name = "Battle of Anegawa" },
                              new Battle { Name = "Battle of Nagashino" });
            //_context.Samurais.AddRange(
            //    new Samurai { Name = "Shimada" },
            //    new Samurai { Name = "Okamoto" });
            //_context.Battles.AddRange(
            //    new Battle { Name = "Battle of Anegawa" },
            //    new Battle { Name = "Battle of Nagashino" });
            _context.SaveChanges();
        }

        private static void AddSamuraisByName(params string[] names)
        {
            foreach (string name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name }); // add the samurai object to the context samurai DbSet, so it's an in memory collection of samurais that the context keeps track of
            }
            _context.SaveChanges(); // will save the data that the context is tracking back to the database
        }
        
        private static void GetSamurais()
        {
            var samurais = _context.Samurais
                .TagWith("ConsoleApp.Program.GetSamurais method")
                .ToList();
            PrintSamurais(samurais);
        }

        private static void PrintSamurais(List<Samurai> samurais)
        {
            Console.WriteLine($"Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                PrintSamurais(samurai);
            }
        }

        private static void PrintSamurais(Samurai samurai)
        {
            if (samurai == null)
            {
                Console.WriteLine("samurai not found");
            }
            else
            {
                Console.WriteLine($"{samurai.Id} - {samurai.Name}");
            }
        }
    }
}
