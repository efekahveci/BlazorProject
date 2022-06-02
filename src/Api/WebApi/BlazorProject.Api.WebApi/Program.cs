using BlazorProject.Api.Application;
using BlazorProject.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(opt => opt.Filters.Add<ValidateModelStateFilter>());
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistanceLayer(builder.Configuration);
builder.Services.AddApplicationLayer();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureRequestPipeline();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
