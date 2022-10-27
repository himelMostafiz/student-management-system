using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Utility.Helpers;

namespace Utility
{
    public class UtilityDependency
    {
        public static void ALLDependency(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton(typeof(TaposRSA));
            //services.AddTransient(typeof(TaposRSA));
        }

    }
}
