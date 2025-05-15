using Microsoft.OpenApi.Models;
using WebApiLearningProject.BLL.Services;

var builder = WebApplication.CreateBuilder(args);
builder
    .Services
    .AddLogging(service =>
    {
        service.ClearProviders();
        service.AddConsole();
        service.SetMinimumLevel(LogLevel.Information);
    });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder
    .Services
    .AddSwaggerGen(options =>
    {
        options.SwaggerDoc(
            "v1",
            new OpenApiInfo { Title = "WebApiLearningProject API", Version = "v1" }
        );
    });
builder.Services.AddCors();

// BLL Services
builder.Services.AddScoped<ITestService, TestService>();
var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API Learning Project");
        options.DocumentTitle = "Web API Learning Project";
        options.RoutePrefix = "swagger";
    });
}
app.MapGet(
    "/",
    context =>
    {
        context.Response.Redirect("/Swagger");
        return Task.CompletedTask;
    }
);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
