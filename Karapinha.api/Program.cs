using Karapinha.DAL;
using Karapinha.DAL.Repositories;
using Karapinha.Service;
using Karapinha.Services;
using Karapinha.Shared;
using Karapinha.Shared.IRepository;
using Karapinha.Shared.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICategoriaService,CategoriaService>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddTransient<IHorarioService, HorarioService>();
builder.Services.AddTransient<IHorarioRepository, HorarioRepository>();

builder.Services.AddTransient<IUtilizadorService, UtilizadorService>();
builder.Services.AddTransient<IUtilizadorRepository, UtilizadorRepository>();

builder.Services.AddTransient<IProfissionalService, ProfissionalService>();
builder.Services.AddTransient<IProfissionalRepository, ProfissionalRepository>();

builder.Services.AddTransient<IServicoService, ServicoService>();
builder.Services.AddTransient<IServicoRepository, ServicoRepository>();

builder.Services.AddTransient<IHorarioFuncionarioService, HorarioFuncionarioService>();
builder.Services.AddTransient<IHoraFuncionarioRepository, HorarioFuncionarioRepository>();

builder.Services.AddTransient<IMarcacaoServico, MarcacaoServicoService>();
builder.Services.AddTransient<IMarcacaoServicoRepository, MarcacaoServicoRepository>();

builder.Services.AddTransient<IMarcacaoService, MarcacaoService>();
builder.Services.AddTransient<IMarcacaoRepository, MarcacaoRepository>();

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:7143") 
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var connectionString = builder.Configuration.GetConnectionString("conn");

builder.Services.AddDbContext<KarapinhaContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(KarapinhaContext).Assembly.FullName)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
