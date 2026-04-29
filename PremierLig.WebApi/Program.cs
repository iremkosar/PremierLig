using Microsoft.EntityFrameworkCore;
using PremierLig.BusinessLayer.Abstract;
using PremierLig.BusinessLayer.Concrete;
using PremierLig.DataAccessLayer.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(PremierLig.BusinessLayer.Mapping.MappingProfile));

builder.Services.AddDbContext<PremierLigContext>();


builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<IFixtureService, FixtureManager>();
builder.Services.AddScoped<IMatchDetailService,MatchDetailManager>();
builder.Services.AddScoped<IStandingService, StandingManager>();
builder.Services.AddScoped<ILeagueService, LeagueManager>();
builder.Services.AddScoped<IStadiumService, StadiumManager>();
builder.Services.AddScoped<ISeasonService, SeasonManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
