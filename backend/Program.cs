using MyUniversityAPP.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mant�m PascalCase
});

//Obtem connectionStringconnectionString
string? connectionString = builder.Configuration["ConnectionString"] ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

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

app.MapControllers();

// Servir o arquivo index.html para todas as rotas n�o API
app.MapFallbackToFile("index.html");

app.Run();
