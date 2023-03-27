using Autofac;
using Autofac.Extensions.DependencyInjection;
using EcommerceAPI.Data.Miscellaneous;
using EcommerceAPI.Middlewares;
using EcommerceAPI.ValidatorBehavior;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var containerBuilder = new ContainerBuilder();
// Add services to the container.

//Logger
Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.File("logs/EcommerceLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

//Serilog
builder.Host.UseSerilog();

//MediatR
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Program).Assembly));
//builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AddHeaderOperationFilter>("x-user-id", "Enter User Id", true);
});

//add custom swagger options
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();


//api versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});
//api versioning
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//call config in autofac 
IConfiguration Configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .AddCommandLine(args)
               .Build();
//declare autofac
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacConfig(Configuration)));
builder.Services.AddAutofac();


var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}
//add auth middleware
app.UseMiddleware<AuthMiddleware>();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
