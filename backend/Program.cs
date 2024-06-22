using MyUniversityAPP.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte para controllers (n�o precisamos de ControllersWithViews pois voc� est� servindo uma SPA)
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mant�m PascalCase
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configurar o pipeline de requisi��o HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Para servir os arquivos est�ticos do Angular.

app.UseRouting(); // Configura o roteamento.

app.UseAuthorization();

// Configura os endpoints para usar os controllers
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Servir o arquivo index.html para todas as rotas n�o API
//app.MapFallbackToFile("index.html");

app.Run();
