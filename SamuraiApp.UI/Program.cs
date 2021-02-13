using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace SamuraiApp.UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {
            // press F5 to start debugging
            // do right click to set this project as startup project herebefore
            _context.Database.EnsureCreated(); // This causes EFcore to read the provider and connection string, check if the db exists, and creates it on the fly
            
            AddSamuraisByName("Shimada", "Okamoto", "Kikuchio", "Hayashida");
            // GetSamurais();
            Console.Write("Press any key...");
            Console.ReadKey();
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
            Console.WriteLine($"Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
