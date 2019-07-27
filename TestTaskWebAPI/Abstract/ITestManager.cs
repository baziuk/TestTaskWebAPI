using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskWebAPI.Abstract
{
    public interface ITestManager
    {
        List<int> GetChange(decimal M, decimal P);

        int GetNumberOfFullDecks(IEnumerable<string> inputCards);
    }
}
