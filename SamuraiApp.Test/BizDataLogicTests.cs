using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Test
{
    [TestClass]
    public class BizDataLogicTests
    {
        [TestMethod]
        public void CanAddSamuraisByName()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanAddSamuraisByName");

            using var context = new SamuraiContext(builder.Options);
            var bizLogic = new BusinessDataLogic(context);

            var namelist = new string[] { "Kikuchiyo", "Kyuzo", "Rikchi" };

            var result = bizLogic.AddSamuraisByName(namelist);
            Assert.AreEqual(namelist.Length, result);
        }

        [TestMethod]
        public void CanInsertSingleSamurai()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertSingleSamurai");

            using (var context = new SamuraiContext(builder.Options))
            {
                var bizLogic = new BusinessDataLogic(context);
                bizLogic.InsertNewSamurai(new Samurai());
            }
            using (var context2 = new SamuraiContext(builder.Options))
            {
                Assert.AreEqual(1, context2.Samurais.Count());
            }
        }
    }
}
