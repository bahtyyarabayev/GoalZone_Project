using GoalZonePremierLig.UI.Services.FixtureServices;
using GoalZonePremierLig.UI.Services.MatchServices;
using GoalZonePremierLig.UI.Services.StatisticService;
using GoalZonePremierLig.UI.Services.TeamServices;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// ✅ HttpClient ile birlikte register et
builder.Services.AddHttpClient<IFixtureService, FixtureService>();
builder.Services.AddHttpClient<IMatchService, MatchService>();
builder.Services.AddHttpClient<ITeamService, TeamService>();
builder.Services.AddHttpClient<IStatisticService, StatisticService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();