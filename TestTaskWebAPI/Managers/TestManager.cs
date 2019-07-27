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
            // var input = new string[] { "2S", "2C", "2D", "2H", "3S", "3C", "3D", "3H", "4S", "4C", "4D", "4H", "5S", "5C", "5D", "5H", "6S", "6C", "6D", "6H", "7S", "7C", "7D", "7H", "8S", "8C", "8D", "8H", "9S", "9C", "9D", "9H", "TS", "TC", "TD", "TH", "JS", "JC", "JD", "JH", "QS", "QC", "QD", "QH", "KS", "KC", "KD", "KH", "AS", "AC", "AD", "AH", "2S", "2C", "2D", "2H", "3S", "3C", "3D", "3H", "4S", "4C", "4D", "4H", "5S", "5C", "5D", "5H", "6S", "6C", "6D", "6H", "7S", "7C", "7D", "7H", "8S", "8C", "8D", "8H", "9S", "9C", "9D", "9H", "TS", "TC", "TD", "TH", "JS", "JC", "JD", "JH", "QS", "QC", "QD", "QH", "KS", "KC", "KD", "KH", "AS", "AC", "AD", "AH", "2S", "2C", "2D", "2H", "3S", "3C", "3D", "3H", "4S", "4C", "4D", "4H", "5S", "5C", "5D", "5H", "6S", "6C", "6D", "6H", "7S", "7C", "7D", "7H", "8S", "8C", "8D", "8H", "9S", "9C", "9D", "9H", "TS", "TC", "TD", "TH", "JS", "JC", "JD", "JH", "QS", "QC", "QD", "QH", "KS", "KC", "KD", "KH", "AS", "AC", "AD" };

            //  var input = new string[] { "9C", "KS", "AC", "AH", "8D", "4C", "KD", "JC", "7D", "9D", "2H", "7C", "3C", "7S", "5C", "6H", "TH" };


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
