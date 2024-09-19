using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyTestController : ControllerBase
    {
        
        [HttpPost(Name = "MyTest1")]
        [Consumes("application/json+testea")]
        public Result Post1(TestA test)
        {
            return new Result(test.TestAtxt);
        }

        [HttpPost(Name = "MyTest2")]
        [Consumes("application/json+testeb")]
        public Result Post2(TestB test)
        {
            return new Result(test.TestBtxt);
        }
    }

    public record Result(string Test);
    public record TestA(string TestAtxt);
    public record TestB(string TestBtxt);
}
