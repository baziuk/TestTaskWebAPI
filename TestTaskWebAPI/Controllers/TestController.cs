using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTaskWebAPI.Abstract;

namespace TestTaskWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestManager _testManager;

        public TestController(ITestManager testManager)
        {
            _testManager = testManager;
        }

        [HttpGet("{M}/{P}")]
        public ActionResult<List<int>> GetChange(decimal M, decimal P)
        {
            return _testManager.GetChange(M, P);
        }

        [HttpPost]
        public ActionResult<int> GetNumberOfFullDecks([FromBody]IEnumerable<string> inputCards)
        {          
            return _testManager.GetNumberOfFullDecks(inputCards);
        }
      
    }
}
