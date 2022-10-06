using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace ExampleApp.Supplements;


public static class JsonPatchInputFormatter
{
    public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
    {
        ServiceProvider? builder = new ServiceCollection()
            .AddLogging()
            .AddMvc()
            .AddNewtonsoftJson()
            .Services.BuildServiceProvider();

        return (builder
            .GetRequiredService<IOptions<MvcOptions>>()
            .Value
            .InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>()
            .First());
    }
}