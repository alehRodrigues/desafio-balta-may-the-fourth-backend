using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StarisApi.Configurations;
using StarisApi.Configurations.Attributtes;
using StarisApi.DbContexts;
using StarisApi.Endpoints;
using StarisApi.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("VaderPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.Configure<JsonOptions>(opt =>
    opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
builder.Services.AddSwaggerGen(opt =>
{
    opt.EnableAnnotations();
    opt.DescribeAllParametersInCamelCase();
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "StarisApi", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    opt.IncludeXmlComments(xmlPath);

    opt.OperationFilter<ParameterAttribute>();
});

builder.Services.AddDbContext<SqliteContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseLazyLoadingProxies();
});

builder.Services.AddTransient<SqliteContext>();
builder.Services.AddScoped(typeof(DataBaseFeederRepository<>));
builder.Services.AddScoped(typeof(Repository<>));

Configurations.Host = builder.Configuration.GetValue<string>("Host")!;

var app = builder.Build();

app.UseCors("VaderPolicy");

app.UseRouting();

app.UseEndpoints(endpoint =>
{
    _ = endpoint.MapGet(
        "/",
        async context => await Task.Run(() => context.Response.Redirect("/swagger/index.html"))
    );
});

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DisplayRequestDuration();
});
app.UseDeveloperExceptionPage();

app.MapGroup("/api").MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapGroup("/api").MapFeeder();
    app.MapGroup("/api").MapDataRelationFeederEndpoits();
}

app.Run();
