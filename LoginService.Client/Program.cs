using LoginService.Client.Components;
using LoginService.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar AuthService con HttpClient y base URL desde configuración
builder.Services.AddHttpClient<AuthService>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
    client.BaseAddress = new Uri(apiBaseUrl!);
});

// Agregar servicios de Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configuración del pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();