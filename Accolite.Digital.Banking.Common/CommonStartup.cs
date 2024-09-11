
using Accolite.Digital.Banking.Common.Data;
using Accolite.Digital.Banking.Common.Services;
using Accolite.Digital.Banking.Common.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Accolite.Digital.Banking.Common
{
    public static class CommonStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
           
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IDataService, DummyDataService>();
            services.AddScoped<IUserService, UserService>();
            
            //services.AddScoped<IAccountService, AccountService>();
        }

        public static void ConfigureDatabase(IServiceCollection services, string connectionString)
        {
        }
    }
}
