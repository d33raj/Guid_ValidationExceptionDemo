
using Guid_Demo.Data;
using Guid_Demo.Exceptions;
using Guid_Demo.Repositories;
using Guid_Demo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Guid_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EmployeeContext>(options =>
            { options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString")); });
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddTransient<IEmployeeServices, EmployeeServices>();
            builder.Services.AddControllers();
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddExceptionHandler<EmployeeExceptionHandler>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseExceptionHandler(_ => { });
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
