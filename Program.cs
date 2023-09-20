using job_opportunities_asp_react.Models.Entities;
using job_opportunities_asp_react.Models.Repositories;
using job_opportunities_asp_react.Services;
using job_opportunities_asp_react.Services.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<JobOpportunitiesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JobOpportunitiesContext"));
});

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IGenericRepository<Applicant>, ApplicantRepository>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
