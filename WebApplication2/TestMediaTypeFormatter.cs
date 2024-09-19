using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace WebApplication2
{
    public class TestMediaTypeFormatter : SystemTextJsonInputFormatter
    {
        public TestMediaTypeFormatter(
            JsonOptions options,
            ILogger<SystemTextJsonInputFormatter> logger) : base(options, logger)
        {
            SupportedMediaTypes.Add("application/json+testa");
            SupportedMediaTypes.Add("application/json+testb");
        }
    }
}
