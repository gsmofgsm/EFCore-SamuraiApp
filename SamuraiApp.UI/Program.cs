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
        //private static SamuraiContext _context = new SamuraiContext();
        //private static SamuraiContext _contextNT = new SamuraiContextNoTracking();

        private static void Main(string[] args)
        {
            // press F5 to start debugging
            // do right click to set this project as startup project herebefore
            //_context.Database.EnsureCreated(); // This causes EFcore to read the provider and connection string, check if the db exists, and creates it on the fly

            AddSamuraisByName("Shimada", "Okamoto", "Kikuchio", "Hayashida");
            // GetSamurais();
            //AddVariousTypes();
            //QueryFilters();
            //QueryAggregates();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //MultipleDatabaseOperations();
            //RetrieveAndDeleteASamurai();

            //QueryAndUpdateBattles_Disconnected();

            //InsertNewSamuraiWithAQuote();
            //InsertNewSamuraiWithManyQuotes();
            //AddQuoteToExistingSamuraiWhileTracked();
            //AddQuoteToExistingSamuraiNotTracked(1);
            //Simpler_AddQuoteToExistingSamuraiNotTracked(2);

            //EagerLoadSamuraiWithQuotes();
            //ProjectSomeProperties();
            //ProjectSamuraisWithQuotes();

            //ExplicitLoadQuotes();

            //FilteringWithRelatedData();
            //ModifyingRelatedDataWhenTracked();
            //ModifyingRelatedDataWhenNotTracked();

            //AddingNewSamuraiToAnExistingBattle();
            //ReturnBattleWithSamurais();
            //ReturnAllBattlesWithSamurais();
            //AddAllSamuraisToAllBattles();
            //WillNotRemoveSamuraiFromABattle();
            //RemoveSamuraiFromABattle();

            //AddNewSamuraiWithHorse();
            //AddNewHorseToSamuraiUsingId();
            //AddNewHorseToSamuraiObject();
            //AddNewHorseToDisconnectedSamuraiObject();
            //ReplaceAHorse();
            //GetSamuraiWithHorse();

            //QuerySamuraiBattleStats();
            //QueryUsingRawSql();
            //QueryUsingRawSqlWithInterpolation();

            //QueryUsingFromSqlRawStoredProd();
            //QueryUsingFromSqlIntStoredProd();
            //ExecuteSomeRawSql();

            Console.Write("Press any key...");
            Console.ReadKey();
        }

        //private static void ExecuteSomeRawSql()
        //{
        //    //var samuraiId = 2;
        //    //var affected = _context.Database
        //    //    .ExecuteSqlRaw("EXEC DeleteQuotesForSamurai {0}", samuraiId); // when using sqlRaw, do remember to pass parameter

        //    var samuraiId = 2;
        //    var affected = _context.Database
        //        .ExecuteSqlInterpolated($"EXEC DeleteQuotesForSamurai {samuraiId}");
        //}

        //private static void QueryUsingFromSqlIntStoredProd()
        //{
        //    var text = "Happy";
        //    var samurais = _context.Samurais.FromSqlInterpolated(
        //        $"EXEC dbo.SamuraisWhoSaidAWord {text}").ToList();
        //}

        //private static void QueryUsingFromSqlRawStoredProd()
        //{
        //    var text = "Happy";
        //    var samurais = _context.Samurais.FromSqlRaw(
        //        "EXEC dbo.SamuraisWhoSaidAWord {0}", text).ToList();
        //}

        //private static void QueryUsingRawSqlWithInterpolation()
        //{
        //    string name = "Kikuchyo";
        //    var samurais = _context.Samurais
        //        .FromSqlInterpolated($"Select * from Samurais Where Name = {name}")
        //        .ToList();
        //}

        //private static void QueryUsingRawSql()
        //{
        //    // must return data for ALL properties of the entity type, no more, no less
        //    // Column names in results must match mapped column names
        //    // it will be tracked
        //    var samurais = _context.Samurais.FromSqlRaw("Select * from samurais").ToList();
        //}

        //private static void QuerySamuraiBattleStats()
        //{
        //    var stats = _context.SamuraiBattleStats.ToList();
        //    var firstStats = _context.SamuraiBattleStats.FirstOrDefault();
        //    var sampsonStats = _context.SamuraiBattleStats
        //        .FirstOrDefault(b => b.Name == "SampsonSan");
        //    var findOne = _context.SamuraiBattleStats.Find(2); // be carefull with find, compiler would be find, but runtime exception because there is no key
        //}

        //private static void GetSamuraiWithHorse()
        //{
        //    var horseonly = _context.Set<Horse>().Find(4);
        //    var horseWithSamurai = _context.Samurais.Include(s => s.Horse)
        //        .FirstOrDefault(s => s.Horse.Id == 4);
        //    var horseSamuraiPairs = _context.Samurais
        //        .Where(s => s.Horse != null)
        //        .Select(s => new { Horse = s.Horse, Samurai = s })
        //        .ToList();
        //}

        //private static void ReplaceAHorse()
        //{
        //    //var samurai = _context.Samurais.Include(s => s.Horse)
        //    //    .FirstOrDefault(s => s.Id == 5);
        //    //samurai.Horse = new Horse { Name = "Trigger" };
        //    //_context.SaveChanges();

        //    // horse trading
        //    var horse = _context.Set<Horse>().FirstOrDefault(h => h.Name == "Mr. Ed");
        //    horse.SamuraiId = 5; // owns Trigger!
        //    _context.SaveChanges(); // throws exception
        //}

        //private static void AddNewHorseToDisconnectedSamuraiObject()
        //{
        //    var samurai = _context.Samurais.AsNoTracking().FirstOrDefault(s => s.Id == 5);
        //    samurai.Horse = new Horse { Name = "Mr. Ed" };

        //    using var newContext = new SamuraiContext();
        //    newContext.Samurais.Attach(samurai);
        //    newContext.SaveChanges();
        //}

        //private static void AddNewHorseToSamuraiObject()
        //{
        //    var samurai = _context.Samurais.Find(12); // There is already a samurai in memory
        //    samurai.Horse = new Horse { Name = "Black Beauty" };
        //    _context.SaveChanges();
        //}

        //private static void AddNewHorseToSamuraiUsingId()
        //{
        //    var horse = new Horse { Name = "Scount", SamuraiId = 2 };
        //    _context.Add(horse);
        //    _context.SaveChanges();
        //}

        //private static void AddNewSamuraiWithHorse()
        //{
        //    var samurai = new Samurai { Name = "Jina Ujichika" };
        //    samurai.Horse = new Horse { Name = "Silver" };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}

        //private static void RemoveSamuraiFromABattle()
        //{
        //    var battleWithSamurai = _context.Battles
        //        .Include(b => b.Samurais.Where(s => s.Id == 12))
        //        .Single(s => s.BattleId == 1);
        //    var samurai = battleWithSamurai.Samurais[0];
        //    battleWithSamurai.Samurais.Remove(samurai);
        //    _context.SaveChanges();
        //}

        //private static void WillNotRemoveSamuraiFromABattle()
        //{
        //    var battle = _context.Battles.Find(1);
        //    var samurai = _context.Samurais.Find(12);
        //    battle.Samurais.Remove(samurai);
        //    _context.SaveChanges(); // the relationship is not being tracked, so nothing gets removed
        //}

        //private static void AddAllSamuraisToAllBattles()
        //{
        //    var allBattles = _context.Battles.Include(b => b.Samurais).ToList(); // eager load so changeTracker knows what are changed, but be careful performance issue
        //    var allSamurais = _context.Samurais.ToList();
        //    foreach (var battle in allBattles)
        //    {
        //        battle.Samurais.AddRange(allSamurais);
        //    }
        //    _context.SaveChanges();
        //}

        //private static void ReturnAllBattlesWithSamurais()
        //{
        //    var battle = _context.Battles.Include(b => b.Samurais).ToList();
        //}

        //private static void ReturnBattleWithSamurais()
        //{
        //    var battle = _context.Battles.Include(b => b.Samurais).FirstOrDefault();
        //}

        //private static void AddingNewSamuraiToAnExistingBattle()
        //{
        //    var battle = _context.Battles.FirstOrDefault();
        //    battle.Samurais.Add(new Samurai { Name = "Takeda shingen" });
        //    _context.SaveChanges();
        //}

        //private static void ModifyingRelatedDataWhenNotTracked()
        //{
        //    var samurai = _context.Samurais.Include(s => s.Quotes)  // eager loading
        //        .FirstOrDefault(s => s.Id == 1);
        //    var quote = samurai.Quotes[0];
        //    quote.Text += "Did you hear that again?";

        //    using var newContext = new SamuraiContext();
        //    //newContext.Quotes.Update(quote); // all quotes of that samurai get updated!
        //    newContext.Entry(quote).State = EntityState.Modified; // only this quote gets updated
        //    newContext.SaveChanges();
        //}

        //private static void ModifyingRelatedDataWhenTracked()
        //{
        //    var samurai = _context.Samurais.Include(s => s.Quotes)  // eager loading
        //        .FirstOrDefault(s => s.Id == 2);
        //    samurai.Quotes[0].Text = "Did you hear that?";  // if quotes not loaded, get index out of range error
        //    _context.SaveChanges();
        //}

        //private static void FilteringWithRelatedData()
        //{
        //    var samurais = _context.Samurais
        //        .Where(s => s.Quotes.Any(q => q.Text.Contains("happy")))  // Quotes won't get returned
        //        .ToList();
        //}

        //private static void ExplicitLoadQuotes()
        //{
        //    // make sure there's a horse in the DB, then clear the context's change tracker
        //    _context.Set<Horse>().Add(new Horse { SamuraiId = 1, Name = "Mr. Ed" });
        //    _context.SaveChanges();
        //    _context.ChangeTracker.Clear();
        //    // ------
        //    var samurai = _context.Samurais.Find(1);
        //    _context.Entry(samurai).Collection(s => s.Quotes).Load();
        //    _context.Entry(samurai).Reference(s => s.Horse).Load();
        //}

        //private static void ProjectSamuraisWithQuotes()
        //{
        //    //var somePropsWithQuotes = _context.Samurais
        //        //.Select(s => new { s.Id, s.Name, s.Quotes })
        //        //.Select(s => new { s.Id, s.Name, NumberOfQuotes = s.Quotes.Count })
        //        //.Select(s => new { s.Id, s.Name, HappyQuotes = s.Quotes.Where(q => q.Text.Contains("happy")) })
        //        //.ToList();

        //    var samuraisAndQuotes = _context.Samurais
        //        .Select(s => new { Samurai = s, HappyQuotes = s.Quotes.Where(q => q.Text.Contains("happy")) })
        //        .ToList();
        //    var firstSamurai = samuraisAndQuotes[0].Samurai.Name += " The happiest";
        //}

        //private static void ProjectSomeProperties()
        //{
        //    var somePropertyies = _context.Samurais.Select(s => new { s.Id, s.Name }).ToList(); // anonymous type
        //    var idAndNames = _context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList(); // dynamic type
        //}

        //public struct IdAndName
        //{
        //    public int Id;
        //    public string Name;

        //    public IdAndName(int id, string name)
        //    {
        //        Id = id;
        //        Name = name;
        //    }
        //}

        //private static void EagerLoadSamuraiWithQuotes()
        //{
        //    //var samuraiWithQuotes = _context.Samurais.Include(s => s.Quotes).ToList();  // uses LeftJoin
        //    //var splitQuery = _context.Samurais.AsSplitQuery().Include(s => s.Quotes).ToList(); // select from samurais, then inner join
        //    var filteredInclude = _context.Samurais.Include(s => s.Quotes.Where(q => q.Text.Contains("Thanks"))).ToList();
        //}

        //private static void Simpler_AddQuoteToExistingSamuraiNotTracked(int samuraiId)
        //{
        //    var quote = new Quote { Text = "Thanks for dinner!", SamuraiId = samuraiId };
        //    using var newContext = new SamuraiContext();
        //    newContext.Quotes.Add(quote);
        //    newContext.SaveChanges();
        //}

        //private static void AddQuoteToExistingSamuraiNotTracked(int samuraiId)
        //{
        //    var samurai = _contextNT.Samurais.Find(samuraiId);
        //    samurai.Quotes.Add(new Quote
        //    {
        //        Text = "Now that I saved you, will you feed me dinner?"
        //    });
        //    using (var newContext = new SamuraiContext())
        //    {
        //        //newContext.Samurais.Update(samurai);  // this will update samurai as well
        //        newContext.Samurais.Attach(samurai);    // this will not update samurai
        //        newContext.SaveChanges();
        //    }
        //}

        //private static void AddQuoteToExistingSamuraiWhileTracked()
        //{
        //    var samurai = _context.Samurais.FirstOrDefault();
        //    samurai.Quotes.Add(new Quote
        //    {
        //        Text = "I bet you're happy that I've saved you!"
        //    });
        //    _context.SaveChanges();
        //}

        //private static void InsertNewSamuraiWithManyQuotes()
        //{
        //    var samurai = new Samurai
        //    {
        //        Name = "Kyuzo",
        //        Quotes = new List<Quote>
        //        {
        //            new Quote { Text = "Watch out for my sharp sword!" },
        //            new Quote { Text = "I told you to watch out for the sharp sword! Oh well!" }
        //        }
        //    };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}

        //private static void InsertNewSamuraiWithAQuote()
        //{
        //    var samurai = new Samurai
        //    {
        //        Name = "Kambei Shimada",
        //        Quotes = new List<Quote>
        //        {
        //            new Quote { Text = "I've come to save you" }
        //        }
        //    };
        //    _context.Samurais.Add(samurai);
        //    _context.SaveChanges();
        //}

        //private static void QueryAndUpdateBattles_Disconnected()
        //{
        //    List<Battle> disconnectedBattles;
        //    using (var context1 = new SamuraiContext())
        //    {
        //        disconnectedBattles = context1.Battles.ToList();
        //    } // context1 is disposed
        //    disconnectedBattles.ForEach(b =>
        //    {
        //        b.StartDate = new DateTime(1570, 01, 01);
        //        b.EndDate = new DateTime(1570, 12, 1);
        //    });

        //    using (var context2 = new SamuraiContext())
        //    {
        //        context2.UpdateRange(disconnectedBattles);   // you must call update in a disconnected context
        //        context2.SaveChanges();   // name get also updated in sql, because EF core knows about the update, but not what get updated
        //    }
        //}

        //private static void RetrieveAndDeleteASamurai()
        //{
        //    var samurai = _context.Samurais.Find(15);  // let context know and start tracking it
        //    PrintSamurais(samurai);
        //    _context.Samurais.Remove(samurai);         // delete
        //    PrintSamurais(samurai);
        //    _context.SaveChanges();                    // SaveChanges
        //    PrintSamurais(samurai);  // 15 Shino - so you can still print it after deleted
        //}

        //private static void MultipleDatabaseOperations()
        //{
        //    var samurai = _context.Samurais.FirstOrDefault();
        //    samurai.Name += "San";
        //    _context.Samurais.Add(new Samurai { Name = "Shino" });
        //    _context.SaveChanges();
        //}

        //private static void RetrieveAndUpdateMultipleSamurais()
        //{
        //    var samurais = _context.Samurais.Skip(1).Take(4).ToList();
        //    PrintSamurais(samurais);
        //    samurais.ForEach(s => s.Name += "San");
        //    PrintSamurais(samurais);
        //    _context.SaveChanges();
        //}

        //private static void RetrieveAndUpdateSamurai()
        //{
        //    var samurai = _context.Samurais.FirstOrDefault();
        //    PrintSamurais(samurai);
        //    samurai.Name += "San";
        //    PrintSamurais(samurai);
        //    _context.SaveChanges();
        //    PrintSamurais(samurai);
        //}

        //private static void QueryAggregates()
        //{
        //    var name = "Sampson";
        //    //var samurai = _context.Samurais.Where(s => s.Name == name).FirstOrDefault();
        //    var samurai = _context.Samurais.FirstOrDefault(s => s.Name == name);
        //    PrintSamurais(samurai);
        //    samurai = _context.Samurais.Find(2);  // this isn't a Linq query, it is a DbSet method that gets executed directly
        //                                          // if key is found in change tracker, avoids unneeded db query
        //    PrintSamurais(samurai);
        //}

        //private static void QueryFilters()
        //{
        //    //var name = "Sampson";
        //    //var samurais = _context.Samurais.Where(s => s.Name == name).ToList(); // parameter is created in sql because search value is in a variable
        //    //var samurais = _context.Samurais.Where(s => s.Name == "Sampson").ToList();  // no parameter is created in sql, because search value is directly in query

        //    var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();
        //    PrintSamurais(samurais);
        //}

        //private static void AddVariousTypes()
        //{
        //    _context.AddRange(new Samurai { Name = "Shimada" },
        //                      new Samurai { Name = "Okamoto" },
        //                      new Battle { Name = "Battle of Anegawa" },
        //                      new Battle { Name = "Battle of Nagashino" });
        //    //_context.Samurais.AddRange(
        //    //    new Samurai { Name = "Shimada" },
        //    //    new Samurai { Name = "Okamoto" });
        //    //_context.Battles.AddRange(
        //    //    new Battle { Name = "Battle of Anegawa" },
        //    //    new Battle { Name = "Battle of Nagashino" });
        //    _context.SaveChanges();
        //}

        private static void AddSamuraisByName(params string[] names)
        {
            //foreach (string name in names)
            //{
            //    _context.Samurais.Add(new Samurai { Name = name }); // add the samurai object to the context samurai DbSet, so it's an in memory collection of samurais that the context keeps track of
            //}
            //_context.SaveChanges(); // will save the data that the context is tracking back to the database
            var _bizData = new BusinessDataLogic();
            var newSamuraisCreatedCount = _bizData.AddSamuraisByName(names);
        }
        
        //private static void GetSamurais()
        //{
        //    var samurais = _context.Samurais
        //        .TagWith("ConsoleApp.Program.GetSamurais method")
        //        .ToList();
        //    PrintSamurais(samurais);
        //}

        //private static void PrintSamurais(List<Samurai> samurais)
        //{
        //    Console.WriteLine($"Samurai count is {samurais.Count}");
        //    foreach (var samurai in samurais)
        //    {
        //        PrintSamurais(samurai);
        //    }
        //}

        //private static void PrintSamurais(Samurai samurai)
        //{
        //    if (samurai == null)
        //    {
        //        Console.WriteLine("samurai not found");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"{samurai.Id} - {samurai.Name}");
        //    }
        //}
    }
}
