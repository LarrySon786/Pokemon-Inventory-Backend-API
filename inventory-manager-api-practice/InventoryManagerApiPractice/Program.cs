using InventoryManagerApiPractice.Components;
using InventoryManagerApiPractice.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// My own API (inventory manager)
builder.Services.AddHttpClient<ProductApiService>(client =>
    client.BaseAddress = new Uri("http://localhost:5223/")
);

// Pokemon API
builder.Services.AddHttpClient<PokemonApiService>(client =>
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/")
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
