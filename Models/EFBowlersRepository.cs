using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlersRepository : iBowlersRepository
    {
        private BowlingDbContext _context { get; set; }
        public EFBowlersRepository (BowlingDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public void SaveBowler(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void CreateBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }
    }
}
