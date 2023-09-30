using job_opportunities_asp_react.Models.Entities;
using job_opportunities_asp_react.Models.Repositories;
using job_opportunities_asp_react.Services;
using job_opportunities_asp_react.Services.Utils;
using job_opportunities_asp_react.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using job_opportunities_asp_react;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<JobOpportunitiesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JobOpportunitiesContext"));
});

builder.Services.AddScoped<IGenericRepository<Applicant>, ApplicantRepository>();
builder.Services.AddScoped<IReadOnlyRepository, ReadOnlyRepository>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<IReadOnlyService, ReadOnlyService>();

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
