
using AppData.DiConfig;
namespace AppApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ConfigurationManager configuration = builder.Configuration;
        builder.Services.ServiceConfigurationExt(configuration);

        builder.Services.AddCors(options =>
        options.AddDefaultPolicy(builder =>
            builder.WithOrigins("https://localhost:7298",
            "http://localhost:5245")
                .AllowAnyHeader()
                .AllowAnyMethod()));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        app.UseCors();

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