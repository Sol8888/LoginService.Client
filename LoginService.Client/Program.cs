using LoginService.Client.Components;
using LoginService.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar AuthService con HttpClient y base URL desde configuraci�n
// Configurar AuthService con HttpClient y base URL desde configuraci�n
builder.Services.AddHttpClient<AuthService>(client =>
{
    var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

    // Aqu� agregas el log para ver la URL que realmente se est� usando
    Console.WriteLine($"[Blazor] Usando API en: {apiBaseUrl}");

    client.BaseAddress = new Uri(apiBaseUrl!);
});



// Agregar servicios de Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configuraci�n del pipeline
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