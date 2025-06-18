using WebFileSystem.Service.Services;
using WebFileSystem.StorageBroker.Services;

namespace WebFileSystem.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IStorageBrokerService, LocalStorageBrokerService>();
        builder.Services.AddScoped<IStorageService, StorageService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        //  wwwroot ichidagi static fayllarga kirish uchun ruxsat berildi
        app.UseStaticFiles(); // uploads, images, css, js kabi fayllar uchun

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
