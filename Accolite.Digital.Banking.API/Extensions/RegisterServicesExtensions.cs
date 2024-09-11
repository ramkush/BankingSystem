using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Accolite.Digital.Banking.API.Attribute;
namespace Accolite.Digital.Banking.API.Extensions
{
    public static class RegisterServicesExtensions
    {
        public static void InjectServices(this WebApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (builder.Configuration == null)
            {
                throw new ArgumentNullException(nameof(builder.Configuration));
            }
      
            //Add Client
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();

                      //Add Mapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new GlobalExceptionHandler());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddRouting(options => options.LowercaseUrls = true);
                 
        }

    }
}
