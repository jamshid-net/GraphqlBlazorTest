using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using GraphqlBlazorTest.Server.Data;
using GraphqlBlazorTest.Server.ExelFileGenerator;
using GraphqlBlazorTest.Server.GraphqlServices;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GraphqlBlazorTest;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin",
                builder => builder.WithOrigins("http://localhost:4200")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
        });


        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.AddScoped(typeof(ExelFileGenerator<>));
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnect"));
        });
        builder.Services.AddGraphQLServer().RegisterService<ApplicationDbContext>()
            .AddQueryType<EmployeeServiceQuery>()
            .AddFiltering()
            .AddMutationType<EmployeeServiceMutation>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();


        app.MapRazorPages();
        app.MapControllers();
        app.MapGraphQL();
        app.MapFallbackToFile("index.html");

        app.Run();
    }
}
