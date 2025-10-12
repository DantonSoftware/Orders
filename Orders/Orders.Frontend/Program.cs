using MudBlazor.Services;
using Orders.Frontend.Components;
using Orders.Frontend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri("https://localhost:7262") });
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();        // ← añade esto

// 🟩 ORDEN CORRECTO: después de UseStaticFiles y antes de MapRazorComponents
app.UseRouting();
app.UseAntiforgery(); // ← aquí va, entre UseRouting y MapRazorComponents

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();