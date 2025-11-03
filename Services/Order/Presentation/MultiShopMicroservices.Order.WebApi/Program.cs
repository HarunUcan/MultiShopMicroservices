
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShopMicroservices.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShopMicroservices.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShopMicroservices.Order.Application.Interfaces;
using MultiShopMicroservices.Order.Application.Services;
using MultiShopMicroservices.Order.Persistense.Context;
using MultiShopMicroservices.Order.Persistense.Repositories;

namespace MultiShopMicroservices.Order.WebApi
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
                    options.Audience = "ResourceOrder";
                    options.RequireHttpsMetadata = false;
                });

            builder.Services.AddDbContext<OrderContext>();

            builder.Services.AddScoped<GetAddressQueryHandler>();
            builder.Services.AddScoped<GetAddressByIdQueryHandler>();
            builder.Services.AddScoped<CreateAddressCommandHandler>();
            builder.Services.AddScoped<UpdateAddressCommandHandler>();
            builder.Services.AddScoped<RemoveAddressCommandHandler>();

            builder.Services.AddScoped<GetOrderDetailQueryHandler>();
            builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
            builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
            builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
            builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddApplicationServices(builder.Configuration);

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
