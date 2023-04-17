using PizzeriaDemoAPI;
using PizzeriaDemoAPI.Services;
using PizzeriaDemoAPI.Repositories;

var AllowSpecificOrigins = "_allowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});

// Add console logger only for this demo, can easily configure it to write to log file or database
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add memory cache to store the data for improving the performance
builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set up DI
// This demo is using CSV file as data store. With three layers structure, it can be easily switch to EF DbContext
// or any other data source
//builder.Services.AddDbContext<PizzeriaDbContext>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(AllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Location}/{action=All}/{id?}");


app.Logger.LogInformation("Program initialize is completed");

app.Run();
