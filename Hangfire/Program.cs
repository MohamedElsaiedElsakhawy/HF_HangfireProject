using Hangfire;
using Hangfire.Models;
using HF.Hangfire.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<CompanyDBContext>();

string hangfireConnectionString = "HangfireConnection";
HangfireExtension.HangfireExtensionMethod(builder, hangfireConnectionString);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

string mapping = "dashboard";
HangfireCustomMiddleware.UseMyMiddleware(app, mapping);

//app.UseHangfireDashboard("/dashboard");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();