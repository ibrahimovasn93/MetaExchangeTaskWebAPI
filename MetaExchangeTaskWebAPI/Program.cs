using metaExchangeTask; // Import the namespace where IMetaExchange is defined
using Microsoft.OpenApi.Models;


namespace MetaExchangeTaskWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetaExchangeTask Web API", Version = "v1" });
            });

            // Register your IMetaExchange implementation
            builder.Services.AddSingleton<IMetaExchange, metaExchangeTask.Program>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetaExchangeTask Web API v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
