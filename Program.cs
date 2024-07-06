using System.Diagnostics;
using System.Runtime.InteropServices;

[DllImport("user32")]
static extern void LockWorkStation();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseUrls("http://0.0.0.0:6789");

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/lock", () =>
{
    LockWorkStation();
});

app.MapGet("/shutdown", () =>
{
    Process.Start("shutdown", "/s /f /t 0");
});

app.MapGet("/restart", () =>
{
    Process.Start("shutdown", "/r /f /t 0");
});

app.Run();
