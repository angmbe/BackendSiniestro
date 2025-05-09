using BackendSiniestro.Interface;
using BackendSiniestro.Models;
using BackendSiniestro.Repository;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(BackendSiniestro.Startup))]

namespace BackendSiniestro
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(
                Environment.GetEnvironmentVariable("SqlConnection")));
            builder.Services.AddTransient<IRepository<Parentesco>, DapperRepository<Parentesco>>();

        }
    }
}
