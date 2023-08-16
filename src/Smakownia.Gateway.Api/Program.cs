using Microsoft.Extensions.FileProviders;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Smakownia.Gateway.Api.Clients;
using Smakownia.Gateway.Api.Middlewares;
using Smakownia.Gateway.Api.Services;

var AllowSpecificOrigins = "_allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IProductsClient, ProductsClient>();
builder.Services.AddTransient<IBasketClient, BasketClient>();
builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<IBasketService, BasketService>();

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                     .AddJsonFile("ocelot.json", optional: false)
                     .AddEnvironmentVariables();

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowSpecificOrigins, policy =>
    {
        policy.WithOrigins(builder.Configuration.GetValue<string>("UiOrigin"))
              .AllowCredentials()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddSwaggerForOcelot(builder.Configuration, opt =>
{
    opt.GenerateDocsForGatewayItSelf = true;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "upload")),
    RequestPath = "/upload",
    ServeUnknownFileTypes = true
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerForOcelotUI(opt =>
    {
        opt.PathToSwaggerGenerator = "/swagger/docs";
    });
}

app.UseCors(AllowSpecificOrigins);

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseRouting();

app.UseEndpoints(e =>
{
    e.MapControllers();
});

app.UseOcelot().Wait();

app.Run();
