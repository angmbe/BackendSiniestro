using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;
using Dapper;
using BackendSiniestro.Models;
using System.Linq;

namespace BackendSiniestro
{
    public static class Function1
    {
        [FunctionName("GetTipoSiniestro")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "tiposiniestro")] HttpRequest req,
            ILogger log)
        {
            var connectionString = Environment.GetEnvironmentVariable("SqlConnection");
            using var connection = new SqlConnection(connectionString);
            var data = await connection.QueryAsync<TipoSiniestro>("SELECT * FROM TipoSiniestro");
            return new OkObjectResult(data);
        }        
    }
}
