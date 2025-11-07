
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShopMicroservices.Cargo.BusinessLayer.Abstract;
using MultiShopMicroservices.Cargo.BusinessLayer.Concrete;
using MultiShopMicroservices.Cargo.DataAccessLayer.Abstract;
using MultiShopMicroservices.Cargo.DataAccessLayer.Concrete;
using MultiShopMicroservices.Cargo.DataAccessLayer.EntityFramework;

namespace MultiShopMicroservices.Cargo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = builder.Configuration["IdentityServerUrl"];
                    options.Audience = "ResourceCargo";
                    options.RequireHttpsMetadata = false;
                });

            builder.Services.AddDbContext<CargoContext>();

            builder.Services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
            builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();

            builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
            builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();

            builder.Services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
            builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();

            builder.Services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
            builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
