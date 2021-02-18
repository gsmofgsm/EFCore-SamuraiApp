using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Test
{
    class InMemoryTests
    {
        [TestMethod]
        public void CanInsertSamuraiIntoMemory()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertSamurai"); // name database, this is how ef core tracks instances of provider in memory
            using (var context = new SamuraiContext(builder.Options)) // do not use builder itself, but its Options
            {
                //context.Database.EnsureDeleted();  // no need anymore to delete and create the database
                //context.Database.EnsureCreated();
                var samurai = new Samurai();
                context.Samurais.Add(samurai);
                //Debug.WriteLine($"Before save: {samurai.Id}");  // this will be already 1, after Add, but before SaveChanges
                //context.SaveChanges();
                //Debug.WriteLine($"After save: {samurai.Id}");

                //Assert.AreNotEqual(0, samurai.Id);
                Assert.AreEqual(EntityState.Added, context.Entry(samurai).State);
            }
        }
    }
}
