using Microsoft.EntityFrameworkCore;
using PIM_4_SEMESTRE.MinhaAplicacao.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurações do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilita CORS para permitir acesso ao frontend (ajuste as origens conforme necessário)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Configurações de controladores e outras dependências
builder.Services.AddControllers();

var app = builder.Build();

// Configuração do middleware para servir arquivos estáticos (opcional)
app.UseStaticFiles();

// Habilitar CORS (usando a política "AllowAllOrigins" definida acima)
app.UseCors("AllowAllOrigins");

// Configurações do roteamento e endpoints
app.MapControllers();

// Executa a aplicação
app.Run();