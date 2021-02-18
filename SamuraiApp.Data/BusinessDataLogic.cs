using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class BusinessDataLogic
    {
        private SamuraiContext _context;

        public BusinessDataLogic()
        {
            _context = new SamuraiContext();
        }

        public BusinessDataLogic(SamuraiContext context)
        {
            _context = context;
        }

        public int AddSamuraisByName(params string[] names)
        {
            foreach (string name in names)
            {
                _context.Samurais.Add(new Samurai { Name = name }); // add the samurai object to the context samurai DbSet, so it's an in memory collection of samurais that the context keeps track of
            }
            var dbResult = _context.SaveChanges(); // will save the data that the context is tracking back to the database
            return dbResult;
        }
    }
}
