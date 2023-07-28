using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var uiOrigin = "_uiOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                     .AddJsonFile("ocelot.json", optional: false)
                     .AddEnvironmentVariables();

builder.Services.AddCors(options =>
{
    options.AddPolicy(uiOrigin, b => b.WithOrigins(builder.Configuration.GetValue<string>("UI_ORIGIN"))
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
});

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddSwaggerForOcelot(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}

app.UseCors(uiOrigin);

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

await app.UseOcelot();

app.MapControllers();

app.Run();
