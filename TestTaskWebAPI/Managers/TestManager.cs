using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskWebAPI.Abstract;

namespace TestTaskWebAPI.Managers
{
    public class TestManager : ITestManager
    {
        public List<int> GetChange(decimal M, decimal P)
        {

            if (P > M)
                throw new ArgumentException($@"({M}) must be greater than ({P})");

            var change = (M - P) * 100;

            var den = new[] { 1, 0.5, 0.25, 0.1, 0.05, 0.01 };

            var denomitations = den.Select(x => (decimal)x * 100M);

            var result = new List<int>();

            foreach (var item in denomitations)
            {
                result.Add((int)Math.Floor(change / item));
                change = change % item;
            }

            result.Reverse();
            return result;

        }

        public int GetNumberOfFullDecks(IEnumerable<string> inputCards) 
        {

            if (inputCards == null)
                throw new ArgumentException($@"Input parameter cannot be null");

            var ranks = "2,3,4,5,6,7,8,9,T,J,Q,K,A".Split(",");
            var suits = "S,C,H,D".Split(",");

            var decks = from rank in ranks
                        from suit in suits
                        select rank + suit;

            var count = (from deck in decks
                         select inputCards.Where(x => x == deck).Count()).Min();

            return count;
        }
    }
}
