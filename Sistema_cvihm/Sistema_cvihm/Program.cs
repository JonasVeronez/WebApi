using Microsoft.EntityFrameworkCore;
using Sistema_cvihm.Data;
using Sistema_cvihm.Repositorios;
using Sistema_cvihm.Repositorios.Interface;

namespace Sistema_cvihm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<SistemasTarefasContext>(
                    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefasRepositorio, TarefasRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}