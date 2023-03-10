using BookStoreManager.Interface;
using BookStoreManager.Manager;
using BookStoreRepository.Interface;
using BookStoreRepository.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using System.Text;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("in it main");
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                ConfigurationManager configuration = builder.Configuration;
                builder.Services.AddStackExchangeRedisCache(
                options =>
                {
                    options.Configuration = configuration["RedisCacheUrl"];
                });
                // Add services to the container.

                builder.Services.AddControllers();
                builder.Services.AddTransient<IUserRepository, UserRepository>();
                builder.Services.AddTransient<IUserManager, UserManager>();
                builder.Services.AddTransient<IBookRepository, BookRepository>();
                builder.Services.AddTransient<IBookManager, BookManager>();
                builder.Services.AddTransient<IAdminManager, AdminManager>();
                builder.Services.AddTransient<IAdminRepository, AdminRepository>();
                builder.Services.AddTransient<IWishlistManager, WishlistManager>();
                builder.Services.AddTransient<IWishlistRepository, WishlistRepository>();
                builder.Services.AddTransient<ICartManager, CartManager>();
                builder.Services.AddTransient<ICartRepository, CartRepository>();
                builder.Services.AddTransient<IAddressManager, AddressManager>();
                builder.Services.AddTransient<IAddressRepository, AddressRepository>();
                builder.Services.AddTransient<IFeedbackManager, FeedbackManager>();
                builder.Services.AddTransient<IFeedbackRepository, FeedbackRepository>();
                builder.Services.AddTransient<IOrderManager, OrderManager>();
                builder.Services.AddTransient<IOrderRepository, OrderRepository>();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(s =>
                {
                    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Welcome to Book Store" });
                    var jwtSecurityScheme = new OpenApiSecurityScheme
                    {
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Name = "JWT Authentication",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Description = "Enter JWT Bearer Token in Textbox For Authorization",

                        Reference = new OpenApiReference
                        {
                            Id = JwtBearerDefaults.AuthenticationScheme,
                            Type = ReferenceType.SecurityScheme
                        }
                    };
                    s.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                    s.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                    { jwtSecurityScheme, Array.Empty<string>() },
                        });
                });
                var tokenKey = builder.Configuration.GetValue<string>("Jwt:key");
                var key = Encoding.ASCII.GetBytes(tokenKey);
                builder.Services.AddAuthentication(a =>
                {
                    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(j =>
                {
                    j.RequireHttpsMetadata = false;
                    j.SaveToken = true;
                    j.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

                builder.Logging.ClearProviders();
                builder.Host.UseNLog();

                var app = builder.Build();
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }
                app.UseAuthentication();
                app.UseHttpsRedirection();
                app.UseRouting();
                app.UseAuthorization();


                app.MapControllers();
                app.MapControllerRoute(
                        name: "Admin",
                        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Program Stopped Beacuse of Exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
    }
}
