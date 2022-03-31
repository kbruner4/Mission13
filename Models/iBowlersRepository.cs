using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public interface iBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        //Edit
        public void SaveBowler(Bowler b);

        //Create
        public void CreateBowler(Bowler b);

        //Delete
        public void DeleteBowler(Bowler b);
    }
}
