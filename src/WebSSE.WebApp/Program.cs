using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapGet("/sse", async (HttpContext context) =>
{
    context.Response.Headers[HeaderNames.ContentType] = "text/event-stream";
    for (var index = 0; index < 10; index++)
    {
        await context.Response.WriteAsync($"data: Message {index}\n\n");
        await context.Response.Body.FlushAsync();
        await Task.Delay(1000);
    }
});


app.Run();
