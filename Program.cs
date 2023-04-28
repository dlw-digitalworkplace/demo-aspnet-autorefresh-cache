using Demo.AutoRefreshCache.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
		.AddControllers();

builder.Services
		.AddMemoryCache();

builder.Services
		.AddSingleton<IDataService, DataService>()
		.AddHostedService<UpdateCacheHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
