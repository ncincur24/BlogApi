using BlogApi.Api.Extensions;
using BlogApi.Api.Jwt.TokenStorage;
using BlogApi.Api.Jwt;
using BlogApi.Api.Settings;
using BlogApi.Application.UseCaseHandling;
using BlogApi.Application.UseCases.Queries;
using BlogApi.DataAccess;
using BlogApi.Implementation;
using BlogApi.Implementation.UseCases.Queries;
using BlogApi.Application;
using Bugsnag.AspNet.Core;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using BlogApi.Application.Logging;
using BlogApi.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var appSettings = new AppSettings();
builder.Configuration.Bind(appSettings);

var configuration = builder.Configuration;
builder.Services.AddTransient<QueryHandler>();


builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
builder.Services.AddTransient<JwtManager>(x =>
{
    var context = x.GetService<BlogContext>();
    var tokenStorage = x.GetService<ITokenStorage>();
    return new JwtManager(context, appSettings.Jwt.Issuer, appSettings.Jwt.SecretKey, appSettings.Jwt.DurationSeconds, tokenStorage);
});
builder.Services.AddLogger();

builder.Services.AddBugsnag(configuration => {
    configuration.ApiKey = appSettings.BugSnagKey;
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    var header = accessor.HttpContext.Request.Headers["Authorization"];

    var data = header.ToString().Split("Bearer ");

    if (data.Length < 2)
    {
        return new AnonimousUser();
    }

    var handler = new JwtSecurityTokenHandler();

    var tokenObj = handler.ReadJwtToken(data[1].ToString());

    var claims = tokenObj.Claims;

    var email = claims.First(x => x.Type == "Email").Value;
    var id = claims.First(x => x.Type == "Id").Value;
    var username = claims.First(x => x.Type == "Username").Value;
    var useCases = claims.First(x => x.Type == "UseCases").Value;

    List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

    return new JwtActor
    {
        Email = email,
        AllowedUseCases = useCaseIds,
        Id = int.Parse(id),
        Username = username,
    };
});
builder.Services.AddJwt(appSettings);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddTransient<IGetCategoriesQuery, GetCategoriesQuery>();
builder.Services.AddTransient<IGetHashTagsQuery, GetHashTagsQuery>();
builder.Services.AddTransient<IGetBlogsQuery, GetBlogsQuery>();
builder.Services.AddTransient<IGetSingleBlogQuery, GetSingleBlogQuery>();
builder.Services.AddTransient<BlogContext>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<BlogContext>(x =>
{
    DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
    builder.UseSqlServer(@"Data Source=nemanja\sqlexpress; Initial Catalog = Blog; Integrated Security = true");
    return new BlogContext(builder.Options);
});

//builder.Services.AddTransient<IEmailSend, EmailSend>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP_Projekat_API", Version = "v1" });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddTransient<IQueryHandler>(x =>
{
    var actor = x.GetService<IApplicationActor>();
    var logger = x.GetService<IUseCaseLogger>();
    var queryHandler = new QueryHandler();
    var timeTrackingHandler = new TimeTrackingQueryHandler(queryHandler);
    var loggingHandler = new LoggingQueryHandler(timeTrackingHandler, actor, logger);
    var decoration = new AuthorizationQueryHandler(actor, loggingHandler);

    return decoration;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
